using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem_LINQ
{
    class AddressBookTable
    {
        DataTable table = new DataTable("AddressBookSystem"); // UC 1 Create a new DataTable

        /* UC2:- Ability to create a Address Book Table with first and last names, address, city, 
                 state, zip, phone number and email as its attributes
        */
        public AddressBookTable()
        {
            table.Columns.Add("FirstName", typeof(string)); //add coumns
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));

            /*UC3:-Ability to insert new Contacts to Address Book */
            table.Rows.Add("Omprakash", "Khawshi", "Bajaj Nagr", "Nagpur", "Maharashtra", "412105", "8788566219", "omkh@gmail.com");
            table.Rows.Add("Ekta", "Kumbhare", "Aund", "Pune", "Maharashtra", "125121", "8570934858", "ekta@gmail.com");
            table.Rows.Add("Vishal", "Singh", "Mumbai", "Mumbai", "Maharashtra", "442206", "7894561230", "vishal@gmail.com.a");



        }

        public void GetAllContacts()
        {
            try
            {
                Console.WriteLine("\n");
                foreach (DataRow dr in table.AsEnumerable())
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("FirstName:- " + dr.Field<string>("firstName"));
                    Console.WriteLine("LastName:- " + dr.Field<string>("lastName"));
                    Console.WriteLine("Address:- " + dr.Field<string>("address"));
                    Console.WriteLine("City:- " + dr.Field<string>("city"));
                    Console.WriteLine("State:- " + dr.Field<string>("state"));
                    Console.WriteLine("Zip:- " + dr.Field<string>("zip"));
                    Console.WriteLine("PhoneNumber:- " + dr.Field<string>("phoneNumber"));
                    Console.WriteLine("Email:- " + dr.Field<string>("eMail"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HelpLink);
            }

        }
        /*UC4:- Ability to edit existing contact person using their name
         */

        public void EditExistingContact(string firstName, string lastName, string column, string newValue)
        {
            try
            {
                DataRow contact = table.Select("FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
                contact[column] = newValue;
                Console.WriteLine("Record successfully Edit");
                GetAllContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /* UC5:- Ability to delete a person using person's name.
         */

        public void DeleteContact(string firstName, string lastName)
        {
            try
            {
                DataRow contact = table.Select("FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
                table.Rows.Remove(contact);
                Console.WriteLine("Record Successfully Delete");
                GetAllContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /*UC6:- Ability to Retrieve Person belonging to a City or State from the Address Book*/

        public void RetrieveByCityOrState(string Cityi, string Statei)
        {
            try
            {
                var retrieveData = from records in table.AsEnumerable()
                                   where (records.Field<string>("City").Equals(Cityi) || records.Field<string>("State").Equals(Statei))
                                   select records;
                //Printing data
                Console.WriteLine("\nRetrieved contactact details by city or state name");
                foreach (DataRow dr in table.AsEnumerable())
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("FirstName:- " + dr.Field<string>("firstName"));
                    Console.WriteLine("LastName:- " + dr.Field<string>("lastName"));
                    Console.WriteLine("Address:- " + dr.Field<string>("address"));
                    Console.WriteLine("City:- " + dr.Field<string>("city"));
                    Console.WriteLine("State:- " + dr.Field<string>("state"));
                    Console.WriteLine("Zip:- " + dr.Field<string>("zip"));
                    Console.WriteLine("PhoneNumber:- " + dr.Field<string>("phoneNumber"));
                    Console.WriteLine("Email:- " + dr.Field<string>("eMail"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /* UC7:- Ability to understand the size of address book by City and State 
                 - Here size indicates the count
        */
        public void CountByCityOrState(string city, string state)
        {
            try
            {
                var contact = from c in table.AsEnumerable()
                              where c.Field<string>("City") == city && c.Field<string>("State") == state
                              select c;

                Console.WriteLine("Count of contacts in {0}, {1} is {2}", city, state, contact.Count());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*UC8:- Ability to retrieve entries sorted alphabetically by Person’s name for a given city
        */
        public void SortedContactsByNameForAgivenCity(string City)
        {
            try
            {
                Console.WriteLine("Sorting by name for City");
                var retrievedData = from records in table.AsEnumerable()
                                    where records.Field<string>("City") == City
                                    orderby records.Field<string>("FirstName"), records.Field<string>("LastName")
                                    select records;
                ///Print Data
                foreach (var dr in retrievedData)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("FirstName:- " + dr.Field<string>("firstName"));
                    Console.WriteLine("LastName:- " + dr.Field<string>("lastName"));
                    Console.WriteLine("Address:- " + dr.Field<string>("address"));
                    Console.WriteLine("City:- " + dr.Field<string>("city"));
                    Console.WriteLine("State:- " + dr.Field<string>("state"));
                    Console.WriteLine("Zip:- " + dr.Field<string>("zip"));
                    Console.WriteLine("PhoneNumber:- " + dr.Field<string>("phoneNumber"));
                    Console.WriteLine("Email:- " + dr.Field<string>("eMail"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*UC9:- Ability to identify each Address Book with name and Type.
         *      - Here the type could Family, Friends, Profession, etc.
                - Alter Address Book to add name and type.
        */

        public void AddAddressBookNameType()
        {
            try
            {

                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "addressBookName";
                column.AllowDBNull = false;
                column.DefaultValue = "Home";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "type";
                column.AllowDBNull = false;
                column.DefaultValue = "Friend";
                table.Columns.Add(column);
                GetAllContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
