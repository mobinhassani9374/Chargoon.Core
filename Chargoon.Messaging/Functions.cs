using Chargoon.Messaging.Models;
using Chargoon.Messaging.Setting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Messaging
{
  public  class Functions
    {
        private readonly RequestProvider _requestProvider;
        public Functions(RequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }
        public async Task<TokenModel> GetToken(Key model)
        {
            var response = await _requestProvider
                .PostAsync<Key, TokenModel>(model, UrlAddress.GetTokenAddress);

            return response as TokenModel;
        }
        public async Task<SendByMobileNumberResultModel> SendByMobileNumbers(SendByMobileNumberModel model, string token)
        {
            var response = await _requestProvider.PostAsync<SendByMobileNumberModel, SendByMobileNumberResultModel>(model, UrlAddress.SendByMobileNumber, token);

            return response as SendByMobileNumberResultModel;
        }
        public async Task<SearchContactResultModel> SearchContacts(SearchContactModel model, string token)
        {
            var response = await _requestProvider
                .GetAsync<SearchContactModel, SearchContactResultModel>(model, UrlAddress.SearchContacts, token);

            return response as SearchContactResultModel;
        }

        public async Task<AddContactResultModel> AddContact(AddContactModel model, string token)
        {
            var response = await _requestProvider
                .PostAsync<AddContactModel, AddContactResultModel>(model, UrlAddress.AddContacts,
                token);

            return response as AddContactResultModel;
        }
    }
}
