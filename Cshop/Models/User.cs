using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cshop.Models
{
      public class User : IdentityUser

    {

        [Column("FirstName")]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [MaxLength(64)]
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public virtual ICollection<OrderList> OrderList { get; set; }

        [Key]
        public Guid UserId { get; set; }


        //public string AccessorName { get; set; }


    }
}
