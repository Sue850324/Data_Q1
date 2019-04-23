using Suec_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;



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
                        switch (item.Locale)
                        {
                            case "US":
                                item.Price = string.Format(new CultureInfo("en-US"), "{0:C}", typetest);
                                break;
                            case "CA":
                                item.Price = string.Format(new CultureInfo("en-CA"), "{0:C}", typetest);
                                break;
                            case "DE":
                                item.Price = string.Format(new CultureInfo("de-DE"), "{0:C}", typetest);
                                break;
                            case "ES":
                                item.Price = string.Format(new CultureInfo("es-ES"), "{0:C}", typetest);
                                break;
                            case "FR":
                                item.Price = string.Format(new CultureInfo("fr-FR"), "{0:C}", typetest);
                                break;
                            case "JP":
                                item.Price = string.Format(new CultureInfo("ja-JP"), "{0:C}", typetest);
                                break;
                        }
                    }
                }
                if (String.IsNullOrEmpty(item.Promote_Price))
                {
                    item.Promote_Price = "-";
                }
                bool resultPromote = decimal.TryParse(item.Promote_Price, out decimal typechange);
                if (resultPromote == true)
                {
                    switch (item.Locale)
                    {
                        case "US":
                            item.Promote_Price = string.Format(new CultureInfo("en-US"), "{0:C}", typechange);
                            break;
                        case "CA":
                            item.Promote_Price = string.Format(new CultureInfo("en-CA"), "{0:C}", typechange);
                            break;
                        case "DE":
                            item.Promote_Price = string.Format(new CultureInfo("de-DE"), "{0:C}", typechange);
                            break;
                        case "ES":
                            item.Promote_Price = string.Format(new CultureInfo("es-ES"), "{0:C}", typechange);
                            break;
                        case "FR":
                            item.Promote_Price = string.Format(new CultureInfo("fr-FR"), "{0:C}", typechange);
                            break;
                        case "JP":
                            item.Promote_Price = string.Format(new CultureInfo("ja-JP"), "{0:C}", typechange);
                            break;
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
    

