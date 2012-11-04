<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(false) %>

        <fieldset>
            <legend>Add your event</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Date) %> (mm/dd/yyyy)
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Date) %> 
                <%= Html.ValidationMessageFor(model => model.Date) %>
            </div>

            
            <div class="editor-label">
                Event name
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Description) %>
                <%= Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Web) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Web) %>
                <%= Html.ValidationMessageFor(model => model.Web) %>
            </div>
            
            <p>
                <input type="submit" value="Add" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "upcoming") %>
    </div>

</asp:Content>

