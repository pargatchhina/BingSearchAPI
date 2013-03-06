using System;

namespace WebSearch.BL.Classes
{
    public class QuerySearchExceptionArgs : EventArgs
    {
        public QuerySearchExceptionArgs(SearchedQuery searchedQuery)
        {
            if (searchedQuery == null)
            {
                searchedQuery = new SearchedQuery(null);
                searchedQuery.Exception = new ArgumentNullException("searchedQuery");
            }
            SearchedQuery = searchedQuery;
        }

        public SearchedQuery SearchedQuery { get; private set; }
    }
}