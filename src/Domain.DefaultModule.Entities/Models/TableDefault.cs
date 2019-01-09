using System;
using System.Collections.Generic;

namespace Domain.DefaultModule.Entities.Models
{
    public partial class TableDefault
    {
        public TableDefault()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
    }
}
