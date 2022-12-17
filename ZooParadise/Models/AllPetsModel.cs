using ZooParadise.Core.Models.Pet;

namespace ZooParadise.Models
{
    public class AllPetsModel
    {
        public const int PetsPerPage = 6;

        public string? AnimalType { get; set; }

        public string? Colour { get; set; }

        public string? Gender { get; set; }

        public string? SearchTerm { get; set; }

        public PetSorting Sorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPetCount { get; set; }

        public IEnumerable<string> AnimalTypes { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<string> Colours { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<string> Genders { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<PetModel> Pets { get; set; } = Enumerable.Empty<PetModel>();
    }
}
