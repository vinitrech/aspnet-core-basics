using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Data
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }

        [ForeignKey(nameof(CountryId))] // this syntax is used to prevent errors, if a string is passed, the IDE would not scream in case the variable's name changed.
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
