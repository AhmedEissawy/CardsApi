using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsApi.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public int ExpireMonth { get; set; }

        public int ExpireYear { get; set; }

        public int CVC { get; set; }
    }
}
