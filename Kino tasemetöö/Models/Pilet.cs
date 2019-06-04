using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kino_tasemetöö.Models
{
    public class Pilet
    {
        public int Id { get; set; }
        public KinoModels Film { get; set; }
        public string PiletiNr { get; set; }
    }
}