using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNo5
{
    public class Posyetyityelyi
    {
        public int PosId { get; set; }
        public string PosName { get; set; }
        public int Age { get; set; }
        public string City{ get; set; }

        public Posyetyityelyi(int posId, string posName, int age, string city)
        {
            PosId = posId;
            PosName = posName;
            Age = age;
            City = city;
        }

        public override string ToString()
        {
            return ($"id посетителя: {PosId}, Имя: {PosName}, Возраст: {Age}, Город проживания: {City}");
        }
    }
}
