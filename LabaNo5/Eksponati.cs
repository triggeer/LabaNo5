using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNo5
{
    public class Eksponati
    {
        public int EkspId {  get; set; }
        public string EkspName { get; set; }
        public string Epoha { get; set; }

        public Eksponati(int ekspId, string ekspName, string epoha)
        {
            EkspId = ekspId;
            EkspName = ekspName;
            Epoha = epoha;
        }

        public override string ToString()
        {
            return ($"id экспоната: {EkspId}, Название: {EkspName}, Эпоха {Epoha}");
        }
    }
}
