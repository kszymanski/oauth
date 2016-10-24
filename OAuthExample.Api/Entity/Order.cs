using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAuthExample.Api.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public User Buyer { get; set; }
        public int BuyerId { get; set; }
    }
}