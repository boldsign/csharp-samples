using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoldSign.Demos.Models
{
    public class EmbeddedTemplate
    {
        [JsonProperty("documentId")]
        [JsonPropertyName("documentId")]
        public string DocumentId { get; set; }

        [JsonProperty("templateId")]
        [JsonPropertyName("templateId")]
        public string TemplateId { get; set; }

        [JsonProperty("SignerName")]
        [JsonPropertyName("SignerName")]
        public string SignerName { get; set; }

        [JsonProperty("SignerEmail")]
        [JsonPropertyName("SignerEmail")]
        public string SignerEmail { get; set; }

        [JsonProperty("signLink")]
        [JsonPropertyName("signLink")]
        public Uri SignLink { get; set; }

        [JsonProperty("address")]
        [JsonPropertyName("address")]
        public string PostalAddress { get; set; }

        [JsonProperty("state")]
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonProperty("postalcode")]
        [JsonPropertyName("postalcode")]
        public string PostalCode { get; set; }
    }
}
