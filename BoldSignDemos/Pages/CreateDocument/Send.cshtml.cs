using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoldSign.Api;
using BoldSign.Model;
using BoldSign.Demos.Models;
using BoldSign.Demos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BoldSign.Demos.Pages.CreateDocument
{
    public class SendModel : PageModel
    {
        public BoldSignDemoViewModel BoldSignDemoViewModel { get; set; }
        private readonly DocumentClient documentClient;
        public SendModel(DocumentClient documentClient)
        {
            this.documentClient = documentClient;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSendAsync(DocumentDetails createDocument)
        {
            //form document details based on the form data.
            var formFields = new List<FormField>();

            //signature field
            formFields.Add(new FormField(
                 name: "Sign",
                 type: FieldType.Signature,
                 pageNumber: 1,
                 isRequired: true,
                 bounds: new Rectangle(x: 96, y: 726, width: 172, height: 43)));

            //email field
            formFields.Add(new FormField(
                type: FieldType.Label,
                pageNumber: 1,
                value: createDocument.Email,
                fontSize: 14,
                bounds: new Rectangle(x: 271, y: 740, width: 250, height: 18)));

            //name field
            formFields.Add(new FormField(
                type: FieldType.Label,
                pageNumber: 1,
                value: createDocument.Name,
                bounds: new Rectangle(x: 140, y: 210, width: 141, height: 17)));

            //address field
            formFields.Add(new FormField(
                type: FieldType.Label,
                pageNumber: 1,
                value: createDocument.Address,
                bounds: new Rectangle(x: 195, y: 235, width: 200, height: 22)));
            var documentDetails = new SendForSign
            {
                Title = "Sent from API SDK",
                Message = "This is document message sent from API SDK",
                Signers = new List<DocumentSigner>
                {
                    new DocumentSigner(
                        name: createDocument.Name,
                        emailAddress: createDocument.Email,
                        signerType: SignerType.Signer,
                        signerOrder: 1,
                        privateMessage: "This is private message for signer",
                        formFields: formFields),
                },
                ExpiryDays = 30,
            };

            // document
            documentDetails.Files = new List<IDocumentFile>
        {
            new DocumentFilePath
            {
                ContentType = "application/pdf",
                // directly provide file path
                FilePath = "Affidavit-of-Residence.pdf",
            }
        };
            // send request for document creation.
            DocumentCreated documentCreated = await this.documentClient.SendDocumentAsync(documentDetails).ConfigureAwait(false);
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                DocumentDetails = new DocumentDetails() { DocumentId = documentCreated.DocumentId, Name = createDocument.Name, Email = createDocument.Email },
                SamplesLists = SamplesList.GetAllSamplesList()
            };
            return Page();
        }
    }
}
