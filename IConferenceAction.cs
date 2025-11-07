using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduleM
{
    public interface IConferenceAction
    {
        void InsertData(); void SearchItem(string key); void DeleteItem(string key); void EditItem(string key);
        void DisplayAll();
    }
}

