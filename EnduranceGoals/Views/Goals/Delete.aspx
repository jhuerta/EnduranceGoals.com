﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    
    <fieldset>
        <legend>Delete event! </legend>
        
            <h3>Are you sure you want to delete "<%= Html.Encode(Model.Name) %>" on
    <%= String.Format("{0:d}", Html.Encode(Model.Name)) %> </h3>
    
            <%= Html.Hidden("Id", Model.Id)%>

    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <input type="submit" value="delete" class="btn btn-danger btn-micro" /> | 
            <%= Html.ActionLink("Back to list", "index","goals")%>
        </p>
    <% } %>

</asp:Content>