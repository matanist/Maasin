using System;
using System.Collections.Generic;

namespace Maasin.Datas.Models
{
    public partial class User
    {
        public User()
        {
            UserBranchMapping = new HashSet<UserBranchMapping>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserBranchMapping> UserBranchMapping { get; set; }
    }
}
