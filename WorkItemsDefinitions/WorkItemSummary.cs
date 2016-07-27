using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedco.Products.TFSHelpers.WorkItemsDefinitions
{
    public class WorkItemSummary : IWorkItemSummary
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string DescriptionHTML { get; set; }
        public virtual IEnumerable<HistoryComment> HistoryDiscussionComments { get; set; }
        public virtual string State { get; set; }
        public virtual IEnumerable<string> AttachmentURLs { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string Type { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual string IterationPath { get; set; }
        public virtual int IterationID { get; set; }
        public virtual string AreaPath { get; set; }
        public virtual int AreaID { get; set; }
        public virtual string AssignedTo { get; set; }
    }
}
