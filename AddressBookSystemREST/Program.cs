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
            AddressBookWebService webService = new AddressBookWebService();
            webService.GetContactList();
            IRestResponse response = webService.GetContactList();
            //Deserialize JSON object
            List<ContactDetails> responsData = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            Console.WriteLine("Count of contacts : "+responsData.Count);
        }
    }
}
