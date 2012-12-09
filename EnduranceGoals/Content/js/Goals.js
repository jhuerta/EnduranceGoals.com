(function() {
    var onClickAjaxGoals = function() {

        console.log("ajax called");

        $.ajax({
            url: "EnduranceGoals/Goals/RaceList",
            success: function(data) {
                console.log(data);
            },
            error: function(data) {
                console.log(data);
            },
            complete: function(data) {
                console.log(data);
            }
        });
    };

    $('#AjaxGoals').click(function() { onClickAjaxGoals(); });
}
());
