function InicializarCalendarios() {

    $("[id*=txtFecha]").datetimepicker({ format: 'd/m/Y', lang: 'es', timepicker: false });
}
$(document).ready(function () {

    InicializarCalendarios();

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {

        InicializarCalendarios();

    });

});