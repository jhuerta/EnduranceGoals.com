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
                        new AjaxOptions() { UpdateTargetId = Model.DivId,
                                            OnSuccess = "AnimateSubscriptionMessageIn($('#" + Model.DivId + "'))"
                        },
                                            new { Class = "btn btn-warning btn-micro" })%>
    <% } %>
    <% else
        {%>
    <%= Ajax.ActionLink(
        "I want in!",
            "Subscribe",
                "Membership",
                new { goalId=Model.GoalId},
                        new AjaxOptions() { UpdateTargetId = Model.DivId,
                                            OnSuccess = "AnimateSubscriptionMessageIn($('#" + Model.DivId + "'))"
                        },
                                            new { Class = "btn btn-success btn-micro" })%>
    <% } %>
</span>

<script type="text/javascript">
    function AnimateSubscriptionMessageOut(item) {
        //item.fadeOut(10000);
    }

    function AnimateSubscriptionMessageIn(item) {
        //item.fadeOut(10000);
    }
</script>


