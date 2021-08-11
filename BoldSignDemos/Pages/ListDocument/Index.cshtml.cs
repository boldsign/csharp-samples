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
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BoldSign.Demos.Pages.ListDocument
{
    public class IndexModel : PageModel
    {
        public BoldSignDemoViewModel BoldSignDemoViewModel { get; set; }
        public int pageNumber { get; set; }
        public string SearchTerm { get; set; }
        public List<DocumentStatus> Status { get; set; }
        private readonly DocumentClient documentClient;
        public IndexModel(DocumentClient documentClient)
        {
            this.documentClient = documentClient;
        }
        public void OnGet(string SearchTerm, List<DocumentStatus> Status, int pageNumber = 1)
        {
            var status = new List<Status>();
            foreach (var docStatus in Status)
            {
                status.AddRange(this.GetStatus(docStatus));
            }
            var documentRecords = this.documentClient.ListDocuments(page: pageNumber, pageSize: 20, searchKey: SearchTerm, status: status);
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                SamplesLists = SamplesList.GetAllSamplesList(),
                DocumentRecords = documentRecords
            };
        }

        public PartialViewResult OnGetProperties(string documentId)
        {
            var documentProperties = this.documentClient.GetProperties(documentId);
            BoldSignDemoViewModel = new BoldSignDemoViewModel()
            {
                SamplesLists = SamplesList.GetAllSamplesList(),
                DocumentProperties = documentProperties
            };
            return new PartialViewResult
            {
                ViewName = "GetDocumentProperties",
                ViewData = new ViewDataDictionary<BoldSignDemoViewModel>(ViewData, BoldSignDemoViewModel)
            };
        }

        private List<Status> GetStatus(DocumentStatus documentStatus)
        {
            return documentStatus switch
            {
                DocumentStatus.Completed => new List<Status>() { Model.Status.Completed },
                DocumentStatus.Declined => new List<Status>() { Model.Status.Declined },
                DocumentStatus.Expired => new List<Status>() { Model.Status.Expired },
                DocumentStatus.Revoked => new List<Status>() { Model.Status.Revoked },
                DocumentStatus.InProgress => new List<Status>() { Model.Status.WaitingForMe, Model.Status.WaitingForOthers, Model.Status.NeedAttention },
                DocumentStatus.Draft => new List<Status>() { Model.Status.None },
                _ => new List<Status>() { Model.Status.None },
            };
        }
    }
}
