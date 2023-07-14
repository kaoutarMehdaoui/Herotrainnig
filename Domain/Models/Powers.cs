using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Powers : Common
    {
        [Required]
        public string Name { get; set; }

        public List<HeroPower> HeroPowers { get; set; }
    }
}
