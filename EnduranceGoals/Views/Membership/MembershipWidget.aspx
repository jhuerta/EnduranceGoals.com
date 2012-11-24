<%@ Page Language="C#" Inherits="ViewPage<EnduranceGoals.Models.ViewModels.MembershipManagementViewModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<span id="<%= Model.DivId %>">
    <% if (Model.IsSubscribed)
       {%>
    <%= Ajax.ActionLink(
        "I want out!",
            "Unsubscribe",
                "Membership",
                new { goalId=Model.GoalId},
                        new AjaxOptions() { UpdateTargetId = Model.DivId, OnSuccess = "AnimateSubscriptionMessage($('#" + Model.DivId + "'))" })%>
    <% } %>
    <% else
        {%>
    <%= Ajax.ActionLink(
        "I want in!",
            "Subscribe",
                "Membership",
                new { goalId=Model.GoalId},
                        new AjaxOptions() { UpdateTargetId = Model.DivId, OnSuccess = "AnimateSubscriptionMessage($('#" + Model.DivId + "'))" })%>
    <% } %>
</span>

<script type="text/javascript">
    function AnimateSubscriptionMessage(item) {
        item.effect("highlight", { color: '#29A9DF' }, 2000);
    }
</script>


