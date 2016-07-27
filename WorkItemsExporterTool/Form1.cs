using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using Sedco.Products.TFSHelpers.WorkItemsDefinitions;
using Sedco.Products.TFSHelpers.WorkItemsDefaultExtractor;
using Sedco.Products.TFSHelpers.WorkItemsExporterTool;

namespace Sedco.Products.TFSHelpers.WorkItemsExporterTool
{
    public partial class Form1 : Form
    {
        private bool isTfsUrlChanged = true;
        private bool selectedProjectChanged = false;
        private bool selectedFolderChanged = false;
        IWorkItemsExtractor extractor = new WorkItemsExtractor();

        public Form1()
        {
            InitializeComponent();
        }

        private void ExportList(IEnumerable<IWorkItemSummary> itemList)
        {
            if (itemList != null && itemList.Count() > 0)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "Choose where to save work items summary";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        NetworkCredential credentials = new NetworkCredential(userTextBox.Text, passwordTextBox.Text, domainTextBox.Text);
                        HTMLPagesCreationHelper.SaveItemsSummary(itemList, dialog.SelectedPath, Environment.CurrentDirectory, credentials);
                        MessageBox.Show("Saving completed");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong!. Here is the exception details: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No items were retrieved! Please double check the tfs url, query text, or work item id.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tfsUrlTextBox.KeyUp += tfsUrlTextBox_KeyUp;
            foldersComboBox.Click += foldersComboBox_Click;
            queryComboBox.Click += queryComboBox_Click;

            if (!String.IsNullOrEmpty(tfsUrlTextBox.Text.Trim()))
            {
                savedQueryRadioButton.Checked = true;
                savedQueryRadioButton.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
        }

        private void tfsUrlTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            isTfsUrlChanged = true;

            if (String.IsNullOrEmpty(tfsUrlTextBox.Text))
            {
                exportButton.Enabled = false;
                savedQueryRadioButton.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                itemIdTextBox.Enabled = false;
                queryTextBox.Enabled = false;
                queryComboBox.Enabled = false;
                projectsComboBox.Enabled = false;
                foldersComboBox.Enabled = false;
                savedQueryRadioButton.Checked = false;
            }
            else
            {
                exportButton.Enabled = true;
                savedQueryRadioButton.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                savedQueryRadioButton.Checked = true;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            UpdateTFSExtractorURL();
            
            if (radioButton1.Checked)
            {
                IWorkItemSummary item = null; 

                try
                {
                    item = extractor.GetWorkItemById(Convert.ToInt32(itemIdTextBox.Text.Trim()));
                }
                catch(Exception ex)
                {
                    string message = ex.Message;
                    if (ex.InnerException != null)
                    {
                        message += ex.InnerException.Message;
                    }

                    MessageBox.Show("No items were retrieved! Please double check the tfs url, query text, or work item id. " + message);
                }

                List<IWorkItemSummary> list = new List<IWorkItemSummary>();
                
                if (item != null)
                {
                    list.Add(item);
                }
                
                ExportList(list);
            }
            else if ((radioButton2.Checked))
            {
                IEnumerable<IWorkItemSummary> itemList = null;
                
                try
                {
                    itemList = extractor.GetWorkItemsByQueryText(queryTextBox.Text);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    if (ex.InnerException != null)
                    {
                        message += ex.InnerException.Message;
                    }

                    MessageBox.Show("No items were retrieved! Please double check the tfs url, query text, or work item id. " + message);
                }

                ExportList(itemList);
            }
            else if ((savedQueryRadioButton.Checked))
            {
                IEnumerable<IWorkItemSummary> itemList = null;

                try
                {
                    itemList = extractor.GetWorkItemsBySavedQuery(projectsComboBox.Text, foldersComboBox.Text, queryComboBox.Text);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    if (ex.InnerException != null)
                    {
                        message += ex.InnerException.Message;
                    }

                    MessageBox.Show("No items were retrieved! Please double check the tfs url, query text, or work item id. " + message);
                }

                ExportList(itemList);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tfsUrlTextBox.Text.Trim()))
            {
                itemIdTextBox.Enabled = true;
                queryTextBox.Enabled = false;

                projectsComboBox.Enabled = false;
                foldersComboBox.Enabled = false;
                queryComboBox.Enabled = false;

                exportButton.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tfsUrlTextBox.Text.Trim()))
            {
                itemIdTextBox.Enabled = false;
                queryTextBox.Enabled = true;

                projectsComboBox.Enabled = false;
                foldersComboBox.Enabled = false;
                queryComboBox.Enabled = false;

                exportButton.Enabled = true;
            }
        }

        private void savedQueryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTFSExtractorURL();

            if (!String.IsNullOrEmpty(tfsUrlTextBox.Text.Trim()))
            {
                itemIdTextBox.Enabled = false;
                queryTextBox.Enabled = false;

                projectsComboBox.Enabled = true;
                foldersComboBox.Enabled = true;
                queryComboBox.Enabled = true;

                exportButton.Enabled = true;

                FillProjectsComboBox();
            }
        }

        void queryComboBox_Click(object sender, EventArgs e)
        {
            if (selectedFolderChanged)
            {
                FillQueryComboBox();
                selectedFolderChanged = false;
            }
            
        }

        void foldersComboBox_Click(object sender, EventArgs e)
        {
            if (selectedProjectChanged)
            {
                FillFoldersComboBox();
                selectedProjectChanged = false;
            }
        }

        private void FillProjectsComboBox()
        {
            List<string> projects = extractor.GetAvailableProjects();

            projectsComboBox.DisplayMember = "Name";
            projectsComboBox.ValueMember = "Name";

            projectsComboBox.Items.Clear();

            if (projects.Count > 0)
            {
                projectsComboBox.Enabled = true;

                foreach (string project in projects)
                {
                    projectsComboBox.Items.Add(new Item(project));
                }
            }
        }

        private void FillFoldersComboBox()
        {
            List<string> folders = extractor.GetAvailableQueryFolders(projectsComboBox.Text);

            foldersComboBox.DisplayMember = "Name";
            foldersComboBox.ValueMember = "Name";

            foldersComboBox.Items.Clear();

            if (folders.Count > 0)
            {
                queryComboBox.Enabled = true;
                foldersComboBox.Enabled = true;

                foreach (string folder in folders)
                {
                    foldersComboBox.Items.Add(new Item(folder));
                }
            }

        }

        private void FillQueryComboBox()
        {
            List<string> queries = extractor.GetAvailableQueries(projectsComboBox.Text, foldersComboBox.Text);

            queryComboBox.DisplayMember = "Name";
            queryComboBox.ValueMember = "Name";

            queryComboBox.Items.Clear();

            foreach (string query in queries)
            {
                queryComboBox.Items.Add(new Item(query));
            }
        }

        private void UpdateTFSExtractorURL()
        {
            if (isTfsUrlChanged)
            {
                try
                {
                    extractor.TfsURL = tfsUrlTextBox.Text;
                    isTfsUrlChanged = false;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Please double check the tfs url! " + ex.Message);
                    return;
                }
            }
        }

        private void projectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProjectChanged = true;
        }

        private void foldersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFolderChanged = true;
        }
    }

    class Item 
    {
          public string Name {get; set;}

          public Item(string name) 
          {
              Name = name;
          }
    }
}
