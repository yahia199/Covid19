using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19_LTUC_Task.Models
{
    public class Record
    {
        public Guid ID { get; set; }
        public string Message { get; set; }
        public Global Global { get; set; }
        public List<Countries> Countries { get; set; }
        public DateTime Date { get; set; }
    }
}
