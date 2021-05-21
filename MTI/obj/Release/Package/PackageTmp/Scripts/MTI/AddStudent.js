const url = '/Helpers/Json/json.json';

$(document).ready(function () {
    $("#studentnum").keyup(function () {
        var id = $("#studentnum").val();
        if (id.length == 5) {
            $("#spinner").removeClass("hidden");
            $.ajax({
                url: "/api/Student/studentnmberexist/" + id,
                method: "post", type: "POST",
                success: function (data) {
                    var button = document.getElementById(".submit");

                    if (data.Name != null) {
                        setTimeout(function () {
                            $("#Error #data").text("ينتمي الرقم للطالب " + data.Name);
                            $("#Error #data").css('color', 'red');
                            $("#studentnum").css('border-color', 'red');
                            $("#spinner").addClass("hidden");

                        }, 2000);
                           
                       
                    }


                }, error: function (error) {
                    setTimeout(function () {
                        $("#Error #data").css('color', 'green');
                        $("#Error #data").css('font', 'bold');
                        $("#studentnum").css('border-color', 'green');
                        $("#spinner").addClass("hidden");
                    }, 2000);

                      
                    
                },

            });
        }
        else {
            setTimeout(function () {
                $("#spinner").addClass("hidden");

                $("#Error #data").text("");
                $("#studentnum").css('border-color', '');
                $("#spinner").removeClass("hidden");

            }, 2000);

             
        }
    });
});


function City() {
    let dropdown = $("#citylist");
    var x = document.getElementById("citydata").value;
    if (x == "") {
        dropdown.append('<option selected="true" disabled>اختر المحافظة</option>');
        $.getJSON(url, function (data) {
            $.each(data, function (key, entry) {
                if (entry.parentID == 0)
                    dropdown.append($('<option></option>').attr({ 'value': entry.Name, 'ID': entry.ID }).text(entry.Name));
            });
        });
    }
    else {
        dropdown.append('<option selected="true" disabled>اختر المحافظة</option>');
        const url = '/Helpers/Json/json.json';
        $.getJSON(url, function (data) {
            $.each(data, function (key, entry) {
                if (entry.parentID == 0)
                    dropdown.append($('<option></option>').attr({ 'value': entry.Name, 'ID': entry.ID }).text(entry.Name));
            });
            dropdown.val(x);
            post();
        });
    }
}
function post() {
    var x = document.getElementById("postdata").value;
    let citydata = $("#citylist option:selected");
    $("#postlist").append('<option selected="true" disabled>اختر المركز</option>');
    $.getJSON(url, function (data) {
        $.each(data, function (key, entry) {
            if (entry.parentID == citydata.attr('ID'))
                $("#postlist").append($('<option></option>').attr({ 'value': entry.Name, 'ID': entry.ID }).text(entry.Name));
        });
        $("#postlist").val(x);
    });
}

$("#citylist").change(function update() {
    $("#postlist").empty();
    $("#postlist").append('<option selected="true" disabled>اختر المركز</option>');
    let citydata = $("#citylist option:selected");
    $("#postlist").prop('selectedIndex', 0);
    const url = '/Helpers/Json/json.json';
    $.getJSON(url, function (data) {
        $.each(data, function (key, entry) {
            if (entry.parentID == citydata.attr('ID'))
                $("#postlist").append($('<option></option>').attr({ 'value': entry.Name, 'ID': entry.ID }).text(entry.Name));
        });
    });
});


$(document).ready(function () {
    City();
});
var date = new Date();
$(function () {
    $("#datepicker").datepicker({
        format: 'DD-MM-YYYY HH:mm:ss',
    });
    $("#anim").on("change", function () {
        $("#datepicker").datepicker("option", "showAnim", $(this).val());
    });
});

$(function () {
    $("#datepicker1").datepicker({
        format: 'MM-DD-YYYY HH:mm:ss'
    });
    $("#anim").on("change", function () {
        $("#datepicker1").datepicker({ showAnim: 'slideDown' });

    });

}); $(function () {
    $("#datepicker2").datepicker({
        format: 'MM-DD-YYYY HH:mm:ss'
    });
    $("#anim").on("change", function () {
        $("#datepicker2").datepicker("option", "showAnim", $(this).val());
    });
});
