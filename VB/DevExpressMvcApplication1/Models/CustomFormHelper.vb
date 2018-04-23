Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.Mvc

Namespace DevExpressMvcApplication1.Models
	Public Class ModelAppointment
		Public Sub New()
		End Sub

		Private privateStartTime As DateTime
		<Required> _
		Public Property StartTime() As DateTime
			Get
				Return privateStartTime
			End Get
			Set(ByVal value As DateTime)
				privateStartTime = value
			End Set
		End Property

		Private privateEndTime As DateTime
		<Required> _
		Public Property EndTime() As DateTime
			Get
				Return privateEndTime
			End Get
			Set(ByVal value As DateTime)
				privateEndTime = value
			End Set
		End Property

		Private privateSubject As String
		<Required> _
		Public Property Subject() As String
			Get
				Return privateSubject
			End Get
			Set(ByVal value As String)
				privateSubject = value
			End Set
		End Property

		Private privateStatus As Integer
		Public Property Status() As Integer
			Get
				Return privateStatus
			End Get
			Set(ByVal value As Integer)
				privateStatus = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
		Private privateLabel As Integer
		Public Property Label() As Integer
			Get
				Return privateLabel
			End Get
			Set(ByVal value As Integer)
				privateLabel = value
			End Set
		End Property
		Private privateLocation As String
		Public Property Location() As String
			Get
				Return privateLocation
			End Get
			Set(ByVal value As String)
				privateLocation = value
			End Set
		End Property
		Private privateAllDay As Boolean
		Public Property AllDay() As Boolean
			Get
				Return privateAllDay
			End Get
			Set(ByVal value As Boolean)
				privateAllDay = value
			End Set
		End Property
		Private privateEventType As Integer
		Public Property EventType() As Integer
			Get
				Return privateEventType
			End Get
			Set(ByVal value As Integer)
				privateEventType = value
			End Set
		End Property
		Private privateRecurrenceInfo As String
		Public Property RecurrenceInfo() As String
			Get
				Return privateRecurrenceInfo
			End Get
			Set(ByVal value As String)
				privateRecurrenceInfo = value
			End Set
		End Property
		Private privateReminderInfo As String
		Public Property ReminderInfo() As String
			Get
				Return privateReminderInfo
			End Get
			Set(ByVal value As String)
				privateReminderInfo = value
			End Set
		End Property

		Private privateOwnerId As Integer
		<Required, Display(Name := "Resource")> _
		Public Property OwnerId() As Integer
			Get
				Return privateOwnerId
			End Get
			Set(ByVal value As Integer)
				privateOwnerId = value
			End Set
		End Property
		Private privateCustomInfo As String
		Public Property CustomInfo() As String
			Get
				Return privateCustomInfo
			End Get
			Set(ByVal value As String)
				privateCustomInfo = value
			End Set
		End Property
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property

		Public Sub New(ByVal source As CustomAppointment)
			If source IsNot Nothing Then
				StartTime = source.StartTime
				EndTime = source.EndTime
				Subject = source.Subject
				Status = source.Status
				Description = source.Description
				Label = source.Label
				Location = source.Location
				AllDay = source.AllDay
				EventType = source.EventType
				RecurrenceInfo = source.RecurrenceInfo
				ReminderInfo = source.ReminderInfo
				OwnerId = source.OwnerId
				CustomInfo = source.CustomInfo
				ID = source.ID
			End If

		End Sub
	End Class

	Public Class CustomAppointmentTemplateContainer
		Inherits AppointmentFormTemplateContainer
		Public Sub New(ByVal scheduler As MVCxScheduler)
			MyBase.New(scheduler)
		End Sub

		Public ReadOnly Property CustomInfo() As String
			Get
				Return If(Appointment.CustomFields("AppointmentCustomField") IsNot Nothing, Appointment.CustomFields("AppointmentCustomField").ToString(), "")
			End Get
		End Property
	End Class
End Namespace