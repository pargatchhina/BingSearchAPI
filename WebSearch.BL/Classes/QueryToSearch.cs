using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSearch.BL.Classes
{
    public class QueryToSearch
    {
        public QueryToSearch() { }
        public QueryToSearch(string query) { Query = query; }

        /// <summary>
        /// The query of search
        /// </summary>
        public string Query { get; set; }
        public String Sources {get;set;}
        public String Options {get;set;}
        public String WebSearchOptions {get;set;}
        public String Market {get;set;}
        public String Adult { get; set; }

    }
}
