using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoldSign.Demos.Models;
using BoldSign.Demos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoldSign.Demos.Pages.TemplateDocument
{
    public class IndexModel : PageModel
    {
        public BoldSignDemoViewModel BoldSignDemoViewModel { get; set; }
        public void OnGet()
        {
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                SamplesLists = SamplesList.GetAllSamplesList()
            };
        }
    }
}
