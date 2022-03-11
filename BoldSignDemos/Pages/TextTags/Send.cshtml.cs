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

namespace BoldSign.Demos.Pages.TextTags
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

        public async Task<IActionResult> OnPostSendAsync()
        {
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                DocumentDetails = new DocumentDetails()
                {
                    Name = "Test",
                    // Please replace with your valid email address to get the signed document.
                    Email = "test@boldsign.dev",
                },
                SamplesLists = SamplesList.GetAllSamplesList()
            };
            return Page();
        }
    }
}
