using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Model
{
    public class RolePermission
    {
        [Key]
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
    }
}
