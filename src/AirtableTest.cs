using Elements;
using Elements.Geometry;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AirtableTest
{
    public static class AirtableTest
    {
        /// <summary>
        /// The AirtableTest function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A AirtableTestOutputs instance containing computed results and the model with any new elements.</returns>
        public static AirtableTestOutputs Execute(Dictionary<string, Model> inputModels, AirtableTestInputs input)
        {
            var output = new AirtableTestOutputs();
            // set up your REST client with RestSharp
            var client = new RestClient("FILL IN YOUR AIRTABLE BASE URL");
            // Specify the request type
            var request = new RestRequest(Method.GET);
            // set up any headers or authorization parameters
            request.AddHeader("Authorization", "Bearer FILL IN YOUR AIRTABLE API KEY");
            // perform the request synchronously
            IRestResponse response = client.Execute(request);
            // parse the response body
            var result = JsonConvert.DeserializeObject<AirtableResponse>(response.Content);
            // do something with the result
            foreach (var record in result.records)
            {
                var fields = record.fields;
                var rect = Polygon.Rectangle(fields.Width, fields.Length);
                var mass = new Mass(rect, fields.Height);
                output.Model.AddElement(mass);
            }
            return output;
        }
    }
}