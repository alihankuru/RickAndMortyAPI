using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.EntityLayer.Concrete
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }

        public Location Origin { get; set; }
        public int? OriginId { get; set; }
        public Location Location { get; set; }

        // Assuming each character can be in multiple episodes
        public List<Episode> Episodes { get; set; }

        public string Url { get; set; }
        public DateTime Created { get; set; }

    }
}
