using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kino_tasemetöö.Models
{
    public class KinoModels
    {
        public int Id { get; set; }
        public string Film { get; set; }
        public int Kestuvus { get; set; }
        public int Saal { get; set; }
        public DateTime Algus { get; set; }
    }
}