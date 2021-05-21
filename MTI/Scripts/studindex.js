
$(document).ready(function () {
    $("#students").DataTable({
        style: {
            "float": "right"
        },
        "language": {
            "url": "/Content/DataTables/language/arabic.json"
        },
        ajax: {
            url: "/api/Student/getstudents",
            dataSrc: ""
        },

        columns: [

            {
                data: "StudentNumber"
            },
            {
                data: "Name"
            },
            {
                data: "batch.batchNo"
            },
            {
                data: "Section.Level"
            },
            {
                data: "specialization.specialty"
            },
            {
                data: "Religion"
            },
            {
                data: "Nationality"
            },
            {
                data: "SSN"
            },
            {
                data: "Mobile"
            },
            {
                data: "Blood_Type"
            },
            {
                data: "BirthDate",
                "searchable": false,
                render: function (data) {
                    var m = new Date(data).getMonth();
                    return (parseInt(m) + 1) + "-" + new Date(data).getDate() + "- " + new Date(data).getFullYear();
                }
            },
            {
                data: "Address"
            },
            {
                data: "Image",
                render: function (data) {
                    return "<img  width=" + 40 + " height=" + 40 + " src=" + data + " />";
                }
            },

            {
                data: "ID",  //Get value from RoleId column, I assumed you used "RoleId" as the name for RoleId in your JSON, in my case, I didn't assigned any name in code behind so i used "mData": "0"
                style: "btn btn-primary",
                "mRender": function (data, type, Students) {
                    return " <a class=" + "buttonprimary" + " href='/students/Edit/" + data + "'>تعديل </a> "
                }
            }, {
                data: {
                    Name: "Name",
                    ID: "ID"

                },
                render: function (data, mdata) {
                    return "<button  class='btn btn-danger Jsdelete' id=" + "Jsdelete" + " data-studID=" + data.ID + " " + "data-name=" + data.Name + ">حذف</button>"
                }
            },
            {
                data: "ID",  //Get value from RoleId column, I assumed you used "RoleId" as the name for RoleId in your JSON, in my case, I didn't assigned any name in code behind so i used "mData": "0"
                "mRender": function (data, type, student) {
                    return "<a class=" + "buttoninfo" + " href='/students/ViewStudent/" + data + "'>عرض الملف </a> "
                }
            }
        ]
    });
});
$("#students").on("click", ".Jsdelete", function () {
    var button = $(this);
    bootbox.confirm({
        message: "سيتم حذف بيانات الطالب " + $(this).attr("data-name"),
        buttons: {
            confirm: {
                label: 'تأكيد',
                className: 'btn-success',
            },
            cancel: {
                label: 'ألغاء',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: "/api/Student/DeleteStudent/" + button.attr("data-studID"),
                    method: "post"
                })
                button.parents("tr").remove();
            }
            else {
                return;
            }
        }
    });


});
$(document).ready(function () {
    var table = $('#students').DataTable();

    $('#level').on('change', function () {
        var x = this.value;
        if (x == "الكل") {
            x = "";
        }
        table.search(x).draw();
    });

});

$(document).ready(function () {
    var table = $('#students').DataTable();

    $('#students tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });


    $('#button').click(function () {
        var myids = new Array();
        myids = [];
        var data = table.rows('.selected').data();
        for (var c = 0; c < data.length; c++) {
            myids.push(data[c].ID);
        }
        if (data.length == 0) {
            $('#Button').href = "#";
        }
        else {
            var postData = { values: myids };
            if (postData == 0) {
                return;
            } else {
                $.ajax({
                    type: "POST",
                    url: "/punshiment/Resivedata",
                    data: postData,
                    success: function (data) {
                        window.location.href = "/punshiment/Addpunshiments";
                    },
                    dataType: "json",
                    traditional: true
                });
            }
        }


    });
});

$(document).ready(function () {

    $('#students tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });

    $('#AddReward').click(function () {
        var myids = new Array();
        myids = [];
        var data2 = table.rows('.selected').data();
        for (var c = 0; c < data2.length; c++) {
            myids.push(data[c].ID);
        }
        if (data.length == 0) {
            $('#AddReward').href = "#";
        }
        else {
            postData = { values: myids };
            if (postData == 0) {
                $('#AddReward').href = "#";
            } else {
                $.ajax({
                    type: "POST",
                    url: "/Reward/Resivedata",
                    data: postData,
                    success: function (data) {
                        window.location.href = "/Reward/AddRewards";
                    },
                    dataType: "json",
                    traditional: true
                });
            }
        }


    });
});



$(document).ready(function () {
    $('#students tbody').on('click', 'tr', function () {
        var table = $('#students').DataTable();
        if (table.rows('.selected').any()) {
            $('#AddReward').removeClass('disabled');
            $('#button').removeClass('disabled');
        }
        else {
            $('#AddReward').addClass('disabled');
            $('#button').addClass('disabled');
        }
    });
});
