$(document).ready(function () {
    $('#loading').hide();
    debugger;
    var currentURL = (document.URL); // returns http://myplace.com/abcd
    var getpart = currentURL.split("/")[1];
    if (window.location.href == "http://localhost:56138/") {
        GetAllCoursesAuto();
    }
    $('#EnrollInCourse').on('click', function () {
        debugger;
        EnrollInCourse();
        $(this).hide();
    });
});

function GetAllCoursesAuto() {
    var UserIdsList = [];
    $.ajax({
        url: 'GetAllCoursesAuto',
        type: "GET",
        data: JSON.stringify(UserIdsList),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger;
            UserIdsList.push(response);
            console.log(UserIdsList);
            $("#SearchCourses").autocomplete({
                source: response
            });
        },
        error: function (errormessage) {
            console.log(errormessage);
            toastr.error("Error");
        }
    });

}
function EnrollInCourse() {
    debugger;
    var postobj = {
        StudentId: $("#CurrentCourseId").val(),
        CourseId: $("#CurrentUserId").val()
    };
    $.ajax({
        url: '@Url.Action("EnrollInCourse","Course")',
        data: JSON.stringify(postobj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            debugger;
            toastr.success("Enrolled Succesfully");
        },
        error: function (errormessage) {
            console.log(errormessage);
            toastr.error("Error");
        }
    });
}