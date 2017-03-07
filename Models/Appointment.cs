using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayView.Models
{
    public class Appointment 
    {
        public Patient patient;
        DateTime appointmentDate{set; get;}
        public Appointment(Patient p, DateTime dt)
        {
            patient = p;
            appointmentDate = dt;
        }
        public Appointment() { }
    }
}
