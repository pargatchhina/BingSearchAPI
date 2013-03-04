using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSearch.BL.Classes
{
    public class QuerySearchCompletedArgs : EventArgs
    {
        public SearchedQuery SearchedQuery { get; private set; }

        public QuerySearchCompletedArgs(SearchedQuery searchedQuery)
        {
            if (searchedQuery == null)
                throw new ArgumentNullException("searchedQuery");

            SearchedQuery = searchedQuery;
        }
    }
}
