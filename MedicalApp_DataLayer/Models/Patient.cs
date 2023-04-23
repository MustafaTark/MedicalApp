using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class Patient :User
    {
        public Patient()
        {
            Reports = new List<Report>();
            Orders= new List<Order>();
            Appointments = new List<Appointment>();
            Chats = new List<Chat>();
            Rates = new List<Rate>();
            PatientMessages = new List<PatientMessage>();
        }
        [Required(ErrorMessage ="First Name is Required Field")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "First Name is Required Field")]
        public string? LastName { get; set; }
        public byte? Age { get; set; }
        public ICollection<Report>? Reports { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<PatientMessage> PatientMessages { get; set; }
    }
}
