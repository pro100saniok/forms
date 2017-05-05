using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Identity.Domain.Entities
{
    public class LoginHistory : BaseEntity
    {
        public DateTime Date { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}