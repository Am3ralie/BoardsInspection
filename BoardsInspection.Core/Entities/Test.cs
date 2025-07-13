using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsInspection.Core.Entities
{
    public class Test
    {
        public int Id { get; set; }

        public int ProductId { get; set; } // внешний ключ на Product

        public string Type { get; set; } = null!;

        public string Responsible { get; set; } = null!;

        public string Result { get; set; } = null!;
    }
}
