using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book Data LINQ ");

            // UC 1 Create a new table
            AddressBookTable addressBookTable = new AddressBookTable();

            //addressBookTable.GetAllContacts();//UC3

            //addressBookTable.EditExistingContact("Omprakash", "Khawshi", "PhoneNumber", "9921670015"); //UC4


            addressBookTable.DeleteContact("Omprakash", "Khawshi"); //UC4

            Console.ReadLine();
        }
    }
}
