using System;
using System.Collections.Generic;
using System.Text;

namespace Sedco.Products.TFSHelpers.WorkItemsDefinitions
{
    public interface IWorkItemSummary
    {
        /// <summary>
        /// work item ID
        /// </summary>
        int ID { get; }

        /// <summary>
        /// title of work item
        /// </summary>
        string Title { get; }

        /// <summary>
        /// description of work item (HTML)
        /// </summary>
        string DescriptionHTML { get; }

        /// <summary>
        /// list of comments inserted on work item.
        /// </summary>
        IEnumerable<HistoryComment> HistoryDiscussionComments { get; }

        /// <summary>
        /// current state of work item
        /// </summary>
        string State { get; }

        /// <summary>
        /// Attachments urls
        /// </summary>
        IEnumerable<string> AttachmentURLs { get; }

        /// <summary>
        /// Name of user who created the work item
        /// </summary>
        string CreatedBy { get; }

        /// <summary>
        /// Date of work item creation
        /// </summary>
        DateTime CreatedDate { get; }

        /// <summary>
        /// work item type (bug/task... etc)
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Project name
        /// </summary>
        string ProjectName { get; }

        /// <summary>
        /// Iteration Path
        /// </summary>
        string IterationPath { get; }

        /// <summary>
        /// Iteration ID
        /// </summary>
        int IterationID { get; }

        /// <summary>
        /// Area Path
        /// </summary>
        string AreaPath { get; }

        /// <summary>
        /// Area ID
        /// </summary>
        int AreaID { get; }

        /// <summary>
        /// Name of user currently assigned to
        /// </summary>
        string AssignedTo { get; }
    }

    public class HistoryComment
    {
        /// <summary>
        /// Date of inserting the comment
        /// </summary>
        public string CommentDate { get; set; }
        
        /// <summary>
        /// Name of user who added the comment
        /// </summary>
        public string CommenterName { get; set; }

        /// <summary>
        /// comment text
        /// </summary>
        public string CommentText { get; set; }
    }
}
