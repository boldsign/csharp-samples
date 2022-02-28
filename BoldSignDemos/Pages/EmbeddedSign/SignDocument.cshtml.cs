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

namespace BoldSign.Demos.Pages.EmbeddedSign
{
    public class SignDocumentModel : PageModel
    {
        public BoldSignDemoViewModel BoldSignDemoViewModel { get; set; }
        private readonly DocumentClient documentClient;
        private readonly TemplateClient templateClient;
        public SignDocumentModel(DocumentClient documentClient, TemplateClient templateClient)
        {
            this.documentClient = documentClient;
            this.templateClient = templateClient;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSignDocumentAsync(TemplateDetails templateDocument)
        {
            var sendForSignFromTemplate = new SendForSignFromTemplate()
            {
                TemplateId = templateDocument.TemplateId,
                Title = "Affidavit of Residence",
                Roles = new List<Roles>()
                {
                    new Roles
                    {
                        SignerName = templateDocument.Name,
                        SignerEmail = templateDocument.Email,
                        RoleIndex = 1,
                        SignerType = SignerType.Signer,
                        ExistingFormFields = new List<ExistingFormField>()
                        {
                            new ExistingFormField()
                            {
                                Id = "SignerName",
                                Value = templateDocument.Name,
                            },
                            new ExistingFormField()
                            {
                                Id = "SignerAddress",
                                Value = templateDocument.Address,
                            },
                            new ExistingFormField()
                            {
                                Id = "SignerState",
                                Value = templateDocument.State,
                            },
                            new ExistingFormField()
                            {
                                Id = "SignerPostalCode",
                                Value = templateDocument.PostalCode,
                            },
                        }
                    }
                },
            };
            DocumentCreated documentCreated = null;
            try
            {
                documentCreated = await this.templateClient.SendUsingTemplateAsync(sendForSignFromTemplate).ConfigureAwait(false);
            }
            catch (ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            var documentId = documentCreated.DocumentId;
            EmbeddedSigningLink embeddedSigning = this.documentClient.GetEmbeddedSignLink(
                 documentId: documentId,
                 signerEmail: templateDocument.Email,
                 redirectUrl: $"{this.Request.Scheme}://{this.Request.Host}/embeddedsign/response");
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                TemplateDetails = new TemplateDetails()
                {
                    SignLink = embeddedSigning.SignLink,
                    DocumentId = documentCreated.DocumentId
                },
                SamplesLists = SamplesList.GetAllSamplesList()
            };
            return Page();
        }
    }
}