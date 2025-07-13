using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsInspection.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public int TestId { get; set; } // внешний ключ на Test

        public string EventResult { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Place { get; set; } = null!;
    }
}
