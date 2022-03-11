using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoldSign.Demos.Models;
using BoldSign.Demos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoldSign.Demos.Pages.EmbeddedSample
{
    public class CompletedModel : PageModel
    {
        public BoldSignDemoViewModel BoldSignDemoViewModel { get; set; }
        public void OnGet(EmbeddedTemplate embeddedTemplate)
        {
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                EmbeddedTemplate = new EmbeddedTemplate()
                {
                    DocumentId = embeddedTemplate.DocumentId,
                    SignerEmail = embeddedTemplate.SignerEmail

                },
                SamplesLists = SamplesList.GetAllSamplesList()
            };
        }
    }   
}