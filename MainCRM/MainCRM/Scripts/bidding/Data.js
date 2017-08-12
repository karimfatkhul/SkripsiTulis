
$(function () {
    var menuItem = $('#left-sidebar-menu-bid');
    menuItem.addClass('active');
    var subMenuItem = menuItem.find('#left-sidebar-menu-bid-data');
    subMenuItem.addClass('active');
})
$(function () {
    $('#datetimepicker2').datetimepicker({
        locale: 'id',
        format: 'MM/DD/YYYY HH:mm:ss'
    });
});
$(function () {
    $('#datetimepicker3').datetimepicker({
        locale: 'id',
        format: 'MM/DD/YYYY HH:mm:ss'
    });
});
