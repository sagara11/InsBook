using InsBook.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers; // ContentDispositionHeaderValue
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class ImageController : Controller
    {
        // GET: Client/Image
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddImage()
        {
            //for (int i = 0; i < Request.Files.Count; i++)
            //{
            //    var file = Request.Files[i];
            //    string a = Path.GetFileNameWithoutExtension(file.FileName);
            //    string b = file.FileName.Replace(a, "oivailon");
            //    var path = Path.Combine(Server.MapPath("~/Images/"), b);
            //    file.SaveAs(path);
            //}

            // đặt lại tên cho ảnh sao cho ko bao gio trùng nhau UUID

            //try
            //{
                var file = Request.Files[0];
                var folderName = Path.Combine("Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.ContentLength > 0)
                {
                    var filePath = Path.GetTempFileName();

            }
            //    else
            //    {
            //        return BadRequest();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, "Internal server error");
            //}



            //string fileNameDB = uploadProductImage(file.FileName);
            //      $fileName = time().$file['name'];
            //      $destination_path = getcwd().DIRECTORY_SEPARATOR;
            //$uploadPath = WWW_ROOT.DS. 'source/avatar'.DS. $fileName;
            //      if (file_exists($uploadPath))
            //      {
            //          return false;
            //      }
            //      if (move_uploaded_file($file['tmp_name'],$uploadPath))
            //      {
            //          return Router::fullbaseUrl().'/source/avatar/'.$fileName;
            //      }
            //      else
            //      {
            //          return false;
            //      }

            //      if (Session[CommonConstants.USER_SESSION] != null || Request.Cookies[CommonConstants.USER_COOKIE] != null)
            //      {
            //          var user = new UserLogin();
            //          // Lấy giá trị của cookie hoặc session
            //          if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
            //          {
            //              // lấy từ cookie
            //              user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
            //              user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
            //          }
            //          else
            //          {
            //              user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
            //          }

            //          var friend = new banbe();
            //          friend.nguoidung1 = user.UserID;
            //          friend.nguoidung2 = id2;
            //          friend.xacnhan = 0;
            //          friend.nguoihanhdong = user.UserID;
            //          friend.ngaybatdau = DateTime.Now;
            //          friend.uutien = 1;

            //          bool result = new AddFriendDao().InsertFriend(friend);

            //          return Json(new
            //          {
            //              status = result
            //          }, JsonRequestBehavior.AllowGet);
            //      }
            //      else
            //      {
            return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            //}
        }
  //      private string uploadProductImage(HttpPostedFileBase file)
  //      {
  //          try
  //          {
  //              if (file.ContentLength > 0)
  //              {
  //                  string _FileName = Path.GetFileName(file.FileName);
  //                  string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
  //                  if() //ảnh đã tồn tại trước đó chưa
  //                  {

  //                  }
  //                  if()
  //                  {

  //                  }
  //                  file.SaveAs(_path);
  //              }
  //          }
  //          catch
  //          {

  //          }

  //          string fileName = Request.Files["name"];


  //      $destination_path = getcwd().DIRECTORY_SEPARATOR;
		//$uploadPath = WWW_ROOT.DS. 'source/avatar'.DS. $fileName;
  //          if (file_exists($uploadPath))
  //          {
  //              return false;
  //          }
  //          if (move_uploaded_file($file['tmp_name'],$uploadPath))
  //          {
  //              return Router::fullbaseUrl().'/source/avatar/'.$fileName;
  //          }
  //          else
  //          {
  //              return false;
  //          }
  //      }
    }
}