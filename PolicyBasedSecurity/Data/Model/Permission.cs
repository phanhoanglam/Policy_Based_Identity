using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
    public class Permission
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Function { get; set; }
    }
}
