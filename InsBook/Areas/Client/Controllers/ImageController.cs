using InsBook.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class ImageController : Controller
    {
        // GET: Client/Image
        // bỏ đường dẫn của ảnh, bài viết
        // bỏ ngày đăng vì trong id đã có giá trị time
        // tách kiểm tra session, cookie thành 1 hàm riêng, trả vè giá trị user
        // user trả về giá trị đang bị thừa: cần loại bỏ 
        protected List<Int64> Images(HttpFileCollectionBase files, int userId, List<Int64> img_ids) //Hàm này để upload nhiều ảnh lên cùng 1 lúc từ file
        {
            List<string> urls = new List<string>();
            ImageDao imageDao = new ImageDao();
            List<Int64> imageIds = new List<Int64>();

            for (int i = 0; i < files.Count; i++)
            {
                var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

                string filename = Path.GetFileNameWithoutExtension(files[i].FileName);
                string ext = Path.GetExtension(files[i].FileName);

                if (allowedExtensions.Contains(ext))
                {
                    string number = new Accessories().RandomNumber();
                    string GUID = Path.Combine(Guid.NewGuid().ToString().Replace("-", "_") + "_" + number);

                    filename = files[i].FileName.Replace(filename, GUID);

                    urls.Add(filename);
                }
                else
                {
                    return imageIds;
                }
            }
            for (int i = 0; i < files.Count; i++)
            {
                UInt64 shardId = Convert.ToUInt64(userId % 2000) << 10;

                imageIds.Add(imageDao.InsertImage(urls[i], Convert.ToString(shardId), img_ids[i]));
                files[i].SaveAs(Path.Combine(Server.MapPath("~/Images"), urls[i]));
            }
            return imageIds;
        }
        protected List<Int64> Image(HttpFileCollectionBase files, int userId, NameValueCollection imgName, Int64 img_id) //Hàm này để upload 1 ảnh duy nhất sau khi cắt chuyển sang dạng blob
        {
            ImageDao imageDao = new ImageDao();

            var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

            string filename = Path.GetFileNameWithoutExtension(imgName[1]);
            string ext = Path.GetExtension(imgName[1]);

            string url = "";
            List<Int64> imageIds = new List<Int64>();

            if (allowedExtensions.Contains(ext))
            {
                string number = new Accessories().RandomNumber();
                string GUID = Path.Combine(Guid.NewGuid().ToString().Replace("-", "_") + "_" + number);

                filename = imgName[1].Replace(filename, GUID);

                url = filename;
            }
            else
            {
                return imageIds;
            }

            UInt64 shardId = Convert.ToUInt64(userId % 2000) << 10;

            imageIds.Add(imageDao.InsertImage(url, Convert.ToString(shardId), img_id));

            files[0].SaveAs(Path.Combine(Server.MapPath("~/Images"), url));
            return imageIds;
        }
    }
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public JsonResult AddImage()
    //{
    //    if (Session[CommonConstants.USER_SESSION] != null || Request.Cookies[CommonConstants.USER_COOKIE] != null)
    //    {
    //        var user = new UserLogin();
    //        // Lấy giá trị của cookie hoặc session
    //        if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
    //        {
    //            // lấy từ cookie
    //            user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu int
    //            user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
    //        }
    //        else
    //        {
    //            user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
    //        }

    //        try
    //        {
    //            List<string> urls = new List<string>();

    //            for (int i = 0; i < Request.Files.Count; i++)
    //            {
    //                var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

    //                string filename = Path.GetFileNameWithoutExtension(Request.Files[i].FileName);
    //                string ext = Path.GetExtension(Request.Files[i].FileName);

    //                if (allowedExtensions.Contains(ext))
    //                {
    //                    string number = new Accessories().RandomNumber();
    //                    string GUID = Path.Combine(Guid.NewGuid().ToString().Replace("-", "_") + "_" + number);

    //                    filename = Request.Files[i].FileName.Replace(filename, GUID);

    //                    urls.Add(filename);
    //                }
    //                else
    //                {
    //                    return Json(new
    //                    {
    //                        status = false
    //                    }, JsonRequestBehavior.AllowGet);
    //                }
    //            }

    //            for (int i = 0; i < Request.Files.Count; i++)
    //            {
    //                // bước 1: truyền toàn bộ url sang -- 1 hoặc nhiều ảnh
    //                // bước 2: tạo ra các Id tương ứng( xử lý bên sql) -- caption đăng xong mới cập nhật
    //                // bước 3: try catch id lỗi
    //                // Đang up 10 mà lỗi 1 cái ở giữa ??? tải lại bằng đc nó

    //                UInt64 time = (new Accessories().GetTime()) << 23;
    //                UInt64 shardId = Convert.ToUInt64(user.UserID % 2000) << 10;

    //                new ImageDao().InsertImage(urls[i], Convert.ToString(time), Convert.ToString(shardId));

    //                Request.Files[i].SaveAs(Path.Combine(Server.MapPath("~/Images"), urls[i]));
    //            }
    //            // bỏ đường dẫn của ảnh, bài viết
    //            // bỏ ngày đăng vì trong id đã có giá trị time
    //            // tách kiểm tra session, cookie thành 1 hàm riêng, trả vè giá trị user
    //            // user trả về giá trị đang bị thừa: cần loại bỏ 
    //            return Json(new
    //            {
    //                status = true
    //            }, JsonRequestBehavior.AllowGet); ;
    //        }
    //        catch (Exception ex)
    //        {
    //            return Json(new
    //            {
    //                status = false
    //            }, JsonRequestBehavior.AllowGet);
    //        }
    //    }
    //    else
    //    {
    //        return Json(new
    //        {
    //            status = false
    //        }, JsonRequestBehavior.AllowGet);
    //    }
    //}
}