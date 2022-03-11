using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BoldSign.Api;
using BoldSign.Demos.Models;
using BoldSign.Demos.ViewModel;
using BoldSign.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace BoldSign.Demos.Pages.TextTags
{
    public class CompletedModel : PageModel
    {
        public BoldSignDemoViewModel BoldSignDemoViewModel { get; set; }
        private readonly DocumentClient documentClient;

        public CompletedModel(DocumentClient documentClient)
        {
            this.documentClient = documentClient;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostCompletedAsync([FromForm(Name = "file")] IFormFile file)
        {
            // Please replace with your valid email address to get the signed document.
            var testEmail = "test@boldsign.dev";
            using var ms = new MemoryStream();

            var openReadStream = file.OpenReadStream();
            await openReadStream.CopyToAsync(ms);
            WordDocument document = new WordDocument(ms, FormatType.Automatic);
            Regex TagPatternRegex = new Regex(@"\{\{.*?\}\}");
            TextSelection[] textSelection = document.FindAll(TagPatternRegex);
            foreach (TextSelection selection in textSelection)
            {
                IWTextRange textRange = selection.GetAsOneRange();
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.White;
            }
            document.Save(ms, FormatType.Docx);
            ms.Position = 0;
            document.Close();

            var documentDetails = new SendForSign
            {
                Title = "Test Tags",
                Message = "This is document message sent from API SDK",
                Signers = new List<DocumentSigner>
                {
                    new DocumentSigner(
                        name: "Test",
                        // Please replace with your valid email address to get the signed document.
                        emailAddress: testEmail,
                        signerType: SignerType.Signer,
                        signerOrder: 1),
                },
                ExpiryDays = 30,
                UseTextTags = true,
            };

            documentDetails.Files = new List<IDocumentFile>
        {
            new DocumentFileBytes()
                    {
                        FileData = ms.ToArray(),
                        FileName = "text.docx",
                        ContentType = file.ContentType,
                    },
        };

            DocumentCreated documentCreated = await this.documentClient.SendDocumentAsync(documentDetails).ConfigureAwait(false);
            await Task.Delay(5000).ConfigureAwait(false);
            try
            {
                await this.documentClient.GetPropertiesAsync(documentCreated.DocumentId).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                await Task.Delay(10000).ConfigureAwait(false);
            }
            EmbeddedSigningLink embeddedSigning = this.documentClient.GetEmbeddedSignLink(
                 documentId: documentCreated.DocumentId,
                 signerEmail: testEmail,
                 redirectUrl: $"https://{this.Request.Host}/texttags/response?documentId={documentCreated.DocumentId}");
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
