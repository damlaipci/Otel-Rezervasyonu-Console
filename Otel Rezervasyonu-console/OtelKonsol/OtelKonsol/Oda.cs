using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{

    abstract class Oda
    {
        public class Day
        {
            public string musteriTc { get; set; }
            public DateTime date;
            public bool rezeverMi;
            public double ucret;

            public Day(DateTime date, bool rezeverMi, double ucret)
            {
                this.date = date;
                this.rezeverMi = rezeverMi;
                this.ucret = ucret;
            }

        }
        protected int odaNumaralari { get; set; }
        protected string yatakCesidi { get; set; }
        protected string manzaraTipi { get; set; }
        public List<Day> takvim { get; set; }


    }
}

