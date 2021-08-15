using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AddressBookSystemREST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book System Using REST API");
            List<ContactDetails> contactList = new List<ContactDetails>();
            AddressBookWebService webService = new AddressBookWebService();
            ContactDetails details = new ContactDetails();
            ContactDetails details2 = new ContactDetails();

            details.FirstName = "Krishna";
            details.LastName = "K";
            details.Address = "T-Nagar";
            details.City = "Chennai";
            details.State = "Tamil Nadu";
            details.Zip = 600032;
            details.PhoneNumber = 9303949594;
            details.Email = "krishna@gmail.com";
            contactList.Add(details);
            details2.FirstName = "Pallavi";
            details2.LastName = "P";
            details2.Address = "T-Nagar";
            details2.City = "Chennai";
            details2.State = "Tamil Nadu";
            details2.Zip = 600032;
            details2.PhoneNumber = 9343354454;
            details2.Email = "pallavi@gmail.com";
            contactList.Add(details2);

            webService.AddMultiplecontacts(contactList);
            IRestResponse response = webService.GetContactList();
            //Deserialize JSON object
            List<ContactDetails> responseData = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            Console.WriteLine("Count of contacts : " + responseData.Count);
        }
    }
}
