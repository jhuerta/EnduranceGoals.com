<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary("Yo, check this out!") %>
    <fieldset>
        <legend><%=
           String.Format("{0} (created on {1:d})", Model.Name, Model.CreatedOn) %> <b>(<%= Html.ActionLink("details", "Details", new { id=Model.Id})%>)  </b></legend>

        <%= Html.Hidden("Id", Model.Id)%>
        
        <input type="hidden" id="Id" value="@Model.Id"/>
        
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Name) %>
            <%= Html.ValidationMessageFor(model => model.Name) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Description) %>
        </div>
        <div class="editor-field">
            <%= Html.TextAreaFor(model => model.Description) %>
            <%= Html.ValidationMessageFor(model => model.Description) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Web) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Web) %>
            <%= Html.ValidationMessageFor(model => model.Web) %>
        </div>
        
        <div class="editor-field">
            <%= Html.DropDownListFor(model => model.SportName,ViewData["Sports"] as SelectList) %>
        </div>
        
        
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
