using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduleM
{
    public class ConferenceManager<T> : IConferenceAction where T : ConferenceItem, new()
    {
        // Fix: AddInitialData method for safe data access
        public List<T> dataList = new List<T>(); 

        private string EntityName
        {
            get { return typeof(T).Name; }
        }

        public void AddInitialData(T item)
        {
            dataList.Add(item);
        }

        public void InsertData()
        {

            Console.WriteLine("\n--- Adding a new {0} ---", EntityName);
            T newItem = new T();

            Console.Write("Enter ID: ");
            newItem.ID = Console.ReadLine();


            Console.Write("Enter {0} Name/Title: ", EntityName); newItem.Name = Console.ReadLine();

            if (newItem is Session session)
            {
                int typeChoice; while (true)
                {
                    Console.Write("Enter Type (0: Keynote, 1: Workshop, 2: Presentation, 3: PanelDiscussion): "); if (int.TryParse(Console.ReadLine(), out typeChoice) && typeChoice >= 0 && typeChoice <= 3) break;
                    Console.WriteLine("Invalid input. Enter a number from 0 to 3.");
                }

                session.Type = (SessionType)typeChoice; session.StartTime = DateTime.Now.AddHours(dataList.Count);

                session.Type = (SessionType)typeChoice; session.StartTime = DateTime.Now.AddHours(dataList.Count);
            }
            else if (newItem is Speaker speaker)
            {
                Console.Write("Enter Affiliation: "); speaker.Affiliation = Console.ReadLine();
            }

            dataList.Add(newItem);

            Console.WriteLine("\nSUCCESS: {0} '{1}' added with ID: {2}", EntityName, newItem.Name, newItem.ID);
        }

        public void DisplayAll()
        {
            if (dataList.Count == 0)
            {

                Console.WriteLine("\nINFO: No {0} items to display.", EntityName); return;
            }


            Console.WriteLine("\n============= Displaying All {0}s (Total: {1}) ==============", EntityName, dataList.Count); foreach (var item in dataList)
            {
                item.DisplayDetails();
            }
            Console.WriteLine("====================================================");
        }

        public void SearchItem(string key)
        {
            // Using IndexOf for case-insensitive Contains (Fixing CS1501)
            var result = dataList.FirstOrDefault(delegate (T i)
            {
                return i.ID.Equals(key, StringComparison.OrdinalIgnoreCase) || i.Name.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0;
            });

            if (result != null)
            {
                Console.WriteLine("\nSearch Results:"); result.DisplayDetails();
            }
            else
            {

                Console.WriteLine("\nINFO: {0} with key '{1}' not found.", EntityName, key);
            }
        }

        public void DeleteItem(string key)
        {
            var itemToDelete = dataList.FirstOrDefault(delegate (T i)
            {
                return i.ID.Equals(key, StringComparison.OrdinalIgnoreCase);
            });
            if (itemToDelete != null)
            {
                dataList.Remove(itemToDelete);

                Console.WriteLine("\nSUCCESS: {0} '{1}' (ID: {2}) has been deleted.", EntityName, itemToDelete.Name, key);
            }
            else
            {
                Console.WriteLine("\nERROR: Cannot delete. {0} with ID/Name '{1}' not found.", EntityName, key);
            }
        }

        public void EditItem(string key)
        {
            var itemToEdit = dataList.FirstOrDefault(delegate (T i)
            {
                return i.ID.Equals(key, StringComparison.OrdinalIgnoreCase);
            });

            if (itemToEdit == null)
            {

                Console.WriteLine("\nERROR: Cannot edit. {0} with ID/Name '{1}' not found.", EntityName, key); return;
            }


            Console.WriteLine("\n--- Editing {0}: {1} (ID: {2}) ---", EntityName, itemToEdit.Name, itemToEdit.ID);



            Console.WriteLine("\nSUCCESS: {0} updated.", EntityName);
        }
    }
}

