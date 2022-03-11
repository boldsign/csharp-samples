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
                CardDescription = "Send e-signature document request to one or more recipients with signing workflow, auto-reminders, expiry date, and more.",
                Description = "Fill in a name and postal address in the below form to create an e-signature document with those prefilled values and send an e-signature request.",
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
                Description = "This demo lists all the documents sent and received by the demo account. Click on any row to view all of its document properties. You can filter the document list using its properties like status, search terms, labels, sender email, and recipients.",
                CardDescription = "Find and list all the documents with a simple OData endpoint. Track only document statuses or fetch it's full properties with the dedicated endpoints.",
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
                Description = "Try filling in the below form and send the document to check how it works! <br/> The form is prefilled with a Template ID which is a template created on <a class='text-decoration-none text-center fs-14 bs_color_0565FF' href='http://app.boldsign.com/'>BoldSign Web App</a>. Note: Learn how to create a template from <a class='text-decoration-none text-center fs-14 bs_color_0565FF' href='https://www.boldsign.com/help/getting-started/creating-templates/'>here</a>. ",
                CardDescription = "Use a pre-configured template created in BoldSign WebApp in your API call to send e-signature requests. <br /> <div class='font-italic'>Note: BoldSign WebApp is a link to our app.</div>",
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
                Description = "BoldSign embedded signing feature allow your users to complete the signing process without leaving your application using iFrame. <br/> Try filling the below form details, send the document, and sign the document. This will help you to understand the complete signing process.",
                CardDescription = "Seamlessly collect e-signatures within your app by embedding BoldSign signer page in it.",
                IconCss = "",
                ControllerName = "EmbeddedSign",
                ViewPageName = "Index",
                IsDisplayCard = true,
                CardButtonName = "EmbeddedSign Within App",
            });
            samplesLists.Add(new SamplesList
            {
                Id = 5,
                Name = "Redirect to signing page from your app",
                Description = "BoldSign embedded signing feature allows your users to complete the signing process with a seamless redirect to signer page then back to your app without an iFrame. <br/> Try filling the below form details, send the document, and sign the document. This will help you to understand the complete signing process.",
                CardDescription = "Collect e-signatures by redirect your users directly to their signing page without sending an email.",
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
            samplesLists.Add(new SamplesList
            {
                Id = 7,
                Name = "Embed send document within your app",
                Description = "BoldSign embedded requesting feature allows you to send the document for signing process without leaving your application using iFrame. <br/> <br/> Try filling out the details below and sending the document. This will help you to understand the complete sending and signing process.",
                CardDescription = "Send e-signature request within your app by embedded BoldSign sending page in it.",
                IconCss = "",
                ControllerName = "EmbeddedSample",
                ViewPageName = "Index",
                IsDisplayCard = true,
                CardButtonName = "Embedded Request",
            });
            samplesLists.Add(new SamplesList
            {
                Id = 8,
                Name = "Dynamic field positioning with text tags",
                Description = "BoldSign text tags are used to place the form field in the document without using co-ordinates, this will be used in the scenario when form field’s location is not predictable, due to the document content nature.  <br/> <br/> <a style='font-style:italic'>Note: In this demo sample, we have used black color text for your visibility and to understand about text tags. But in real, it is advised to use the color that match background, usually it will be white-on-white.</a> <br/> <br/> <a class='text-decoration-none text-center fs-14 bs_color_0565FF' rel='nofollow' href='https://www.boldsign.com/help/api/text-tags/usage/#text-tag-syntax'>Documentation: Text tags syntax</a>",
                CardDescription = "Send document for signature with text tags without locating the fields using co-ordinates.",
                IconCss = "",
                ControllerName = "TextTags",
                ViewPageName = "Index",
                IsDisplayCard = true,
                CardButtonName = "Text Tags",
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
