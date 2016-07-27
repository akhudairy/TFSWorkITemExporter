using System;
using System.Collections.Generic;
using System.Text;

namespace Sedco.Products.TFSHelpers.WorkItemsDefinitions
{
    public interface IWorkItemsExtractor
    {
        /// <summary>
        /// gets or sets the TFS url
        /// </summary>
        string TfsURL { get; set; }

        /// <summary>
        /// gets a work item by id
        /// </summary>
        /// <param name="id">id of work item</param>
        /// <returns>work items list</returns>
        IWorkItemSummary GetWorkItemById(int id);

        /// <summary>
        /// gets work items by using query text
        /// </summary>
        /// <param name="query">the select statement</param>
        /// <returns>work items list</returns>
        IEnumerable<IWorkItemSummary> GetWorkItemsByQueryText(string query);

        /// <summary>
        /// gets work items by running a saved query
        /// </summary>
        /// <param name="projectName">project name</param>
        /// <param name="queryFolderName">query folder name</param>
        /// <param name="queryName">query name</param>
        /// <returns>work items list</returns>
        IEnumerable<IWorkItemSummary> GetWorkItemsBySavedQuery(string projectName, string queryFolderName, string queryName);

        /// <summary>
        /// get list of all available projects
        /// </summary>
        /// <returns>array of project names</returns>
        List<string> GetAvailableProjects();

        /// <summary>
        /// get list of all available query folders under a project
        /// </summary>
        /// <param name="projectName">project name</param>
        /// <returns>array of project names</returns>
        List<string> GetAvailableQueryFolders(string projectName);

        /// <summary>
        /// get list of all available queries
        /// </summary>
        /// <param name="projectName">project name</param>
        /// <param name="queryFolderName">query folder name</param>
        /// <returns>array of available queries names</returns>
        List<string> GetAvailableQueries(string projectName, string queryFolderName);
    }
}
