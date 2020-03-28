using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsBook.Areas.Client.Models
{
    public class SetLocationModal
    {
        public string name { set; get; }
        public string slug { set; get; }
        public string type { set; get; }
        public string name_with_type { set; get; }
        public string code { set; get; }
        //List<SetDistrict> quan_huyen { set; get; }
    }
    //class SetDistrict
    //{
    //    public string name { set; get; }
    //    public string type { set; get; }
    //    public string slug { set; get; }
    //    public string name_with_type { set; get; }
    //    public string path { set; get; }
    //    public string path_with_type { set; get; }
    //    public string code { set; get; }
    //    public string parent_code { set; get; }
    //    List<SetSubDistrict> xa_phuong { set; get; }
    //}
    //class SetSubDistrict
    //{
    //    public string name { set; get; }
    //    public string type { set; get; }
    //    public string slug { set; get; }
    //    public string name_with_type { set; get; }
    //    public string path { set; get; }
    //    public string path_with_type { set; get; }
    //    public string code { set; get; }
    //    public string parent_code { set; get; }
    //}
}