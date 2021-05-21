document.addEventListener("DOMContentLoaded", (event) => {

    document.getElementsByTagName("BODY")[0].onload = (event) => {
        myVar = setTimeout(showPage, 500)
    }
    
}, false)


$(function () {
    $.ajax({
        type: "get",
        url: "/api/newsApi/GetNews",
        success(data) {
            for (var news = 0; news < data.length; news++)
                $("#newslist").append('<li>' + data[news].Details + '(' + data[news].category + ')' + '<img  style="width:15px ;height:15px;" src="../Content/Image/logo color203936240.ico" alt=""></li > ');
            marquee();
        },
        error(data) {
            for (var ss = 0; ss < 4; ss++)
                $("#newslist").append('<li> حدث خطأ اثناء استدعاء البيانات</li >');
            marquee();

        }
    });
});

function marquee() {
    $(".marquee").marquee({
        duration: 10000,
        //gap in pixels between the tickers
        gap: 5,
        startVisible: true,
        // On cycle pause the marquee
        pauseOnCycle: 1000,                //time in milliseconds before the marquee will start animating
        delayBeforeStart: 0,
        //'left' or 'right'
        direction: 'right',
        pauseOnHover: true,
        //true or false - should the marquee be duplicated to show an effect of continues flow
    });
}

var myVar;

function showPage() {
    document.getElementById("loader").style.display = "none";
    document.getElementById("myDiv").style.display = "block";
}