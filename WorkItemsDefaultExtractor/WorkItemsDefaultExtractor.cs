using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Sedco.Products.TFSHelpers.WorkItemsDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedco.Products.TFSHelpers.WorkItemsDefaultExtractor
{
    public class WorkItemsExtractor : IWorkItemsExtractor
    {
        private WorkItemStore store;
        private string url = String.Empty;

        public WorkItemsExtractor()
        {
            
        }

        public string TfsURL
        {
            get
            {
                return url;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("TfsURL");
                }

                url = value;

                // Connect to TFS
                var tfs =
                    TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
                        new Uri(url));

                // Get the work item store service
                store = tfs.GetService<WorkItemStore>();
            }
        }

        public IWorkItemSummary GetWorkItemById(int workItemId)
        {
            try
            {
                WorkItem workItem = store.GetWorkItem(workItemId);

                DefaultWorkItemSummary item = new DefaultWorkItemSummary(workItem);
                return item;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Make sure you set TfsURL before calling this method, and that workItemId is valid. Check inner exception for more details.", ex);
                throw exception;
            }
        }

        public IEnumerable<IWorkItemSummary> GetWorkItemsByQueryText(string query)
        {
            try
            {
                WorkItemCollection workItemCollection = store.Query(query);
                List<IWorkItemSummary> result = new List<IWorkItemSummary>();

                foreach (WorkItem workItem in workItemCollection)
                {
                    result.Add(new DefaultWorkItemSummary(workItem));
                }

                return result;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Make sure you set TfsURL before calling this method, and that the query is valid. Check inner exception for more details.", ex);
                throw exception;
            }
        }

        public IEnumerable<IWorkItemSummary> GetWorkItemsBySavedQuery(string projectName, string queryFolderName, string queryName)
        {
            try
            {
                QueryHierarchy queryRoot = store.Projects[projectName].QueryHierarchy;
                QueryFolder folder = (QueryFolder)queryRoot[queryFolderName];
                QueryDefinition query1 = (QueryDefinition)folder[queryName];
                WorkItemCollection queryResultsqueryResults = store.Query(query1.QueryText);
                List<IWorkItemSummary> result = new List<IWorkItemSummary>();

                foreach (WorkItem workItem in queryResultsqueryResults)
                {
                    result.Add(new DefaultWorkItemSummary(workItem));
                }

                return result;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Make sure you set TfsURL before calling this method, and that the query is valid. Check inner exception for more details.", ex);
                throw exception;
            }
        }

        public List<string> GetAvailableProjects()
        {
            List<string> result = new List<string>();
            try
            {
                foreach (Project project in store.Projects)
                {
                    result.Add(project.Name);
                }

                return result;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Make sure you set TfsURL before calling this method, and that the query is valid. Check inner exception for more details.", ex);
                throw exception;
            }
        }

        public List<string> GetAvailableQueryFolders(string projectName)
        {
            List<string> result = new List<string>();
            try
            {
                QueryHierarchy queryRoot = store.Projects[projectName].QueryHierarchy;

                foreach (QueryFolder folder in queryRoot)
                {
                    result.Add(folder.Name);
                }

                return result;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Make sure you set TfsURL before calling this method, and that the query is valid. Check inner exception for more details.", ex);
                throw exception;
            }
        }

        public List<string> GetAvailableQueries(string projectName, string queryFolderName)
        {
            List<string> result = new List<string>();
            try
            {
                QueryHierarchy queryRoot = store.Projects[projectName].QueryHierarchy;
                QueryFolder folder = (QueryFolder)queryRoot[queryFolderName];

                foreach (QueryDefinition query in folder)
                {
                    result.Add(query.Name);
                }

                return result;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Make sure you set TfsURL before calling this method, and that the query is valid. Check inner exception for more details.", ex);
                throw exception;
            }
        }
    }
}
