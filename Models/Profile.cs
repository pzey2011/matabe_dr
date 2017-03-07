using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayView.Models
{
    class Profile
    {
        public Patient patient;
        private String history { get; set; }
        private String allergy { get; set; }
        private int age { get; set; }
        public Visit[] visits;
    }
}
