using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Text;
using Microsoft.Extensions.Logging;
using Everfi.Foundry.Common;
using Everfi.Foundry.ViewModel;

namespace Everfi.Foundry.Service
{
    public class FoundryConnectionParameters
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public bool SandBoxMode { get; set; } = false;
    }
    /// <summary>
    /// Foundry API
    /// </summary>
    public class FoundryAPI
    {
        private readonly ILogger<FoundryAPI> _logger;

        private readonly FoundryConnectionParameters _parms;

        private FoundryToken Token { get; set; }
        private HttpClient client = new HttpClient();

        public FoundryAPI(ILogger<FoundryAPI> logger)
        {
            _logger = logger;
        }
        public FoundryAPI(ILogger<FoundryAPI> logger, FoundryConnectionParameters parms)
        {
            _logger = logger;
            _parms = parms;
        }

        public void Configure(FoundryConnectionParameters parms)
        {
            if (parms != null)
            {
                _parms.ClientID = parms.ClientID;
                _parms.ClientSecret = parms.ClientSecret;
                _parms.SandBoxMode = parms.SandBoxMode;
            }

            client.BaseAddress = GetBaseURI(_parms.SandBoxMode);
        }

         /// <summary>
        /// Get Base URI for API calls.
        /// </summary>
        /// <param name="sandboxMode"></param>
        /// <returns></returns>
        public Uri GetBaseURI(bool sandboxMode = false)
        {
            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Calling '{nameof(GetBaseURI)}' method in '{nameof(FoundryAPI)}' class.");

            Uri baseURI;

            if (sandboxMode == false)
                baseURI = new Uri(FoundryAPIEndPoint.BaseURI);
            else
                baseURI = new Uri(FoundryAPIEndPoint.BaseSandBoxURI);

            if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Sandbox mode set to {sandboxMode}. Using the URI: {baseURI}");

            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Exiting '{nameof(GetBaseURI)}' method in '{nameof(FoundryAPI)}' class.");

            return baseURI;
        }

                
        /// <summary>
        /// Call Foundry Get Users API
        /// </summary>
        /// <param name="filters">A dictionary of filters</param>
        /// <param name="returnFields">comma separated return fields</param>
        /// <returns></returns>
        public async Task<FoundryGetUsersResponse> GetUser(Dictionary<string, string> filters, string returnFields)
        {
            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Calling '{nameof(GetUser)}' method in '{nameof(FoundryAPI)}' class.");
            var user = new FoundryGetUsersResponse();

            try
            {
                // Set the header
                await SetHeader();
                var query = HttpUtility.ParseQueryString(string.Empty);

                // Set  filters if the parameter is set.
                if (filters.Count > 0)
                {
                    foreach(var filter in filters)
                    {
                        if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Add filter{filter.Key}={filter.Value}");
                        query[filter.Key] = filter.Value;
                    }
                }

                // Set return fields if the parameters is set
                if (returnFields != String.Empty || returnFields != null)
                {
                    if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Return fields: {returnFields}");
                    query["field[users]"] = returnFields;
                }

                if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Send Get User request to : {FoundryAPIEndPoint.GetUsers + query.ToString()} ");
                user = await client.GetFromJsonAsync<FoundryGetUsersResponse>(FoundryAPIEndPoint.GetUsers + query.ToString());
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error)) _logger.LogError(ex, $"Exception has occurred in '{nameof(GetUser)}' method in '{nameof(FoundryAPI)}' class.");
                throw new Exception("Exception occurred in GetUsers API", ex);
            }

            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Exiting '{nameof(GetUser)}' method in '{nameof(FoundryAPI)}' class.");
            return user;
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns></returns>
        public async Task<FoundryGetCategoriesResponse> GetCategories(bool includeLabels)
        {
            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Calling '{nameof(GetCategories)}' method in '{nameof(FoundryAPI)}' class.");
            var categories = new FoundryGetCategoriesResponse();
            try
            {
                await SetHeader();
                var query = HttpUtility.ParseQueryString(string.Empty);
                if (includeLabels)
                {
                    if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Include Labels: {includeLabels}");
                    query["include"] = "category_labels";
                }

                if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Send Get Categories request to : {FoundryAPIEndPoint.GetCategories + query.ToString()}");
                categories = await client.GetFromJsonAsync<FoundryGetCategoriesResponse>(FoundryAPIEndPoint.GetCategories + query.ToString());
            }
            catch (Exception ex) {
                if (_logger.IsEnabled(LogLevel.Error)) _logger.LogError(ex, $"Exception has occurred in '{nameof(GetCategories)}' method in '{nameof(FoundryAPI)}' class.");
                throw new Exception("Exception occurred in Get Categories API", ex);
            }

            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Exiting '{nameof(GetCategories)}' method in '{nameof(FoundryAPI)}' class.");

            return categories;
        }

        /// <summary>
        /// Get All Locations
        /// </summary>
        /// <returns></returns>
        public async Task<FoundryGetLocationsResponse> GetLocations(string returnFields)
        {
            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Calling '{nameof(GetLocations)}' method in '{nameof(FoundryAPI)}' class.");
            var locations = new FoundryGetLocationsResponse();
            try
            {
                await SetHeader();
                var query = HttpUtility.ParseQueryString(string.Empty);
                if (returnFields != String.Empty || returnFields != null)
                {
                    if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Return fields: {returnFields}");
                    query["fields[locations]"] = "id,type,name,external_id,address_country_iso_code,address_state_iso_code";
                }

                if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Send Get Locations request to : {FoundryAPIEndPoint.GetLocations + query.ToString()}");
                locations = await client.GetFromJsonAsync<FoundryGetLocationsResponse>(FoundryAPIEndPoint.GetLocations + query.ToString());
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error)) _logger.LogError(ex, $"Exception has occurred in '{nameof(GetLocations)}' method in '{nameof(FoundryAPI)}' class.");
                throw new Exception("Exception occurred iin Get Locations API. ", ex);
            }

            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Exiting '{nameof(GetLocations)}' method in '{nameof(FoundryAPI)}' class.");
            return locations;
        }

        /// <summary>
        /// Add a new user to Foundry
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Tuple<FoundryGetUserResponse,HttpResponseMessage>> AddUser(FoundryUserRequest user)
        {
            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Calling '{nameof(AddUser)}' method in '{nameof(FoundryAPI)}' class.");

            var userResponse = new FoundryGetUserResponse(); //Foundry Get User Response Object
            var response = new HttpResponseMessage(); // HTTP Response Message
            try
            {
                // Set Header
                await SetHeader();

                //Set Json serialization options. Ignore properties that have null values
                JsonSerializerOptions options = new()
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var json = JsonSerializer.Serialize(user, options);
                var data = new StringContent(json, Encoding.UTF8, ContentType.JSON);

                if (_logger.IsEnabled(LogLevel.Debug)) _logger.LogDebug($"Send Create User request to : {FoundryAPIEndPoint.AddUser} with data: {json}");
                response = await client.PostAsync(FoundryAPIEndPoint.AddUser, data);

                // If status code is OK or Created then process, otherwise throw a new Exception with the content of the response.
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    userResponse = await JsonSerializer.DeserializeAsync<FoundryGetUserResponse>(response.Content.ReadAsStream());
                    if (_logger.IsEnabled(LogLevel.Debug)) _logger.LogDebug($"Add User API Response : {await response.Content.ReadAsStringAsync()}");
                }
                else
                {
                    if (_logger.IsEnabled(LogLevel.Warning)) _logger.LogWarning($"Add User API Response : {await response.Content.ReadAsStringAsync()}");
                }//endif response.StatusCode
               
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error)) _logger.LogError(ex, $"Exception has occurred in '{nameof(AddUser)}' method in '{nameof(FoundryAPI)}' class.");
            }

            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Exiting '{nameof(AddUser)}' method in '{nameof(FoundryAPI)}' class.");
            return new Tuple<FoundryGetUserResponse, HttpResponseMessage>(userResponse,response);
        }

        /// <summary>
        /// Update an existing user in Foundry
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Tuple<FoundryGetUserResponse, HttpResponseMessage>> UpdateUser(FoundryUserRequest user)
        {
            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Calling '{nameof(UpdateUser)}' method in '{nameof(FoundryAPI)}' class.");

            var userResponse = new FoundryGetUserResponse();
            var response = new HttpResponseMessage();

            try
            {
                // Set Header
                await SetHeader();

                // Set Json Serialization Options
                JsonSerializerOptions options = new()
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var json = JsonSerializer.Serialize(user, options);
                var data = new StringContent(json, Encoding.UTF8, ContentType.JSON);

                if (_logger.IsEnabled(LogLevel.Debug)) _logger.LogDebug($"Send Update User request to : {FoundryAPIEndPoint.UpdateUser + user.Data.Id} with data: {json}");
                response = await client.PatchAsync(FoundryAPIEndPoint.UpdateUser + user.Data.Id, data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    userResponse = await JsonSerializer.DeserializeAsync<FoundryGetUserResponse>(response.Content.ReadAsStream());
                    if (_logger.IsEnabled(LogLevel.Debug)) _logger.LogDebug($"Update User API Response : {await response.Content.ReadAsStringAsync()}");
                }
                else
                {
                    if (_logger.IsEnabled(LogLevel.Warning)) _logger.LogWarning($"Update User API Response : {await response.Content.ReadAsStringAsync()}");
                }

            }
            catch(Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error)) _logger.LogError(ex, $"Exception has occurred in '{nameof(UpdateUser)}' method in '{nameof(FoundryAPI)}' class.");
            }

            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Exiting '{nameof(UpdateUser)}' method in '{nameof(FoundryAPI)}' class.");
            return new Tuple<FoundryGetUserResponse, HttpResponseMessage>(userResponse, response); ;
        }


        /// <summary>
        /// Authenticate Foundry
        /// </summary>
        /// <returns></returns>
        public async Task<FoundryToken> Authenticate()
        {
            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Calling '{nameof(Authenticate)}' method in '{nameof(FoundryAPI)}' class.");

            var token = new FoundryToken();
            if (Token is null || Token.AccessToken == String.Empty)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query[FoundryAuthentication.GrantType] = FoundryAuthentication.ClientCredentialsGrantType;
                query[FoundryAuthentication.ClientID] = _parms.ClientID;
                query[FoundryAuthentication.ClientSecret] = _parms.ClientSecret;

                if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation($"Send Authenticate request to : {FoundryAPIEndPoint.Authenticate} | Query String: {FoundryAuthentication.GrantType} = { FoundryAuthentication.ClientCredentialsGrantType}");
                var response = client.PostAsync(FoundryAPIEndPoint.Authenticate + query.ToString(), null);
                token = await JsonSerializer.DeserializeAsync<FoundryToken>(response.Result.Content.ReadAsStream());
                Token = token;
            }

            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Exiting '{nameof(Authenticate)}' method in '{nameof(FoundryAPI)}' class.");
            return Token;
        }

        /// <summary>
        /// Set Header token and other core header values to connect
        /// to the Foundry API
        /// </summary>
        /// <returns></returns>
        public async Task<HttpClient> SetHeader()
        {
            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Calling '{nameof(SetHeader)}' method in '{nameof(FoundryAPI)}' class.");

            //Authenticate
            await Authenticate();

            //Set Default Headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.TokenType, Token.AccessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType.JSON));

            if (_logger.IsEnabled(LogLevel.Trace)) _logger.LogTrace($"Exiting '{nameof(SetHeader)}' method in '{nameof(FoundryAPI)}' class.");
            return client;

        }
    }
}
