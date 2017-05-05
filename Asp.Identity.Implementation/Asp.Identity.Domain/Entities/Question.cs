using System.Collections.Generic;

namespace Asp.Identity.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }

        public bool HaveAnswer { get; set; }

        public List<PossibleAnswer> PossibleAnswer { get; set; }
    }
}