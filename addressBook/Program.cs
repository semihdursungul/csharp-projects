using System;
using System.Collections.Generic;

namespace AddressBookApp
{
    class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{Name}: {PhoneNumber}";
        }
    }

    class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(string name, string phoneNumber)
        {
            var contact = new Contact { Name = name, PhoneNumber = phoneNumber };
            contacts.Add(contact);
            Console.WriteLine($"Contact '{name}' added successfully!");
        }

        public void DeleteContact(string name)
        {
            var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                contacts.Remove(contact);
                Console.WriteLine($"Contact '{name}' deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Contact '{name}' not found!");
            }
        }

        public void DisplayContacts()
        {
            Console.WriteLine("Contacts in Address Book:");
            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("No contacts found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            while (true)
            {
                Console.WriteLine("\nAddress Book Menu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Delete Contact");
                Console.WriteLine("3. Display All Contacts");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice (1/2/3/4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the contact name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter the contact phone number: ");
                        string phoneNumber = Console.ReadLine();
                        addressBook.AddContact(name, phoneNumber);
                        break;

                    case "2":
                        Console.Write("Enter the contact name to delete: ");
                        string nameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(nameToDelete);
                        break;

                    case "3":
                        addressBook.DisplayContacts();
                        break;

                    case "4":
                        Console.WriteLine("Exiting the Address Book. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
