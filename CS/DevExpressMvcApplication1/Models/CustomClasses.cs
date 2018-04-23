using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevExpressMvcApplication1.Models {
    #region #customappointment
    public class CustomAppointment {
        private DateTime m_Start;
        private DateTime m_End;
        private string m_Subject;
        private int m_Status;
        private string m_Description;
        private int m_Label;
        private string m_Location;
        private bool m_Allday;
        private int m_EventType;
        private string m_RecurrenceInfo;
        private string m_ReminderInfo;
        private int m_OwnerId;
        private int m_Id;

        private string m_CustomInfo;


        public DateTime StartTime { get { return m_Start; } set { m_Start = value; } }
        public DateTime EndTime { get { return m_End; } set { m_End = value; } }
        public string Subject { get { return m_Subject; } set { m_Subject = value; } }
        public int Status { get { return m_Status; } set { m_Status = value; } }
        public string Description { get { return m_Description; } set { m_Description = value; } }
        public int Label { get { return m_Label; } set { m_Label = value; } }
        public string Location { get { return m_Location; } set { m_Location = value; } }
        public bool AllDay { get { return m_Allday; } set { m_Allday = value; } }
        public int EventType { get { return m_EventType; } set { m_EventType = value; } }
        public string RecurrenceInfo { get { return m_RecurrenceInfo; } set { m_RecurrenceInfo = value; } }
        public string ReminderInfo { get { return m_ReminderInfo; } set { m_ReminderInfo = value; } }
        public int OwnerId { get { return m_OwnerId; } set { m_OwnerId = value; } }
        public int ID { get { return m_Id; } set { m_Id = value; } }

        public string CustomInfo { get { return m_CustomInfo; } set { m_CustomInfo = value; } }

        public CustomAppointment() {
        }

        public static CustomAppointment CreateCustomAppointment(string subject, object resourceId, int status, int label, int id) {
            CustomAppointment apt = new CustomAppointment();
            apt.ID = id;
            apt.Subject = subject;
            apt.OwnerId = Convert.ToInt32(resourceId);
            apt.StartTime = DateTime.Now.AddHours(id);
            apt.EndTime = apt.StartTime.AddHours(3);
            apt.Status = status;
            apt.Label = label;
            return apt;
        }
    }
    #endregion  #customappointment

    #region #customresource
    public class CustomResource {
        private string m_name;
        private int m_res_id;
        private int m_res_color;

        public string Name { get { return m_name; } set { m_name = value; } }
        public int ResID { get { return m_res_id; } set { m_res_id = value; } }
        public int Color { get { return m_res_color; } set { m_res_color = value; } }

        public CustomResource() {

        }

        public static CustomResource CreateCustomResource(int res_id, string caption, int ResColor) {
            CustomResource cr = new CustomResource();
            cr.ResID = res_id;
            cr.Name = caption;
            cr.Color = ResColor;
            return cr;
        }    

    }
    #endregion #customresource

    public class SchedulerDataObject {
        public List<CustomAppointment> Appointments { get; set; }
        public List<CustomResource> Resources { get; set; }
    }
}