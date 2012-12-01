<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EnduranceGoals.Models.ViewModels.GoalViewModel>" %>





<% using (Html.BeginForm())
   {%>
<%= Html.ValidationSummary(false) %>
<fieldset>
            <!-- start: Container -->
            <div class="container">
                <!-- start: Row -->
                <div class="row">
                    <!-- start: About -->
                    <div class="span3">
    <input type="hidden" id="Id" value="<%=Model.Id%>" />
    <div class="editor-label">
        <%= Html.LabelFor(model => model.Name) %>
    </div>
    <div class="editor-field">
        <%= Html.TextBoxFor(model => model.Name) %>
        <%= Html.ValidationMessageFor(model => model.Name) %>
    </div>
    <div class="editor-label">
        When:
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.Date)%>
        <%= Html.ValidationMessageFor(model => model.Date) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.Web) %>
    </div>
    <div class="editor-field">
        <%= Html.TextBoxFor(model => model.Web) %>
        <%= Html.ValidationMessageFor(model => model.Web) %>
    </div>

        <%= Html.TextBoxFor(model => model.VenueLatitude, new { @id= "latitude-" + Model.Id, type="hidden"})%>
        <%= Html.TextBoxFor(model => model.VenueLongitude, new { @id = "longitude-" + Model.Id , type="hidden"})%>


    
    </div>
    
    <div class="span6">
    <div class="editor-label">
        <%= Html.LabelFor(model => model.Description) %>
    </div>
    <div class="editor-field">
        <%= Html.TextAreaFor(model => model.Description, new { @class = "span6", style = "height: 135px;"})%>
        <%= Html.ValidationMessageFor(model => model.Description) %>
    </div>

    </div>
    <%-- This is a different way of populating dropdown list
        <div class="editor-label">
            Sport:
        </div>
        <div class="editor-field">
            <%= Html.DropDownListFor(model => model.SportName,ViewData["Sports"] as SelectList) %>
        </div>
--%>
    <%--Make sure the name of the DropDownListFor is the identifier of the list of venues (to allow default value!)--%>
    <div class="span3">
    <div class="editor-label">
        Venue:
    </div>
    <div class="editor-field dropdown">
        <%= Html.DropDownListFor(m => m.VenueId, Model.Venues)%>
    </div>
    <div id="longitudeLatitudeVenue">Coordinates: </div>
    <div class="editor-label">
        Sport:
    </div>
    <div class="editor-field dropdown">
        <%= Html.DropDownListFor(m => m.SportId, Model.Sports)%>
    </div>
    <p>
        <input type="submit" value="Save" class="btn btn-primary btn-large" />
    </p>
    </div>
                </div>
                <!-- end: Row -->
            </div>
            <!-- end: Container -->
</fieldset>
<% } %>




    <script type="text/javascript">
        $(function() {
            var selectBox = $("select#VenueId").selectBoxIt({
                showEffect: "fadeIn",
                showEffectSpeed: 300,
                hideEffect: "fadeOut",
                hideEffectSpeed: 300
            });
            var selectBox = $("select#SportId").selectBoxIt({
                showEffect: "fadeIn",
                showEffectSpeed: 300,
                hideEffect: "fadeOut",
                hideEffectSpeed: 300
            });

            $("#Date").datepicker(
        { maxDate: "10/2/2013", minDate: "10/2/2012", gotoCurrent: true }
        );

            $("#Date").datepicker(
        { maxDate: "10/2/2013", minDate: "10/2/2012", gotoCurrent: true }
        );




            $("#longitude-" + "<%= Model.Id %>").on('change', function() {
                var longitude = $("#longitude-" + "<%= Model.Id %>").val();
                var latitude = $("#latitude-" + "<%= Model.Id %>").val();
                var longLatMessage = "Coordinates: " + longitude + "," + latitude;
                console.log(longLatMessage);
                $("#longitudeLatitudeVenue").text(longLatMessage);

            });
        });

    </script>