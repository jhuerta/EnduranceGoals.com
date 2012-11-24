<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="PartialTitle" runat="server">
Log On (<%= Html.ActionLink("Register", "Register") %> )
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%= Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                
                            <!-- start: Container -->
            <div class="container">
                <!-- start: Row -->
                <div class="row">
                    <!-- start: About -->
                    <div class="span3">
                    
                <div class="editor-label">
                    <%= Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%= Html.TextBoxFor(m => m.UserName) %>
                    <%= Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                </div>
                    <div class="span3">
                
                <div class="editor-label">
                    <%= Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%= Html.PasswordFor(m => m.Password) %>
                    <%= Html.ValidationMessageFor(m => m.Password) %>
                    <%= Html.CheckBoxFor(m => m.RememberMe, new { style = "float: left;margin-right: 10px;" })%> <%= Html.LabelFor(m => m.RememberMe) %>
                    
                </div>
                </div>
                
         
                
                    <div class="span2">
                
                <div><div><br/></div>
                    <input type="submit" value="Log On" class="btn btn-primary btn-large"/>
                </div>
                
            </fieldset>
        </div>
    <% } %>
</asp:Content>
