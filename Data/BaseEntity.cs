using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUW.Core.Data
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string IP { get; set; }
    }
}