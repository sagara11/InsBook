using InsBook.Areas.Client.Models;
using Model.Dao;
using Model.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InsBook.Areas.Client.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Client/Locations
        public void AddLocation()
        {
            string jsonFilePath = @"C:\Users\ACER\Downloads\tinh_tp.json";

            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                List<SetLocationModal> array = JsonConvert.DeserializeObject<List<SetLocationModal>>(json);
                foreach (var item in array)
                {
                    diadiem dd = new diadiem();
                    dd.id = int.Parse(item.code);
                    dd.ten = item.name;
                    dd.parent_id = null;
                    new LocationDao().InsertLocation(dd);
                }
            }
        }
    }
}