using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Identity.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CID { get; set; }

        [NotMapped]
        public string FullName
        {
            get {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        public List<LoginHistory> LoginHistory { get; set; }

        public List<UserForm> WorkForms { get; set; }
    }
}
