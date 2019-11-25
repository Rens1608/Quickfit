$(function() {
    $("#addExercise").click(function() {
        $.ajax({
            type: "POST",
            url: 'Workout/Exercises',
            data: form.serialize()
        })
            .success(function(html) {
                var tableBody = $("#tblContactBody");
                tableBody.text(html);
            })
            .error(function(msg) {
                console.log(msg);
            });
    });
});