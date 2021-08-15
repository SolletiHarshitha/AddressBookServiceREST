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

            //Delete contact
            webService.DeleteContact();

            IRestResponse response = webService.GetContactList();
            //Deserialize JSON object
            List<ContactDetails> responseData = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            Console.WriteLine("Count of contacts : " + responseData.Count);
        }
    }
}
