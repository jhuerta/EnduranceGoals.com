(function() {
    var renderGoalListPage = function(page) {
        page = page || 3;
        var goalList = [];
        var pagination = [];
        $.ajax({
            url: "Goals/RaceList/" + page,
            success: function(data) {

                var indexPagination = {};

                indexPagination['Pages'] = data['Pages'];
                indexPagination['CurrentPage'] = data['CurrentPage'];
                indexPagination['Next'] = data['Next'];
                indexPagination['Prev'] = data['Prev'];
                pagination.push(indexPagination);
                console.log(pagination);

                var numberOfGoals = data['Goals'].length;
                for (var x = 0; x < numberOfGoals; x++) {
                    var goal = {};
                    goal["Id"] = data['Goals'][x].Id;
                    goal["Name"] = data['Goals'][x].Name;
                    goal["Date"] = data['Goals'][x].Date;
                    goal["Location"] = data['Goals'][x].Location;
                    goal["Participants"] = JSON.stringify(data['Goals'][x].Participants).split(',');
                    goal["Sport"] = data['Goals'][x].Sport.Name;
                    goal["IsParticipant"] = data['Goals'][x].IsParticipant;
                    goal["UserCanModifyEvent"] = data['Goals'][x].UserCanModifyEvent;
                    goal["GoalCanBeDeleted"] = data['Goals'][x].GoalCanBeDeleted;
                    goalList.push(goal);
                }

                $("#paginationIndex").empty();
                $('#GoalListJson').empty();

                $('#paginationTemplate').tmpl(pagination).appendTo("#paginationIndex");
                $('#goalListTemplate').tmpl(goalList).appendTo("#GoalListJson");
            }
        });
    };





    function toggleSubscription(id, from, to, style, newText) {
        $('#' + id).removeClass(from);
        $('#' + id).removeClass('btn-warning');
        $('#' + id).removeClass('btn-success');
        $('#' + id).addClass(to);
        $('#' + id).addClass(style);
        $('#' + id).addClass('newNewnew');
        $('#' + id).text(newText);
    }

    function toggleVisibilityDelete(id, users) {
        console.log(users.length);
        if (users.length === 0) {
            $('#delete-' + id).addClass('hidden');
            return;
        }
        $('#delete-' + id).removeClass('hidden');

    }
    function refreshDeleteBtn(id) {
        $.ajax({
            url: "EnduranceGoals/Goals/Participants/" + id,
            success: function(data) {
                toggleVisibilityDelete(id, data.ParticipantList);
            }
        });
    }

    function onUnsubscribeBtn(id) {
        $.ajax({
            url: "EnduranceGoals/Membership/Unsubscribe/" + id,
            success: (function() {
                toggleSubscription(id, 'unsubscribeBtn', 'subscribeBtn', 'btn-success', 'I want in!');
                refreshDeleteBtn(id);
            } ())
        });
    };

    function onSubscribeBtn(id) {
        $.ajax({
            url: "EnduranceGoals/Membership/Subscribe/" + id,
            success: (function() {
                toggleSubscription(id, 'subscribeBtn', 'unsubscribeBtn', 'btn-warning', 'I want out!');
                refreshDeleteBtn(id);
            } ())
        });
    };

    $('.subscribeBtn').live('click', function() { onSubscribeBtn(event.target.id); });
    $('.unsubscribeBtn').live('click', function() { onUnsubscribeBtn(event.target.id); });

    $('.onPage').live('click', function() { renderGoalListPage(event.target.id.split('-')[1]); });

    $('#AjaxGoals').click(function() { renderGoalListPage(1); });

    function printdata(goalList) {
        for (var x = 0; x < goalList.length; x++) {
            console.log("Data[" + x + "].id: " + goalList[x]["Id"]);
            console.log("Data[" + x + "].name: " + goalList[x]["Name"]);
            console.log("Data[" + x + "].date: " + goalList[x]["Date"]);
            console.log("Data[" + x + "].location: " + goalList[x]["Location"]);
            console.log("Data[" + x + "].participants: " + goalList[x]["Participants"]);
            console.log("Data[" + x + "].sport: " + goalList[x]["Sport"]);
        }
    }

    renderGoalListPage(1);


}
());


