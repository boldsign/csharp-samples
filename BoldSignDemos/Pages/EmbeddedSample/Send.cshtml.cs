using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoldSign.Api;
using BoldSign.Demos.Models;
using BoldSign.Demos.ViewModel;
using BoldSign.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoldSign.Demos.Pages.EmbeddedSample
{
    public class SendModel : PageModel
    {
        private readonly DocumentClient documentClient;
        private readonly TemplateClient templateClient;
        public SendModel(DocumentClient documentClient, TemplateClient templateClient)
        {
            this.documentClient = documentClient;
            this.templateClient = templateClient;
        }

        public BoldSignDemoViewModel BoldSignDemoViewModel { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostSendAsync(EmbeddedTemplate templateDocument)
        {

            var embeddedTemplateRequest = new EmbeddedTemplateRequest()
            {
                TemplateId = templateDocument.TemplateId,
                Title = "Affidavit of Residence",
                Roles = new List<Roles>()
                {
                    new Roles
                    {
                        SignerName = templateDocument.SignerName,
                        SignerEmail = templateDocument.SignerEmail,
                        RoleIndex = 1,
                        SignerType = SignerType.Signer,
                        ExistingFormFields = new List<ExistingFormField>()
                        {
                            new ExistingFormField()
                            {
                                Id = "SignerName",
                                Value = templateDocument.SignerName,
                            },
                            new ExistingFormField()
                            {
                                Id = "SignerAddress",
                                Value = templateDocument.PostalAddress,
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

                    },
                },
                ShowToolbar = true,
                ShowSendButton = true,
                ShowPreviewButton = true,
                ShowSaveButton = true,

                RedirectUrl = new System.Uri($"https://{this.Request.Host}/embeddedsample/response/"),
        
            };

            EmbeddedSendCreated documentCreated = null;
            try
            {
                documentCreated = await this.templateClient.CreateEmbeddedRequestUrlAsync(embeddedTemplateRequest).ConfigureAwait(false);
            }
            catch (ApiException ex)
            {
                throw new Exception(ex.Message);
            }
                      
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                EmbeddedTemplate = new EmbeddedTemplate()
                {
                    SignLink = documentCreated.SendUrl,
                    DocumentId = documentCreated.DocumentId,
                    SignerEmail = templateDocument.SignerEmail
                },
                SamplesLists = SamplesList.GetAllSamplesList()
            };
            return Page();
        }
    }
}
