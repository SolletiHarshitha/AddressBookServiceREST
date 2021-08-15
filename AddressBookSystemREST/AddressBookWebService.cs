using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemREST
{
    public class AddressBookWebService
    {
        RestClient client; 
        public AddressBookWebService()
        {
            client = new RestClient("http://localhost:3000");
        }
        //Retrieve Contacts
        public IRestResponse GetContactList()
        {
            RestRequest request = new RestRequest("/contacts",Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        //Add Contact
        public IRestResponse AddContact(ContactDetails details)
        {
            RestRequest request = new RestRequest("/contacts", Method.POST);
            JsonObject json = new JsonObject();
            json.Add("FirstName", details.FirstName);
            json.Add("LastName", details.LastName);
            json.Add("Address", details.Address);
            json.Add("City", details.City);
            json.Add("State", details.State);
            json.Add("Zip", details.Zip);
            json.Add("PhoneNumber", details.PhoneNumber);
            json.Add("Email", details.Email);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
        //Add Multiple Contacts
        public void AddMultiplecontacts(List<ContactDetails> contactList)
        {
            RestRequest request = new RestRequest("/contacts", Method.POST);
            foreach(ContactDetails contact in contactList)
            {
                AddContact(contact);
            }
        }
        //Update Contact
        public IRestResponse UpdateContact(ContactDetails details)
        {
            RestRequest request = new RestRequest("/contacts/2", Method.POST);
            JsonObject json = new JsonObject();
            json.Add("FirstName", details.FirstName);
            json.Add("LastName", details.LastName);
            json.Add("Address", details.Address);
            json.Add("City", details.City);
            json.Add("State", details.State);
            json.Add("Zip", details.Zip);
            json.Add("PhoneNumber", details.PhoneNumber);
            json.Add("Email", details.Email);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
        //Delete Contact
        public IRestResponse DeleteContact()
        {
            RestRequest request = new RestRequest("/contacts/1", Method.DELETE);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
