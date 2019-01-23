(function () {
    $('#sidebarCollapse').on('click', function () {
        $(this).toggleClass('active');
        $('#sidebar').toggleClass('active');
        $(".toggle").toggleClass("show hide");
    });
})();