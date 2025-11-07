using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduleM
{
    public abstract class ConferenceItem
    {
        // Properties
        public string ID { get; set; } 
        public string Name { get; set; }

        // Abstract Method (Polymorphism) 
        public abstract void DisplayDetails();
    }
}

