using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Test
    {
        public int Id { get; set; }

        [Required]
        public string NameTest { get; set; }

        public string Description { get; set; }

        public virtual Role Role { get; set; }
    }
}
