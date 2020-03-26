using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Exceptions;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.ReadOnly.Bank;
using IdokladSdk.Models.ReadOnly.Country;

namespace IdokladSdk.NetCore.TestApp.Examples
{
    /// <summary>
    /// ContactExamples.
    /// </summary>
    public class ContactExamples
    {
        private readonly DokladApi _api;
        private List<BankListGetModel> _banks;
        private List<CountryListGetModel> _countries;

        public ContactExamples(DokladApi api)
        {
            _api = api;
        }

        public List<BankListGetModel> Banks => _banks ?? (_banks = GetBanks());

        public List<CountryListGetModel> Countries => _countries ?? (_countries = GetCountries());

        public int CreateContact_ResponseChecking()
        {
            // Get default contact values
            var defaultResponse = _api.ContactClient.Default();

            // Check API response
            if (!defaultResponse.IsSuccess)
            {
                throw new ApplicationException($"Error while trying to get default contact values: {defaultResponse.StatusCode} - {defaultResponse.Message}");
            }

            // Modify contact returned from API
            var contactToCreate = defaultResponse.Data;
            contactToCreate.CompanyName = "company 1";
            contactToCreate.IdentificationNumber = "12345678";
            contactToCreate.CountryId = GetCountry("CZ");
            contactToCreate.BankId = GetBank(contactToCreate.CountryId, "0800");
            contactToCreate.City = "Brno";
            contactToCreate.Street = "Drobneho 49";
            contactToCreate.PostalCode = "602 00";

            // Create new contact
            var postResponse = _api.ContactClient.Post(contactToCreate);

            // Check API response
            if (!postResponse.IsSuccess)
            {
                throw new ApplicationException($"Error while trying to create new contact: {postResponse.StatusCode} - {postResponse.Message}");
            }

            // Get created contact
            var createdContact = postResponse.Data;
            return createdContact.Id;
        }

        public int CreateContact_ExceptionHandling()
        {
            try
            {
                // Get default contact values - throws an exception if not successful
                var contactToCreate = _api.ContactClient.Default().CheckResult();

                // Modify default contact values
                contactToCreate.CompanyName = "company 2";
                contactToCreate.IdentificationNumber = "87654321";

                // Create new contact - throws an exception if not successful
                var createdContact = _api.ContactClient.Post(contactToCreate).CheckResult();

                return createdContact.Id;
            }
            catch (IdokladSdkException e)
            {
                Console.WriteLine($"iDoklad API call failed: {e.ApiResult.StatusCode} - {e.ApiResult.Message}");
                throw;
            }
        }

        public ContactGetModel UpdateContact(int id, string firstName, string surname)
        {
            // Create update model containing id (required) and only properties to be updated
            var contactUpdate = new ContactPatchModel
            {
                Id = id,
                Firstname = firstName,
                Surname = surname
            };

            // Update contact - throws an exception if not successful
            var updatedContact = _api.ContactClient.Update(contactUpdate).CheckResult();
            return updatedContact;
        }

        private List<BankListGetModel> GetBanks()
        {
            return _api.BankClient
                .List()
                .Get()
                .Data.Items
                .ToList();
        }

        private List<CountryListGetModel> GetCountries()
        {
            return _api.CountryClient
                .List()
                .Get()
                .Data.Items
                .ToList();
        }

        private int GetBank(int countryId, string code)
        {
            var bank = Banks.FirstOrDefault(b => b.CountryId == countryId && b.NumberCode == code);

            return bank?.Id ?? 0;
        }

        private int GetCountry(string code)
        {
            var country = Countries.FirstOrDefault(c => c.Code == code);

            return country?.Id ?? 0;
        }
    }
}
