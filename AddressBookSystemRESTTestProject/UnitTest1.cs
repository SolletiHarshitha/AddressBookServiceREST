using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSystemREST;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AddressBookSystemRESTTestProject
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookWebService webService;
        [TestInitialize]
        public void SetUp()
        {
            webService = new AddressBookWebService();
        }
        [TestMethod]
        public void GetCountOfContacts()
        {
            IRestResponse response = webService.GetContactList();
            //Checking the status code
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<ContactDetails> responseData = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            Assert.AreEqual(2, responseData.Count);
        }
    }
}
