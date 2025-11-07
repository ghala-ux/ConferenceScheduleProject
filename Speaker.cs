using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduleM
{
    public class Speaker : ConferenceItem
    {
        // Speaker Specific Properties
         public string Affiliation { get; set; }
         public string Biography { get; set; } 
        public override void DisplayDetails()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("[SPEAKER] ID: {0} | Name: {1}", ID, Name);
            Console.WriteLine("  - Affiliation: {0}", Affiliation);
            Console.WriteLine("-----------------------------------------");
        }
    }
}

