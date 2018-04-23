using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using dragDropMvc.Models;

namespace dragDropMvc.Controllers {
    public class HomeController : Controller {
        DataProvider provider = new DataProvider();

        public ActionResult Index() {
            return View();
        }

        public ActionResult CallbackPanelPartial(int? key, bool? leftToRight) {
            if (key != null)
                provider.Update(Convert.ToInt32(key),Convert.ToBoolean(leftToRight));
            return PartialView("_CallbackPanelPartial");
        }

        public ActionResult GridOne() {
            return PartialView("_GridOne", provider.GetFirstGridData());
        }
        public ActionResult GridTwo() {
            return PartialView("_GridTwo", provider.GetSecondGridData());
        }
    }
}