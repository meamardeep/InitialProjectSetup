using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeIdea.DataAccess
{
    public class Account
    {
              
        //string FirstName { get; set; }
        //string LastName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        [Column(TypeName="varchar(50)")]
       public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

    }
}
