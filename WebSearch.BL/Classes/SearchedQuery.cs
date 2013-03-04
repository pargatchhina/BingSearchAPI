using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Net;

namespace WebSearch.BL.Classes
{
    public class SearchedQuery : QueryToSearch
    {
        public SearchedQuery(string query) : base(query) {
            Result = new List<QueryResult>();
        }

        /// <summary>
        /// The raw content of the request
        /// </summary>
        public List<QueryResult> Result { get; set; }

        /// <summary>
        /// The web exception that occurred during the crawl
        /// </summary>
        public Exception Exception { get; set; }

    }
}
