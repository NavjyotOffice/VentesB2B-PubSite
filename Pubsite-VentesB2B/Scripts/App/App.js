var _URL = window.URL || window.webkitURL;
$("#ContentDetail_Upload").change(function (e) {
    lblFileSize.innerHTML = "";
    var file, img;
    if ((file = this.files[0])) {
        img = new Image();
        img.onload = function () {
            lblFileSize.innerHTML = '(' + this.width + "px * " + this.height + "px)";
        };
        img.src = _URL.createObjectURL(file);
    }
});

$("#ContentDetail_Upload").change(function () {
    var ext = $('#ContentDetail_Upload').val().split('.').pop().toLowerCase();
    if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
        alert('invalid extension!');
        $('#ContentDetail_Upload').val('');
    }
});