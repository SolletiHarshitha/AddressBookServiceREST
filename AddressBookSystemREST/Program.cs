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

            details.FirstName = "Pavani";
            details.LastName = "P";
            details.Address = "CMBT";
            details.City = "Chennai";
            details.State = "Tamil Nadu";
            details.Zip = 600032;
            details.PhoneNumber = 9883839229;
            details.Email = "pavani@gmail.com";

            IRestResponse response = webService.UpdateContact(details);
            //Deserialize JSON object
            List<ContactDetails> responseData = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            Console.WriteLine("Count of contacts : " + responseData.Count);
        }
    }
}
