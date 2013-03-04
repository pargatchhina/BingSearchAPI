using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSearch.BL.Classes
{
    /// <summary>
    /// it holds the result returned from bing using Composite method
    /// </summary>
    public class QueryResult
    {
        #region Cunstructor

        public QueryResult() { }
        
        #endregion

        #region Properites

        /// <summary>
        /// GUID
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// WebTotal
        /// </summary>
        public long? WebTotal { get; set; }

        #endregion
    }
}
