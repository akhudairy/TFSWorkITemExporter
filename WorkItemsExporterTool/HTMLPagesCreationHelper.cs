using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Sedco.Products.TFSHelpers.WorkItemsDefinitions;
using System.Windows.Forms;

namespace Sedco.Products.TFSHelpers.WorkItemsExporterTool
{
    public class HTMLPagesCreationHelper
    {
        public static void SaveItemsSummary(IEnumerable<IWorkItemSummary> itemList, string outputPath, string templateDirectory, ICredentials credentials)
        {
            templateDirectory = templateDirectory += "\\HTML";
            CopyTemplateFiles(outputPath, templateDirectory);
            CreateMasterHTMLPage(itemList, outputPath, templateDirectory);

            foreach(IWorkItemSummary item in itemList)
            {
                CreateItemHTMLPage(item, outputPath, templateDirectory);
                DownloadItemAttachments(item, outputPath, credentials);
            }
        }

        private static void CopyTemplateFiles(string outputPath, string templateDirectory)
        {
            string[] fileNames = Directory.GetFiles(templateDirectory);

            foreach(string file in fileNames)
            {
                if (!file.EndsWith(".html"))
                {
                    File.Copy(file, Path.Combine(outputPath, Path.GetFileName(file)), true);
                }
            }
        }

        private static void CreateItemHTMLPage(IWorkItemSummary item, string outputPath, string templateDirectory)
        {
            string pageContent = File.ReadAllText(Path.Combine(templateDirectory, "WorkItemPage.html"));

            pageContent = pageContent.Replace("[AssignedTo]", item.AssignedTo);
            pageContent = pageContent.Replace("[ID]", item.ID.ToString());
            pageContent = pageContent.Replace("[Title]", item.Title);
            pageContent = pageContent.Replace("[Type]", item.Type);
            pageContent = pageContent.Replace("[State]", item.State);
            pageContent = pageContent.Replace("[Description]", item.DescriptionHTML);
            pageContent = pageContent.Replace("[CreatedBy]", item.CreatedBy);
            pageContent = pageContent.Replace("[CreatedDate]", item.CreatedDate.ToString());
            pageContent = pageContent.Replace("[ProjectName]", item.ProjectName);
            pageContent = pageContent.Replace("[IterationID]", item.IterationID.ToString());
            pageContent = pageContent.Replace("[IterationPath]", item.IterationPath);
            pageContent = pageContent.Replace("[AreaID]", item.AreaID.ToString());
            pageContent = pageContent.Replace("[AreaPath]", item.AreaPath);
            pageContent = pageContent.Replace("[Attachemtns]", GetAttachmentsHTML(item, File.ReadAllText(Path.Combine(templateDirectory, "AttachmentTemplate.html"))));
            pageContent = pageContent.Replace("[History]", GetHistoryCommentsHTML(item, File.ReadAllText(Path.Combine(templateDirectory, "HistoryCommentTemplate.html"))));

            File.WriteAllText(Path.Combine(outputPath, item.ID + ".html"), pageContent);
        }

        private static void DownloadItemAttachments(IWorkItemSummary item, string outputPath, ICredentials credentials)
        {
            if (item.AttachmentURLs.Count() > 0)
            {
                Directory.CreateDirectory(Path.Combine(outputPath, item.ID.ToString()));
            }

            foreach (string attachment in item.AttachmentURLs)
            {
                int failedDownload = 0;
                string attachmentName = GetAttachmentName(attachment);
                string fileName = Path.Combine(outputPath, item.ID + "\\" + attachmentName);
                try
                { 
                    using (var client = new WebClient())
                    {
                        client.Credentials = credentials;
                        client.DownloadFile(attachment, fileName);
                    }
                }
                catch (Exception ex)
                {
                    failedDownload++;
                    if (failedDownload < 3)
                    {
                        string message = ex.Message;
                        if (ex.InnerException != null)
                        {
                            message += ". " + ex.InnerException.Message;
                        }

                        MessageBox.Show("Error while downloading '" + "" + "'. Details: " + message + Environment.NewLine + Environment.NewLine + "If you have 'Fiddler' installed on this machine, try to run it and try again.");
                    }
                }
            }
        }

        private static void CreateMasterHTMLPage(IEnumerable<IWorkItemSummary> itemList, string outputPath, string templateDirectory)
        {
            string pageContent = File.ReadAllText(Path.Combine(templateDirectory, "SummaryPage.html"));
            string workItems = String.Empty;

            foreach (IWorkItemSummary summary in itemList)
            {
                workItems += GetItemSummary(summary, File.ReadAllText(Path.Combine(templateDirectory, "WorkItemTemplate.html")));
            }

            pageContent = pageContent.Replace("[WorkItems]", workItems);
            pageContent = pageContent.Replace("[Date]", DateTime.Now.ToString());

            File.WriteAllText(Path.Combine(outputPath, "index.html"), pageContent);
        }

        private static string GetAttachmentsHTML(IWorkItemSummary item, string attachmentHTML)
        {
            string result = String.Empty;
            
            foreach(string attachment in item.AttachmentURLs)
            {
                string attachmentName = GetAttachmentName(attachment);
                string tempHTML = attachmentHTML.Replace("[AttachmentText]", attachmentName);
                tempHTML = tempHTML.Replace("[AttachmentURL]", item.ID + "\\" + attachmentName);
                result += tempHTML;
            }

            return result;
        }

        private static string GetHistoryCommentsHTML(IWorkItemSummary item, string historyHTML)
        {
            string result = String.Empty;

            foreach (HistoryComment comment in item.HistoryDiscussionComments)
            {
                string tempHTML = historyHTML.Replace("[CommentDate]", comment.CommentDate);
                tempHTML = tempHTML.Replace("[CommenterName]", comment.CommenterName);
                tempHTML = tempHTML.Replace("[CommentText]", comment.CommentText);
                result += tempHTML;
            }

            return result;
        }

        private static string GetItemSummary(IWorkItemSummary item, string summaryHTML)
        {
            summaryHTML = summaryHTML.Replace("[ID]", item.ID.ToString());
            summaryHTML = summaryHTML.Replace("[State]", item.State);
            summaryHTML = summaryHTML.Replace("[Title]", item.Title);
            summaryHTML = summaryHTML.Replace("[CreatedDate]", item.CreatedDate.ToString());
            summaryHTML = summaryHTML.Replace("[AssignedTo]", item.AssignedTo);

            return summaryHTML;
        }

        private static string GetAttachmentName(string url)
        {
            int startIndex = url.IndexOf("FileName=") + 9;

            return url.Substring(startIndex);
        }
    }
}
