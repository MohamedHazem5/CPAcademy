using System.ComponentModel.DataAnnotations;


namespace CPAcademy.Models
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
