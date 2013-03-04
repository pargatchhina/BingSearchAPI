using System;

namespace WebSearch.BL.Classes
{
    public class QuerySearchStartingArgs : EventArgs
    {
        public QueryToSearch QueryToSearch { get; private set; }

        public QuerySearchStartingArgs(QueryToSearch queryToSearch)
        {
            if (queryToSearch == null)
                throw new ArgumentNullException("queryToSearch");

            QueryToSearch = queryToSearch;
        }
    }
}
