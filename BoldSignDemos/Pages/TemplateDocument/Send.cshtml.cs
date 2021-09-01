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

namespace BoldSign.Demos.Pages.TemplateDocument
{
    public class SendModel : PageModel
    {
        public BoldSignDemoViewModel BoldSignDemoViewModel { get; set; }
        private readonly TemplateClient templateClient;
        public SendModel(TemplateClient templateClient)
        {
            this.templateClient = templateClient;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSendAsync(TemplateDetails templateDetails)
        {
            var sendForSignFromTemplate = new SendForSignFromTemplate(
                templateId: templateDetails.TemplateId,
                roles: new List<Roles>()
                {
                    new Roles
                    {
                        SignerName = templateDetails.Name,
                        SignerEmail = templateDetails.Email,
                        RoleIndex = 1,
                        SignerType = SignerType.Signer,
                        ExistingFormFields = new List<ExistingFormField>()
                        {
                            new ExistingFormField()
                            {
                                Name = "SignerName",
                                Value = templateDetails.Name,
                            },
                            new ExistingFormField()
                            {
                                Name = "SignerEmail",
                                Value = templateDetails.Email,
                            }
                        }
                    }
                });
            DocumentCreated documentCreated = null;
            try
            {
                documentCreated = await this.templateClient.SendUsingTemplateAsync(sendForSignFromTemplate);
            }
            catch (ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                TemplateDetails = new TemplateDetails() { DocumentId = documentCreated.DocumentId, Email = templateDetails.Email },
                SamplesLists = SamplesList.GetAllSamplesList()
            };
            return Page();
        }
    }
}