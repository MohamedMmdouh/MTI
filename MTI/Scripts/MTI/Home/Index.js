document.addEventListener("DOMContentLoaded", (event) => {

    var selectCarousel = $('#carousel-1');
    var selectInner = selectCarousel.find('.carousel-inner');
    selectInner.children('.item').remove();
    selectInner.append('<div class="item active"><img  style="width:100%;height:650px;" src="../Content/Image/1 (2).PNG" alt=""></div>');
    selectInner.append('<div class="item"><img style="width:100%;height:650px;" src="../Content/Image/DSC_0005 (2).jpg" alt=""></div>');
    selectInner.append('<div class="item"><img style="width:100%;height:650px;" src="../Content/Image/DSC_0080 (2).jpg" alt=""></div>');
    selectInner.append('<div class="item"><img style="width:100%;height:650px;" src="../Content/Image/3.jpg" alt=""></div>');
    selectInner.append('<div class="item"><img style="width:100%;height:650px;" src="../Content/Image/3 (2).jpg" alt=""></div>');
    selectInner.append('<div class="item"><img style="width:100%;height:650px;" src="../Content/Image/IMG_4816.JPG" alt=""></div>');

}, false)
