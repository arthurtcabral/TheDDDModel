using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Product : Base
    {
        [Display(Name = "Preço")]
        public double Price { get; set; }
        [Display(Name = "Ativo")]
        public bool IsActive { get; set; }
    }
}
