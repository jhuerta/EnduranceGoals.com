using System;
using System.Web.Mvc;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models.Repositories;

namespace EnduranceGoals.Controllers
{
    public class UserController : Controller
    {
        public ActionResult UpdateEmail([Bind(Prefix = "id")] string name)
        {
            Users users = new Users(SessionProvider.OpenSession());

            var user = users.GetByName(name);

            user.Email = name.ToLower() + DateTime.Now.ToShortTimeString() + "@email.com";

            var jsonGoal = new
                               {
                                   Name = user.Name,
                                   Description = user.Email,
                                   Id = user.Id,
                                   Date = user.Password
                               };

            users.Update(user);

            return Json(jsonGoal, JsonRequestBehavior.AllowGet);
        }
    }
}