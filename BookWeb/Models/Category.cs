using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Diplay order must be between 1 and 100 !!")]
        public int DiaplayOrder { get; set; }
        public DateTime GetDateTime { get; set; }= DateTime.Now;
    }
}
