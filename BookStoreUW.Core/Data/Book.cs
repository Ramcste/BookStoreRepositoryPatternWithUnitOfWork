using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUW.Core.Data
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string  ISBN { get; set; }

        public DateTime Published { get; set; }
    }
}