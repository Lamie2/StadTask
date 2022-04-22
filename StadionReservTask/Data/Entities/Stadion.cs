using System;
using System.Collections.Generic;
using System.Text;

namespace StadionReservTask.Data.Entities
{
    class Stadion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourPrice { get; set; }
        public int Capacity { get; set; }
    }
}
