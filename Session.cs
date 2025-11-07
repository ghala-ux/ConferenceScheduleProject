using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduleM
{
    public class Session : ConferenceItem
    {
        // Session Specific Properties
        public DateTime StartTime { get; set; }
        public SessionType Type { get; set; } // Uses Enum 

        // Implementation of the abstract method (Polymorphism)
        public override void DisplayDetails()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("[SESSION] ID: {0} | Title: {1}", ID, Name);
            Console.WriteLine("  - Time: {0}", StartTime.ToShortTimeString());
            Console.WriteLine("  - Type: {0}", Type);
            Console.WriteLine("-----------------------------------------");
        }
    }
}
