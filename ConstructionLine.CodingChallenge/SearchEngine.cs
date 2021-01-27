using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;
        private readonly HashSet<Shirt> resultsHash;
        private readonly SortedList<Shirt, Shirt> resultsSorted;
        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
          
            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.

        }


        public SearchResults Search(SearchOptions options)
        {
            List <Shirt> result = new List<Shirt>();
            // TODO: search logic goes here.
            result = _shirts.Where(shirt => 
                                        (!options.Colors.Any() || options.Colors.Contains(shirt.Color)) 
                                     && (!options.Sizes.Any() || options.Sizes.Contains(shirt.Size))).ToList();

  
            return new SearchResults
            {
                Shirts = result,

                ColorCounts = Color.All.Select(color => new ColorCount
                {   Color = color, Count = result.Count(shirt => shirt.Color == color) }).ToList(),

                SizeCounts = Size.All.Select(size => new SizeCount
                {   Size = size, Count = result.Count(shirt => shirt.Size == size)  }).ToList()
            };
        }
    }
}