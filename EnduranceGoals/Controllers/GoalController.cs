using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using NHibernate;
using NHibernate.Impl;

namespace EnduranceGoals.Controllers
{
    public class GoalController : Controller
    {
        public ActionResult Index()
        {
            var session = (ISession) System.Web.HttpContext.Current.Items["current.session"];
            Goals goals = new Goals(session);
            var goalList = goals.GetAll();
            return Json(
            new { success = goalList }
        , JsonRequestBehavior.AllowGet);
        }
    }
}
