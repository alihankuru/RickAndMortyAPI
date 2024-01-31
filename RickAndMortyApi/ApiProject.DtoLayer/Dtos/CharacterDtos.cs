using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.DtoLayer.Dtos
{
    public class CharacterDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        //public List<EpisodeDtos> Episodes { get; set; }
        public List<string> Episodes { get; set; }
        public LocationDto Origin { get; set; }
        public LocationDto Location { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
