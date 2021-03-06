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
        /// <summary>
        /// Retrieve count of contacts
        /// </summary>
        [TestMethod]
        public void GetCountOfContacts()
        {
            IRestResponse response = webService.GetContactList();
            //Checking the status code
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<ContactDetails> responseData = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            Assert.AreEqual(2, responseData.Count);
        }
        /// <summary>
        /// Add multiple contacts
        /// </summary>
        [TestMethod]
        public void AddMultipleContactsByCallingPOSTApi()
        {
            List<ContactDetails> contactList = new List<ContactDetails>();
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
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            //Deserialize JSON object
            List<ContactDetails> responseData = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            Assert.AreEqual(4,responseData.Count);
        }
        /// <summary>
        /// Update contact
        /// </summary>
        [TestMethod]
        public void UpdateContactByCallingPUTApi()
        {
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
            var res = JsonConvert.DeserializeObject<ContactDetails>(response.Content);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
        /// <summary>
        /// Delete contact
        /// </summary>
        [TestMethod]
        public void DeleteContactByCallingDeleteApi()
        {
            IRestResponse res = webService.DeleteContact();
            IRestResponse response = webService.GetContactList();
            List<ContactDetails> result = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(3, result.Count);
        }
    }
}
