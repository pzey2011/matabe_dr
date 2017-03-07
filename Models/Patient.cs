using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayView.Models
{
    public class Patient
    {
        private String name;
        private String phone_number;
        public Appointment[] appointments;
        public Patient(String init_name, String init_phone_number)
        {
            phone_number = init_phone_number;
            name = init_name;
        }
        public String get_name()
        {
            return name;
        }
        public String get_phone_number()
        {
            return phone_number;

        }

    }
}
