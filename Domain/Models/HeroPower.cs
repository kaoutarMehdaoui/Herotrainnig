using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class HeroPower : Common
    {
        [ForeignKey("HeroId")]
        public int HerosId { get; set; }
        public Heros Heros { get; set; }

        [ForeignKey("PowerId")]
        public int PowersId { get; set; }
        public Powers Powers { get; set; }

    }
}
