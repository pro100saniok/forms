using Asp.Identity.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Identity.Domain.Entities
{
    public class UserForm : BaseEntity
    {
        public int FormId { get; set; }
        public int UserId { get; set; }

        public List<UserAnswer> Answers { get; set; }

        public FormStatus MyProperty { get; set; }

        #region Navgation_Properties
        [ForeignKey("FormId")]
        public WorkForm Form { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } 
        #endregion
    }
}
