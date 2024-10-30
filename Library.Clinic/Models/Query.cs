using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Models
{
    public class Query
    {
        public string? Content { get; set; }

        public Query(string content)
        {
            this.Content = content;
        }
    }
}
