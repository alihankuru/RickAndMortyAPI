using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.DtoLayer.Dtos
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AirDate { get; set; }
        public string EpisodeCode { get; set; }

        //public List<CharacterDto> Characters { get; set; }
        public List<string> Characters { get; set; }

        public string Url { get; set; }
        public string Created { get; set; }
    }
}
