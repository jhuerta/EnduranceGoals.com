<<<<<<< HEAD
﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Smart.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.RegisterModel>" %>
=======
﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Endurance.Master" Inherits="System.Web.Mvc.ViewPage<EnduranceGoals.Models.RegisterModel>" %>
>>>>>>> 675e7f5c8871d68d50cb7af8df43ce5839c94609

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PartialTitle" runat="server">
                New Account
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       { %>
    <%= Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <!-- start: Container -->
            <div class="container">
                <!-- start: Row -->
                <div class="row">
                    <!-- start: About -->
                    <div class="span4">
                        <div class="editor-label">
                            <%= Html.LabelFor(m => m.Name) %>
                        </div>
                        <div class="editor-field">
                            <%= Html.TextBoxFor(m => m.Name)%>
                            <%= Html.ValidationMessageFor(m => m.Name) %>
                        </div>
                        <div class="editor-label">
                            <%= Html.LabelFor(m => m.LastName) %>
                        </div>
                        <div class="editor-field">
                            <%= Html.TextBoxFor(m => m.LastName) %>
                            <%= Html.ValidationMessageFor(m => m.LastName) %>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="editor-label">
                            <%= Html.LabelFor(m => m.UserName) %>
                        </div>
                        <div class="editor-field">
                            <%= Html.TextBoxFor(m => m.UserName) %>
                            <%= Html.ValidationMessageFor(m => m.UserName) %>
                        </div>
                        <div class="editor-label">
                            <%= Html.LabelFor(m => m.Email) %>
                        </div>
                        <div class="editor-field">
                            <%= Html.TextBoxFor(m => m.Email) %>
                            <%= Html.ValidationMessageFor(m => m.Email) %>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="editor-label">
                            <%= Html.LabelFor(m => m.Password) %>
                        </div>
                        <div class="editor-field">
                            <%= Html.PasswordFor(m => m.Password) %>
                            <%= Html.ValidationMessageFor(m => m.Password) %>
                        </div>
                        <div class="editor-label">
                            <%= Html.LabelFor(m => m.ConfirmPassword) %>
                        </div>
                        <div class="editor-field">
                            <%= Html.PasswordFor(m => m.ConfirmPassword) %>
                            <%= Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                            (password min length:
                            <%= Html.Encode(ViewData["PasswordLength"]) %>
                            )
                        </div>
                        <p>
                            <input type="submit" value="Register" class="btn btn-primary  btn-large" />
                        </p>
                    </div>
                </div>
                <!-- end: Row -->
            </div>
            <!-- end: Container -->
        </fieldset>
    </div>
    <% } %>
</asp:Content>
