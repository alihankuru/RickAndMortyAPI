using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.EntityLayer.Concrete
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }

        // Assuming each location has multiple residents (characters)
        public List<Character> Residents { get; set; }

        public string Url { get; set; }
        public DateTime Created { get; set; }


    }
}
