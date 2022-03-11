using BoldSign.Model;
using BoldSign.Demos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoldSign.Demos.ViewModel
{
    public class BoldSignDemoViewModel
    {
        public IEnumerable<SamplesList> SamplesLists { get; set; }

        public CreateDocument CreateDocument { get; set; }

        public DocumentDetails DocumentDetails { get; set; }

        public DocumentRecords DocumentRecords { get; set; }

        public TemplateDetails TemplateDetails { get; set; }

        public DocumentProperties DocumentProperties { get; set; }

        public EmbeddedTemplate EmbeddedTemplate { get; set; }
    }
}
