using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSearch.BL.Classes
{
    public class QuerySearchExceptionArgs : EventArgs
    {
        public SearchedQuery SearchedQuery { get; private set; }

        public QuerySearchExceptionArgs(SearchedQuery searchedQuery)
        {
            if (searchedQuery == null)
            {
                searchedQuery = new SearchedQuery(null);
                searchedQuery.Exception = new ArgumentNullException("searchedQuery");
            }
            SearchedQuery = searchedQuery;
        }
    }
}
