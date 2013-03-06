using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Net;
using System.Threading.Tasks;
using Bing;
using WebSearch.BL.Interfaces;

namespace WebSearch.BL.Classes
{
    /// <summary>
    ///     Main class to call bing service for searches
    /// </summary>
    public class BingSearch : BingBaseClass, IBingSearch
    {
        #region Cunstructor

        public BingSearch() : base(null)
        {
            Queries = new List<string>();
        }

        public BingSearch(Uri uri) : base(uri)
        {
            Queries = new List<string>();
        }

        #endregion

        #region Properties

        public List<string> Queries { get; set; }

        public ICredentials Credentials
        {
            set { base.Credentials = value; }
            get { return base.Credentials; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     method to call bing searches asynchronously
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(List<string> query)
        {
            if (query == null)
                FireQuerySearchExceptionEventAsync(null);

            for (int i = 0; i < query.Count; i++)
            {
                await QuerySearch(new QueryToSearch {Query = query[i]});
            }
        }

        #endregion

        #region Private Helping Methods

        /// <summary>
        ///     async method to send query to bing
        /// </summary>
        /// <param name="queryToSearch">pass query related info to bing</param>
        /// <returns></returns>
        private async Task QuerySearch(QueryToSearch queryToSearch)
        {
            await Task.Run(() =>
                {
                    //Fire event when search is about to start
                    FireQuerySearchStartingEventAsync(queryToSearch);

                    var searchedQuery = new SearchedQuery(queryToSearch.Query);
                    try
                    {
                        DataServiceQuery<ExpandableSearchResult> result = base.Composite("web", queryToSearch.Query,
                                                                                         null, null, null, null, null,
                                                                                         null, null, null, null, null,
                                                                                         null, null, null);
                        IEnumerable<ExpandableSearchResult> webResults = result.Execute();

                        foreach (ExpandableSearchResult r in webResults)
                        {
                            searchedQuery.Result.Add(new QueryResult {ID = r.ID, WebTotal = r.WebTotal});
                        }
                    }
                    catch (Exception ex)
                    {
                        searchedQuery.Exception = ex;
                        FireQuerySearchExceptionEventAsync(searchedQuery);
                    }

                    FireQuerySearchCompletedEventAsync(searchedQuery);
                });
        }

        #endregion

        #region Asynchronous Events

        /// <summary>
        ///     Asynchronous event that is fired before a query is searhed.
        /// </summary>
        public event EventHandler<QuerySearchStartingArgs> QuerySearchStartingAsync;

        /// <summary>
        ///     Asynchronous event that is fired when an individual query has been searched.
        /// </summary>
        public event EventHandler<QuerySearchCompletedArgs> QuerySearchCompletedAsync;

        /// <summary>
        ///     Asynchronous event that is fired when an individual query has been searched.
        /// </summary>
        public event EventHandler<QuerySearchExceptionArgs> QuerySearchExceptionAsync;

        private void OnQuerySearchStartingAsync(QuerySearchStartingArgs e)
        {
            EventHandler<QuerySearchStartingArgs> threadSafeEvent = QuerySearchStartingAsync;
            if (threadSafeEvent != null)
            {
                //Fire each subscribers delegate async
                foreach (EventHandler<QuerySearchStartingArgs> del in threadSafeEvent.GetInvocationList())
                {
                    del.BeginInvoke(this, e, null, null);
                }
            }
        }

        private void FireQuerySearchStartingEventAsync(QueryToSearch queryToSearch)
        {
            OnQuerySearchStartingAsync(new QuerySearchStartingArgs(queryToSearch));
        }

        private void FireQuerySearchCompletedEventAsync(SearchedQuery searchedQuery)
        {
            OnQuerySearchCompletedAsync(new QuerySearchCompletedArgs(searchedQuery));
        }

        private void OnQuerySearchCompletedAsync(QuerySearchCompletedArgs e)
        {
            EventHandler<QuerySearchCompletedArgs> threadSafeEvent = QuerySearchCompletedAsync;
            if (threadSafeEvent != null)
            {
                //Fire each subscribers delegate async
                foreach (EventHandler<QuerySearchCompletedArgs> del in threadSafeEvent.GetInvocationList())
                {
                    del.BeginInvoke(this, e, null, null);
                }
            }
        }

        private void FireQuerySearchExceptionEventAsync(SearchedQuery searchedQuery)
        {
            OnQuerySearchExceptionAsync(new QuerySearchExceptionArgs(searchedQuery));
        }

        private void OnQuerySearchExceptionAsync(QuerySearchExceptionArgs e)
        {
            EventHandler<QuerySearchExceptionArgs> threadSafeEvent = QuerySearchExceptionAsync;
            if (threadSafeEvent != null)
            {
                //Fire each subscribers delegate async
                foreach (EventHandler<QuerySearchExceptionArgs> del in threadSafeEvent.GetInvocationList())
                {
                    del.BeginInvoke(this, e, null, null);
                }
            }
        }

        #endregion
    }
}