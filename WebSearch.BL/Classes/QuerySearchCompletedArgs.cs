using System;

namespace WebSearch.BL.Classes
{
    public class QuerySearchCompletedArgs : EventArgs
    {
        public QuerySearchCompletedArgs(SearchedQuery searchedQuery)
        {
            if (searchedQuery == null)
                throw new ArgumentNullException("searchedQuery");

            SearchedQuery = searchedQuery;
        }

        public SearchedQuery SearchedQuery { get; private set; }
    }
}