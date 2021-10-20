using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoldSign.Demos.Models
{
    public class TemplateDetails
    {
        [JsonProperty("documentId")]
        [JsonPropertyName("documentId")]
        public string DocumentId { get; set; }

        [JsonProperty("templateId")]
        [JsonPropertyName("templateId")]
        public string TemplateId { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("signLink")]
        [JsonPropertyName("signLink")]
        public string SignLink { get; set; }

        [JsonProperty("address")]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonProperty("state")]
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonProperty("postalcode")]
        [JsonPropertyName("postalcode")]
        public string PostalCode { get; set; }

    }
}
