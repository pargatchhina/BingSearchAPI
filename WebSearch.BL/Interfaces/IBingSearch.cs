using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSearch.BL.Classes;

namespace WebSearch.BL.Interfaces
{
    public interface IBingSearch
    {
        /// <summary>
        /// Asynchronous event that is fired before a query to bing.
        /// </summary>
        event EventHandler<QuerySearchStartingArgs> QuerySearchStartingAsync;

        /// <summary>
        /// Asynchronous event that is fired when an individual query has been searched.
        /// </summary>
        event EventHandler<QuerySearchCompletedArgs> QuerySearchCompletedAsync;

        /// <summary>
        /// Asynchronous event that is fired when an individual query has been searched with exception.
        /// </summary>
        event EventHandler<QuerySearchExceptionArgs> QuerySearchExceptionAsync;

    }
}
