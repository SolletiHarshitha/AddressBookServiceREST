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
            RestRequest request = new RestRequest("/AddressBook",Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
