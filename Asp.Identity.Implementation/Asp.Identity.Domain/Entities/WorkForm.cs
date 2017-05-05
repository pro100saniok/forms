using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Identity.Domain.Entities
{
    [Table("Forms")]
    public class WorkForm : BaseEntity
    {
        public string Name { get; set; }

        public List<Question> Questions { get; set; }

    }
}