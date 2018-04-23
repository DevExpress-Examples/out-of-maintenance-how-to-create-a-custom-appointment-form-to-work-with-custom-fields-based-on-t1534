@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<script type="text/javascript">
    function OnAppointmentFormSave(s, e) {
        if (IsValidAppointment())
            scheduler.AppointmentFormSave();
    }
    function IsValidAppointment() {
        $.validator.unobtrusive.parse('form');
        return $("form").valid();
    }
</script>

@ModelType DevExpressMvcApplication1.Models.SchedulerDataObject
@Html.Partial("SchedulerPartial", Model)


