using System.ComponentModel.DataAnnotations;

namespace HeroCRUD.ModelDTO
{
    public class PowerDTO
    {
        public int Id { get; set; }
       [Required (ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
    }
}
