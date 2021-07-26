# Everfi.Foundry
.NET 5 SDK to access Everfi Foundry API. The library is designed to work with .NET DI. The constructor takes an ILogger<FoundryAPI> and FoundryConnectionParameters objects as parameters. 
  
# APIs
The following methods are available in the FoundryAPI class

## Get User
This method takes the following parameters and returns a list of users that meet the filter criteria. The resultset columns are limited by what you pass in the return fields.
  * Dictionary<string, string> Filters to apply to the result set
  * string Return Fields
  
## Get Categories
This method takes the following parameters and returns all categories.
  * bool Include Labels. If the bool is true then Category Labels will also be included in the resultset
  
## Get Locations
This method takes the following parameters and returns all locations. THe resultset columns are limited by the returnfields parameters.
  * string Return Fields
  
## AddUser
AddUser method creates a new user in Foundry. It takes the following parameter(s)
* FoundryUserRequest user. This object stores the data required for the Creation and Modification requests in Foundry.

## UpdateUser
UpdateUser method updates/deactivates a user in Foundry. It takes the following parameter(s)
* FoundryUserRequest user. This object stores the data required for the Creation and Modification requests in Foundry.
  
## Authenticate 
Authenticates an API Request using Client ID and Client Secret that were passed in the constructor as part of FoundryConnectionParameters object
  
## SetHeader
This method internally calls Authenticate on Foundry and then sets the Authorization Token in the Header of the Request. Call this method if you create a new API Method in the FoundryAPI class.
  
# Example

Let's get started with a simple coonsole application.
  
## Packages to include
Include the following packages
  
* Microsoft.Extensions.Logging
* Microsoft.Extensions.Hosting
* Microsoft.Extensions.DependencyInjection
  
## Set up the console application
Add the following method to your program.cs
``` csharp
   public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
         .ConfigureLogging(logging =>
         {
             logging.ClearProviders();
             logging.AddConsole();
         }).ConfigureServices((_, services) =>
         {
             services.AddScoped<FoundryConnectionParameters>()
             .AddScoped<FoundryAPI>();
         }).UseConsoleLifetime();
```
The console application is now ready to call the Foundry API methods. Here is the complete program.cs class
  
``` csharp
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Everfi.Foundry.Service;


namespace TestEverfi
{
    class Program
    {
        static void Main(string[] args)
        {

            using IHost host = CreateHostBuilder(args).Build();
            var connectionParms = host.Services.GetService<FoundryConnectionParameters>();
            connectionParms.ClientID = "Client ID Goes Here";
            connectionParms.ClientSecret = "Your Client Secret Goes here";
            connectionParms.SandBoxMode = true;

            var api = host.Services.GetService<FoundryAPI>();

            //Get User. Add all the filters in a Dictionary.
            // Define return fields
            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("filter[employee_id]", "<Employee ID to Search>");

            string returnFields = "first_name,last_name,email,sso_id,employee_id,user_types";

            var user = api.GetUser(filters,returnFields).Result;


            //Get Categoires. The bool is used to bring back category labels along with categories. If set to false, only categories will be returned.
            var categories = api.GetCategories(true).Result;

            //Get Locations. Pass the return fields
            var locations = api.GetLocations("id,type,name,external_id,address_country_iso_code,address_state_iso_code").Result;

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
         .ConfigureLogging(logging =>
         {
             logging.ClearProviders();
             logging.AddConsole();
         }).ConfigureServices((_, services) =>
         {
             services.AddScoped<FoundryConnectionParameters>()
             .AddScoped<FoundryAPI>();
         }).UseConsoleLifetime();              

    }
}
  
```
  

