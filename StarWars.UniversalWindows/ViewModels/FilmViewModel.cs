using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.UniversalWindows.ViewModels
{
    public class FilmViewModel
    {
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int[] CharacterIndices { get; set; }

        public int CharacterCount => CharacterIndices.Length;
    }
}
