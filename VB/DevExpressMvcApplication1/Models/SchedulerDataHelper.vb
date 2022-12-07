Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Linq
Imports DevExpressMvcApplication1
Imports DevExpress.Web.Mvc
Imports DevExpressMvcApplication1.Models
Imports System.Collections.Generic
Imports System.Drawing
Imports System
Imports System.Web
Imports System.Web.Mvc.Html
Imports DevExpress.XtraScheduler
Imports DevExpress.Web

Public Module SchedulerDataHelper
	Public Function GetResources() As List(Of CustomResource)
		Dim resources As New List(Of CustomResource)()
		resources.Add(CustomResource.CreateCustomResource(1, "Max Fowler", Color.Yellow.ToArgb()))
		resources.Add(CustomResource.CreateCustomResource(2, "Nancy Drewmore", Color.Green.ToArgb()))
		resources.Add(CustomResource.CreateCustomResource(3, "Pak Jang", Color.LightPink.ToArgb()))
		Return resources
	End Function

	Private myRand As New Random()
	Public Function GetAppointments(ByVal resources As List(Of CustomResource)) As List(Of CustomAppointment)
		Dim appointments As New List(Of CustomAppointment)()
		For Each item As CustomResource In resources
			Dim subjPrefix As String = item.Name & "'s "
			appointments.Add(CustomAppointment.CreateCustomAppointment(subjPrefix & "meeting", item.ResID, 2, 5, lastInsertedID))
			lastInsertedID += 1
			appointments.Add(CustomAppointment.CreateCustomAppointment(subjPrefix & "travel", item.ResID, 3, 6, lastInsertedID))
			lastInsertedID += 1
			appointments.Add(CustomAppointment.CreateCustomAppointment(subjPrefix & "phone call", item.ResID, 0, 10, lastInsertedID))
			lastInsertedID += 1
		Next item
		Return appointments
	End Function


	Public ReadOnly Property DataObject() As SchedulerDataObject
		Get
