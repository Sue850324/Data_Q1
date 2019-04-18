using Suec_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;



namespace Suec_Data.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string filepath = Server.MapPath("~/App_Data/data.json");
            string json = System.IO.File.ReadAllText(filepath);

            List<TestModel> list = JsonConvert.DeserializeObject<List<TestModel>>(json);
            foreach (var item in list)
            {
                if (String.IsNullOrEmpty(item.Price))
                {
                    item.Price = "-";
                }
                else
                {
                    bool resultPrice = decimal.TryParse(item.Price, out decimal typetest);
                    if (resultPrice == true)
                    {
                        if (item.Locale == "US" || item.Locale == "CA")
                        {
                            item.Price = string.Format("{0:$###,###.###}", typetest);
                        }
                        else if (item.Locale == "DE" || item.Locale == "ES" || item.Locale == "FR")
                        {
                            item.Price = string.Format("{0:€###,###.###}", typetest);
                        }
                        else if (item.Locale == "JP")
                        {
                            item.Price = string.Format("{0:¥###,###.###}", typetest);
                        }
                    }
                    else
                    {
                        item.Price = "-";
                    }
                }
                if (String.IsNullOrEmpty(item.Promote_Price))
                {
                    item.Promote_Price = "-";
                }
                bool resultPromote = decimal.TryParse(item.Promote_Price, out decimal typechange);
                if (resultPromote == true)
                {
                    if (item.Locale == "US" || item.Locale == "CA")
                    {
                        item.Promote_Price = "$" + typechange.ToString("N");
                    }
                    else if (item.Locale == "DE" || item.Locale == "ES" || item.Locale == "FR")
                    {
                        item.Promote_Price = "€" + typechange.ToString("N"); 
                    }
                    else if (item.Locale == "JP")
                    {
                        item.Promote_Price = "¥" + typechange.ToString("N"); 
                    }
                }
                else
                {
                    item.Promote_Price = "-";
                }
            }

            return View(list);
        }
    }
}
