@Imports System.Web.UI.WebControls
@ModelType DevExpressMvcApplication1.Models.ModelAppointment

@Code
    Html.EnableClientValidation()
    Html.EnableUnobtrusiveJavaScript()
End Code

@Using (Html.BeginForm())
    @<table cellpadding="0" cellspacing="0" style="width: 100%; height: 285px;">
        <tr>
            <td style="padding-right: 15px;">
                @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "Subject"
                        settings.Text = "Subject:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
            </td>
            <td colspan="3" style="width: 100%">
                @Html.DevExpress().TextBox(
                    Sub(settings)
                        settings.Name = "Subject"
                        settings.ShowModelErrors = True
                        settings.Properties.ValidationSettings.Display = Display.Dynamic
                        settings.Width = Unit.Percentage(100)
                    End Sub).Bind(Model.Subject).GetHtml()
            </td>
        </tr>
        <tr>
            <td style="padding-right: 15px;">
                @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "Location"
                        settings.Text = "Location:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
            </td>
            <td style="width: 50%">
                @Html.DevExpress().TextBox(
                    Sub(settings)
                        settings.Name = "Location"
                        settings.ShowModelErrors = True
                        settings.Properties.ValidationSettings.Display = Display.Dynamic
                        settings.Width = Unit.Percentage(100)
                    End Sub).Bind(Model.Location).GetHtml()
            </td>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding-left: 10px;">
                            @Html.DevExpress().CheckBox(
                                Sub(settings)
                                    settings.Name = "AllDay"
                                    settings.Width = Unit.Percentage(100)
                                End Sub).Bind(Model.AllDay).GetHtml()
                        </td>
                        <td>
                            @Html.DevExpress().Label(
                                Sub(settings)
                                    settings.AssociatedControlName = "AllDay"
                                    settings.Text = "All Day Event"
                                    settings.Width = Unit.Percentage(100)
                                End Sub).GetHtml()
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="white-space: nowrap; padding-right: 15px;">
                @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "StartTime"
                        settings.Text = "Start time:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
            </td>
            <td colspan="3">
                @Html.DevExpress().DateEdit(
                    Sub(settings)
                        settings.Name = "StartTime"
                        settings.Properties.EditFormat = EditFormat.DateTime
                        settings.ShowModelErrors = True
                        settings.Properties.ValidationSettings.Display = Display.Dynamic
                        settings.Width = Unit.Percentage(100)
                    End Sub).Bind(Model.StartTime).GetHtml()
            </td>
        </tr>
        <tr>
            <td style="white-space: nowrap; padding-right: 15px;">
                @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "EndTime"
                        settings.Text = "End time:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
            </td>
            <td colspan="3">
                @Html.DevExpress().DateEdit(
                    Sub(settings)
                        settings.Name = "EndTime"
                        settings.Properties.EditFormat = EditFormat.DateTime
                        settings.ShowModelErrors = True
                        settings.Properties.ValidationSettings.Display = Display.Dynamic
                        settings.Width = Unit.Percentage(100)
                    End Sub).Bind(Model.EndTime).GetHtml()
            </td>
        </tr>



        <tr>
            <td style="padding-right: 15px; white-space: nowrap;">
                @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "Status"
                        settings.Text = "Show Time As:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
            </td>
            <td style="width: 50%">
                @Html.DevExpress().ComboBox(
                    Sub(settings)
                        settings.Name = "Status"
                        settings.Properties.ValueType = GetType(Int32)
                        settings.Properties.ValueField = "Value"
                        settings.Properties.TextField = "Text"
                        settings.Width = Unit.Percentage(100)
                    End Sub).BindList(ViewBag.StatusDataSource).Bind(Model.Status).GetHtml()
            </td>
            <td style="padding-left: 10px; padding-right: 15px;">
                @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "Label"
                        settings.Text = "Label:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
            </td>
            <td style="width: 50%">
                @Html.DevExpress().ComboBox(
                    Sub(settings)
                        settings.Name = "Label"
                        settings.Properties.ValueType = GetType(Int32)
                        settings.Properties.ValueField = "Value"
                        settings.Properties.TextField = "Text"
                        settings.Width = Unit.Percentage(100)
                    End Sub).BindList(ViewBag.LabelDataSource).Bind(Model.Label).GetHtml()
            </td>
        </tr>
        @If Model.EventType = 0 OrElse Model.EventType = 1 Then
            @<tr>
                <td style="padding-right: 15px;">
                    @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "OwnerId"
                        settings.Text = "Resource:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
                </td>
                <td style="width: 50%">
                    @Html.DevExpress().ComboBox(
                    Sub(settings)
                        settings.Name = "OwnerId"
                        settings.Properties.ValueType = GetType(Int32)
                        settings.Properties.ValueField = "Value"
                        settings.Properties.TextField = "Text"
                        settings.Width = Unit.Percentage(100)
                    End Sub).BindList(ViewBag.ResourceDataSource).Bind(Model.OwnerId).GetHtml()
                </td>
            </tr>            
    End If
        <tr>
            <td style="padding-right: 15px;">
                @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "CustomInfo"
                        settings.Text = "Custom info:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
            </td>
            <td colspan="3" style="width: 100%">
                @Html.DevExpress().Memo(
                    Sub(settings)
                        settings.Name = "CustomInfo"
                        settings.Properties.Rows = 3
                        settings.ShowModelErrors = True
                        settings.Properties.ValidationSettings.Display = Display.Dynamic
                        settings.Width = Unit.Percentage(100)
                    End Sub).Bind(Model.CustomInfo).GetHtml()
            </td>
        </tr>
        <tr>
            <td colspan="4">
                @Html.DevExpress().Label(
                    Sub(settings)
                        settings.AssociatedControlName = "Description"
                        settings.Text = "Description:"
                        settings.Width = Unit.Percentage(100)
                    End Sub).GetHtml()
            </td>
        </tr>
        <tr>
            <td colspan="4">
                @Html.DevExpress().Memo(
                    Sub(settings)
                        settings.Name = "Description"
                        settings.Properties.Rows = 2
                        settings.ShowModelErrors = True
                        settings.Properties.ValidationSettings.Display = Display.Dynamic
                        settings.Width = Unit.Percentage(100)
                    End Sub).Bind(Model.Description).GetHtml()
            </td>
        </tr>
    </table>
    @<table cellpadding="0" cellspacing="0" style="width: 100%; height: 35px;">
        <tr>
            <td style="width: 100%; height: 100%;" align="center">
                <table style="height: 100%;">
                    <tr>
                        <td>
                            @Html.DevExpress().Button(
                                Sub(settings)
                                    settings.Name = "Apply"
                                    settings.Text = "Ok"
                                    settings.Width = Unit.Pixel(91)
                                    settings.ClientSideEvents.Click = "OnAppointmentFormSave"
                                End Sub).GetHtml()
                        </td>
                        <td>
                            @Html.DevExpress().Button(
                                Sub(settings)
                                    settings.Name = "Cancel"
                                    settings.Text = "Cancel"
                                    settings.ClientSideEvents.Click = "function(s, e) { scheduler.AppointmentFormCancel(); }"
                                    settings.Width = Unit.Pixel(91)
                                End Sub).GetHtml()
                        </td>
                        <td>
                            @Html.DevExpress().Button(
                                Sub(settings)
                                    settings.Name = "Delete"
                                    settings.Text = "Delete"
                                    settings.Width = Unit.Pixel(91)
                                    settings.Enabled = ViewBag.DeleteButtonEnabled
                                    settings.ClientSideEvents.Click = "function(s, e) { scheduler.AppointmentFormDelete(); }"
                                End Sub).GetHtml()
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    @<table cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="width: 100%;" align="left">
                @Html.DevExpress().SchedulerStatusInfo(
                    Sub(settings)
                        settings.Name = "schedulerStatusInfo"
                        settings.Priority = 1
                        settings.SchedulerName = "scheduler"
                    End Sub).GetHtml()
            </td>
        </tr>
    </table>
End Using
