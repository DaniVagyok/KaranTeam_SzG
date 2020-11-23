using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Models
{
    public class FileCommentModel
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
