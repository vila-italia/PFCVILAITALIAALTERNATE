﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public int MotoboyId { get; set; }
        public virtual Motoboy Motoboy { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}