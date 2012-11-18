using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace EnduranceGoals.Helpers
{
    public static class HelperExtension
    {
        public static MvcHtmlString HiddenFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes)
        {
            var propertyName = ExpressionHelper.GetExpressionText(expression);

            var input = new TagBuilder("input");
            input.MergeAttribute("id", helper.AttributeEncode(helper.ViewData.TemplateInfo.GetFullHtmlFieldId(propertyName)));
            input.MergeAttribute("name", helper.AttributeEncode(helper.ViewData.TemplateInfo.GetFullHtmlFieldName(propertyName)));
            input.MergeAttribute("value", "aaa");
            input.MergeAttribute("type", "hidden");
            input.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(input.ToString());
        }
    }
    public static class ActionLinkExtension
    {
        public static string ActionLink(this HtmlHelper helper, string userName)
        {
            return helper.ActionLink(
                userName, "Details", "Goals", new { Id = userName }).
                ToHtmlString();

        }
    }
}