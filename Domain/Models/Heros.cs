using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Heros : Comman
    {
        [Required, StringLength(50), RegularExpression(@"[A-Za-z]", ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }

        [Required, StringLength(50), RegularExpression(@"[A-Za-z]", ErrorMessage = "Characters are not allowed in LastName.")]
        public string LastName { get; set; }

        [ Range(5, 90, ErrorMessage = "The age must be between 5 and 90 years old.")]
        public int Age { get; set; }

        [Required, DisplayName("Hero Name"), StringLength(50)]
        public string NameHero { get; set; }

        public string photo { get; set; }
        public string gender { get; set; }
        public string Description { get; set; }
        public List<HeroPower> HeroPowers { get; set; }
    }
}
