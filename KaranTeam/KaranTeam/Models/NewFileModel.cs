using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Models
{
    public class NewFileModel
    {
        public int Id { get; set; }
        public string FileBase64String { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
