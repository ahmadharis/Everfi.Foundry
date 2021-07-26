using System;
namespace Everfi.Foundry.Common
{
        public struct FoundryAuthentication
        {
            public const string GrantType = "grant_type";
            public const string ClientID = "client_id";
            public const string ClientSecret = "client_secret";
            public const string ClientCredentialsGrantType = "client_credentials";
        }


        public struct FoundryAPIEndPoint
        {
            public const string BaseSandBoxURI = "https://api.fifoundry-sandbox.net";
            public const string BaseURI = "https://api.fifoundry.net";
            public const string Authenticate = "oauth/token?";
            public const string GetUsers = "v1/admin/users/?";
            public const string AddUser = "v1/admin/registration_sets/";
            public const string UpdateUser = "v1/admin/registration_sets/";
            public const string GetCategories = "v1/admin/categories/?";
            public const string GetLocations = "v1/admin/locations/?";
        }

        public struct ContentType
        {
            public const string JSON = "application/json";
        }


}