'INSTANT VB NOTE: The local variable dataObject was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
			Dim dataObject_Renamed As New SchedulerDataObject()


			If HttpContext.Current.Session("ResourcesList") Is Nothing Then
				HttpContext.Current.Session("ResourcesList") = GetResources()
			End If
			dataObject_Renamed.Resources = TryCast(HttpContext.Current.Session("ResourcesList"), List(Of CustomResource))

			If HttpContext.Current.Session("AppointmentsList") Is Nothing Then
				HttpContext.Current.Session("AppointmentsList") = GetAppointments(dataObject_Renamed.Resources)
			End If
			dataObject_Renamed.Appointments = TryCast(HttpContext.Current.Session("AppointmentsList"), List(Of CustomAppointment))
			Return dataObject_Renamed
		End Get
	End Property

	Private defaultAppointmentStorage_Renamed As MVCxAppointmentStorage
	Public ReadOnly Property DefaultAppointmentStorage() As MVCxAppointmentStorage
		Get
			If defaultAppointmentStorage_Renamed Is Nothing Then
				defaultAppointmentStorage_Renamed = CreateDefaultAppointmentStorage()
			End If
			Return defaultAppointmentStorage_Renamed

		End Get
	End Property

	Private Function CreateDefaultAppointmentStorage() As MVCxAppointmentStorage
		Dim appointmentStorage As New MVCxAppointmentStorage()
		appointmentStorage.AutoRetrieveId = True
		appointmentStorage.Mappings.AppointmentId = "ID"
		appointmentStorage.Mappings.Start = "StartTime"
		appointmentStorage.Mappings.End = "EndTime"
		appointmentStorage.Mappings.Subject = "Subject"
		appointmentStorage.Mappings.AllDay = "AllDay"
		appointmentStorage.Mappings.Description = "Description"
		appointmentStorage.Mappings.Label = "Label"
		appointmentStorage.Mappings.Location = "Location"
		appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo"
		appointmentStorage.Mappings.ReminderInfo = "ReminderInfo"
		appointmentStorage.Mappings.ResourceId = "OwnerId"
		appointmentStorage.Mappings.Status = "Status"
		appointmentStorage.Mappings.Type = "EventType"

		appointmentStorage.CustomFieldMappings.Add(New DevExpress.Web.ASPxScheduler.ASPxAppointmentCustomFieldMapping("AppointmentCustomField", "CustomInfo"))
		Return appointmentStorage
	End Function

	Private defaultResourceStorage_Renamed As MVCxResourceStorage
	Public ReadOnly Property DefaultResourceStorage() As MVCxResourceStorage
		Get
			If defaultResourceStorage_Renamed Is Nothing Then
				defaultResourceStorage_Renamed = CreateDefaultResourceStorage()
			End If
			Return defaultResourceStorage_Renamed

		End Get
	End Property

	Private Function CreateDefaultResourceStorage() As MVCxResourceStorage
		Dim resourceStorage As New MVCxResourceStorage()
		resourceStorage.Mappings.ResourceId = "ResID"
		resourceStorage.Mappings.Caption = "Name"
		resourceStorage.Mappings.Color = "Color"
		Return resourceStorage
	End Function

	Public Function GetSchedulerSettings() As SchedulerSettings
		Return GetSchedulerSettings(Nothing)
	End Function

	<System.Runtime.CompilerServices.Extension> _
	Public Function GetSchedulerSettings(ByVal customHtml As System.Web.Mvc.HtmlHelper) As SchedulerSettings
		Dim settings As New SchedulerSettings()
		settings.Name = "scheduler"
		settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "SchedulerPartial"}
		settings.EditAppointmentRouteValues = New With {Key .Controller = "Home", Key .Action = "EditAppointment"}
		settings.CustomActionRouteValues = New With {Key .Controller = "Home", Key .Action = "CustomCallBackAction"}

		settings.Storage.Appointments.Assign(SchedulerDataHelper.DefaultAppointmentStorage)
		settings.Storage.Resources.Assign(SchedulerDataHelper.DefaultResourceStorage)

		settings.Storage.EnableReminders = False
		settings.GroupType = SchedulerGroupType.Resource
		settings.Views.DayView.Styles.ScrollAreaHeight = 400
		settings.Start = DateTime.Now

		settings.AppointmentFormShowing = Function(sender, e) AnonymousMethod1(sender, e)

			'ViewBag.ReminderDataSource = container.ReminderDataSource;
        settings.OptionsForms.SetAppointmentFormTemplateContent(Function(c) AnonymousMethod2(c, customHtml))
		Return settings
	End Function
	
	Private Function AnonymousMethod1(ByVal sender As Object, ByVal e As Object) As Boolean
		Dim scheduler = TryCast(sender, MVCxScheduler)
		If scheduler IsNot Nothing Then
			e.Container = New CustomAppointmentTemplateContainer(scheduler)
		End If
		Return True
	End Function
	
    Private Function AnonymousMethod2(ByVal c As Object, ByVal customHtml As System.Web.Mvc.HtmlHelper) As Boolean
        Dim container = CType(c, CustomAppointmentTemplateContainer)
        Dim modelAppointment As New ModelAppointment() With {.ID = If(container.Appointment.Id Is Nothing, -1, CInt(Fix(container.Appointment.Id))), .Subject = container.Appointment.Subject, .Location = container.Appointment.Location, .StartTime = container.Appointment.Start, .EndTime = container.Appointment.End, .AllDay = container.Appointment.AllDay, .Description = container.Appointment.Description, .EventType = CInt(Fix(container.Appointment.Type)), .Status = container.Appointment.StatusId, .Label = container.Appointment.LabelId, .CustomInfo = container.CustomInfo, .OwnerId = Convert.ToInt32(container.Appointment.ResourceId)}
        customHtml.ViewBag.DeleteButtonEnabled = container.CanDeleteAppointment
        TryCast(container.ResourceDataSource, ListEditItemCollection).RemoveAt(0)
        customHtml.ViewBag.ResourceDataSource = container.ResourceDataSource
        customHtml.ViewBag.StatusDataSource = container.StatusDataSource
        customHtml.ViewBag.LabelDataSource = container.LabelDataSource
        customHtml.RenderPartial("CustomAppointmentFormPartial", modelAppointment)
        Return True
    End Function

	Private lastInsertedID As Integer = 0

	' CRUD operations implementation
	Public Sub InsertAppointments(ByVal appts() As CustomAppointment)
		If appts.Length = 0 Then
			Return
		End If

		Dim appointmnets As List(Of CustomAppointment) = TryCast(HttpContext.Current.Session("AppointmentsList"), List(Of CustomAppointment))
		For i As Integer = 0 To appts.Length - 1
			If appts(i) IsNot Nothing Then
				appts(i).ID = lastInsertedID
				lastInsertedID += 1
				appointmnets.Add(appts(i))
			End If
		Next i
	End Sub

	Public Sub UpdateAppointments(ByVal appts() As CustomAppointment)
		If appts.Length = 0 Then
			Return
		End If

		Dim appointmnets As List(Of CustomAppointment) = TryCast(System.Web.HttpContext.Current.Session("AppointmentsList"), List(Of CustomAppointment))
        For i As Integer = 0 To appts.Length - 1
            Dim currentIndex As Integer = i
            Dim sourceObject As CustomAppointment = appointmnets.First(Function(apt) apt.ID = appts(currentIndex).ID)
            appts(i).ID = sourceObject.ID
            appointmnets.Remove(sourceObject)
            appointmnets.Add(appts(i))
        Next i
	End Sub

	Public Sub RemoveAppointments(ByVal appts() As CustomAppointment)
		If appts.Length = 0 Then
			Return
		End If

		Dim appointmnets As List(Of CustomAppointment) = TryCast(HttpContext.Current.Session("AppointmentsList"), List(Of CustomAppointment))
		For i As Integer = 0 To appts.Length - 1
            Dim currentIndex As Integer = i
            Dim sourceObject As CustomAppointment = appointmnets.First(Function(apt) apt.ID = appts(currentIndex).ID)
            appointmnets.Remove(sourceObject)
		Next i
	End Sub
End Module