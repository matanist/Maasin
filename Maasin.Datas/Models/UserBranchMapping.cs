using System;
using System.Collections.Generic;

namespace Maasin.Datas.Models
{
    public partial class UserBranchMapping
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BranchId { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual User User { get; set; }
    }
}
