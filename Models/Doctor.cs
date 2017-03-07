using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayView.Models
{
   public class Doctor
    {
       public String firstName{get; set;}
       public String lastName{get; set;}
       public String proficiency{get; set;}



       public Doctor(String f, String l, String p)
       {
           lastName = l;
           firstName = f;
           proficiency = p;
        }
     


    }
}
