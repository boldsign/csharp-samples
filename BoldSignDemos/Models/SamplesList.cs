using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoldSign.Demos.Models
{
    public class SamplesList
    {
        public SamplesList()
        {

        }

        public SamplesList(int id, string name, string description, string iconCss, string controllerName, string viewPageName, bool isDisplayCard, string cardButtonName, string cardDescription)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IconCss = iconCss;
            this.ControllerName = controllerName;
            this.ViewPageName = viewPageName;
            this.IsDisplayCard = isDisplayCard;
            this.CardButtonName = cardButtonName;
            this.CardDescription = cardDescription;
        }

        public static List<SamplesList> GetAllSamplesList()
        {
            List<SamplesList> samplesLists = new List<SamplesList>();
            samplesLists.Add(new SamplesList
            {
                Id = 1,
                Name = "Send document for signing",
                CardDescription = "The BoldSign document will be created on the fly with the required properties.",
                Description = "The BoldSign document will be created on the fly with the required properties like uploading document, signer and details. <br /> Try filling the below form details and send the document to check how it works!",
                IconCss = "",
                ControllerName = "CreateDocument",
                ViewPageName = "Index",
                IsDisplayCard = true,
                CardButtonName = "Create Document",
            });
            samplesLists.Add(new SamplesList
            {
                Id = 2,
                Name = "List, and get detailed information of the documents",
                Description = "On this demo example, list documents sent and received by the current user, and query with many filter options.  <br /> BoldSign also provides API to get the detailed information about the specific document. <br /> When you click on the specific document record, it will be redirect to the detailed page of the document using Get Properties API.",
                CardDescription = "On this demo example, documents list, filter and get detailed information of the specific document.",
                IconCss = "",
                ControllerName = "ListDocument",
                ViewPageName = "Index",
                IsDisplayCard = true,
                CardButtonName = "List Document",
            });
            samplesLists.Add(new SamplesList
            {
                Id = 3,
                Name = "Send document from template",
                Description = "Sending document from template is the most easiest way. The template will be created from the BoldSign web app, this allow us to confirm the visual placement of the elements. <br /> The already created template can be used the send the document out for signing, by just filing the signer details. <br /> Try filling the below form details and send the document to check how it works!",
                CardDescription = "Sending document from template is most easiest way.",
                IconCss = "",
                ControllerName = "TemplateDocument",
                ViewPageName = "Index",
                IsDisplayCard = true,
                CardButtonName = "Template Document",
            });
            samplesLists.Add(new SamplesList
            {
                Id = 4,
                Name = "Embed signing process within your app",
                Description = "BoldSign embedded signing feature allow your users to complete the signing process without leaving your application using iFrame. <br /> Try filling the below form details, send the document, and sign the document. This will help you to understand the complete signing process.",
                CardDescription = "On this demo, the signing process is hosted in the application using iFrame.",
                IconCss = "",
                ControllerName = "EmbeddedSign",
                ViewPageName = "Index",
                IsDisplayCard = true,
                CardButtonName = "EmbeddedSign Within App",
            });
            samplesLists.Add(new SamplesList
            {
                Id = 5,
                Name = "Embed signing process without iFrame",
                Description = "BoldSign embedded signing feature allows your users to complete the signing process without iFrame. The signing process will be held at BoldSign web app. On completion of the signing process, the user will be redirect to your application. <br /> Try filling the below form details, send the document, and sign the document. This will help you to understand the complete signing process.",
                CardDescription = "On this demo, the signing process will be held at BoldSign web app. On completion, the user will be redirect to your application.",
                IconCss = "",
                ControllerName = "EmbeddedSignWithForm",
                ViewPageName = "Index",
                IsDisplayCard = true,
                CardButtonName = "EmbeddedSign",
            });
            samplesLists.Add(new SamplesList
            {
                Id = 6,
                Name = "Get document properties",
                Description = "The detailed document properties of the selected document.",
                CardDescription = "This can be display document properties based on the selected document id.",
                IconCss = "",
                ControllerName = "DocumentProperties",
                ViewPageName = "Index",
                IsDisplayCard = false,
                CardButtonName = "Document Properties",
            });
            return samplesLists;
        }


        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonProperty("iconCss")]
        [JsonPropertyName("iconCss")]
        public string IconCss { get; set; }

        [JsonProperty("controllerName")]
        [JsonPropertyName("controllerName")]
        public string ControllerName { get; set; }

        [JsonProperty("viewPageName")]
        [JsonPropertyName("viewPageName")]
        public string ViewPageName { get; set; }

        [JsonProperty("isDisplayCard")]
        [JsonPropertyName("isDisplayCard")]
        public bool IsDisplayCard { get; set; }

        [JsonProperty("cardButtonName")]
        [JsonPropertyName("cardButtonName")]
        public string CardButtonName { get; set; }

        [JsonProperty("cardDescription")]
        [JsonPropertyName("cardDescription")]
        public string CardDescription { get; set; }

        [JsonProperty("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
