using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNo5
{
    public class Bileti
    {
        public int TiketId { get; set; }
        public int EkspId { get; set; }
        public int PosId { get; set; }
        public string Date { get; set; }
        public int Cost { get; set; }

        public Bileti(int tiketId, int ekspId, int posId, string date, int cost)
        {
            TiketId = tiketId;
            EkspId = ekspId;    
            PosId = posId;
            Date = date;
            Cost = cost;
        }

        public override string ToString()
        {
            return ($"Id билета: {TiketId}, Id экспоната: {EkspId}, Id посетителя: {PosId}, Дата: {Date}, Стоимость: {Cost}");
        }
    }
}
