using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Sedco.Products.TFSHelpers.WorkItemsDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedco.Products.TFSHelpers.WorkItemsDefaultExtractor
{
    internal class DefaultWorkItemSummary : WorkItemSummary
    {
        private WorkItem workItem { get; set; }
        private string assignedTo = String.Empty;
        private List<HistoryComment> historyComments = new List<HistoryComment>();
        private List<string> attachmentURLs = new List<string>();

        public DefaultWorkItemSummary(WorkItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            workItem = item;

            GetAssignedToField();
            GetHistoryComments();
            GetAttachmentURLs();
        }

        public override int ID 
        {
            get { return workItem.Id; }
        }

        public override string Title
        {
            get { return workItem.Title; }
        }

        public override string DescriptionHTML
        {
            get { return workItem.Description; }
        }
        
        public override string State
        {
            get { return workItem.State; }
        }
        
        public override string CreatedBy
        {
            get { return workItem.CreatedBy; }
        }

        public override DateTime CreatedDate
        {
            get { return workItem.CreatedDate; }
        }

        public override string Type
        {
            get { return workItem.Type.Name; }
        }

        public override string ProjectName
        {
            get { return workItem.Project.Name; }
        }

        public override string IterationPath
        {
            get { return workItem.IterationPath; }
        }

        public override int IterationID
        {
            get { return workItem.IterationId; }
        }

        public override string AreaPath
        {
            get { return workItem.AreaPath; }
        }

        public override int AreaID
        {
            get { return workItem.AreaId; }
        }

        public override string AssignedTo
        {
            get { return assignedTo; }
        }

        public override IEnumerable<HistoryComment> HistoryDiscussionComments
        { get { return historyComments; } }

        public override IEnumerable<string> AttachmentURLs
        { get { return attachmentURLs; } }

        private void GetAssignedToField()
        {
            try
            {
                Field assignedToField = workItem.Fields["Assigned To"];
                assignedTo = assignedToField.Value.ToString();
            }
            catch
            {
                //do nothing if assigned to field was not found
            }
        }

        private void GetHistoryComments()
        {
            HistoryComment comment;

            foreach (Revision revision in workItem.Revisions)
            {
                try
                { 
                    Field historyField = revision.Fields["History"];
                    Field changedByField = revision.Fields["Changed By"];
                    Field changedDateField = revision.Fields["Changed Date"];

                    if (String.IsNullOrEmpty(historyField.Value.ToString()) == false) //if there was a comment added in history
                    {
                        comment = new HistoryComment() { CommenterName = changedByField.Value.ToString(),
                            CommentText = historyField.Value.ToString(),
                            CommentDate = changedDateField.Value.ToString() };

                        historyComments.Add(comment);
                    }
                }
                catch
                {
                    //do nothing if fields were not found
                }
            }
        }

        private void GetAttachmentURLs()
        {
            if (workItem.Attachments != null)
            {
                foreach (Attachment attachment in workItem.Attachments)
                {
                    attachmentURLs.Add(attachment.Uri.ToString());
                }
            }
        }
    }
}
