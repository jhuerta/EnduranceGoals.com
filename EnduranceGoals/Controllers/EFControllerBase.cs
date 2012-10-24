using System.Web.Mvc;
using EnduranceGoals.Models;

namespace EnduranceGoals.Controllers
{
    public class EFControllerBase : Controller
    {
        protected EnduranceGoalsEntities entity = new EnduranceGoalsEntities();


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            entity.SaveChanges();
        }
    }
}