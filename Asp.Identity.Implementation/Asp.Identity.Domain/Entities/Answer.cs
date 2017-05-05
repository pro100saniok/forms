using Asp.Identity.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Identity.Domain.Entities
{
    public class UserAnswer : BaseEntity
    {
        public int? PossibleAnswerId { get; set; }
        public string Text { get; set; }

        public AnswerType Type { get; set; }

        public int QuestionId { get; set; }


        #region Navigations
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        [ForeignKey("PossibleAnswerId")]
        public PossibleAnswer PossibleAnswer { get; set; }
        #endregion
    }
}