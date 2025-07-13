using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsInspection.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string SerialNumber { get; set; } = null!;

        public DateTime ProductionDate { get; set; }
    }
}
