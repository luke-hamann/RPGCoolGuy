using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RPGCoolGuy.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter an attack value.")]
        [Range(0, 1000000000, ErrorMessage = "Please enter an attack value between 0 and 1 trillion.")]
        public int? Attack { get; set; }

        [Required(ErrorMessage = "Please enter a defense value.")]
        [Range(0, 1000000000, ErrorMessage = "Please enter a defense value between 0 and 1 trillion.")]
        public int? Defense { get; set; }

        [Required(ErrorMessage = "Please enter an HP value.")]
        [Range(0, 1000000000, ErrorMessage = "Please enter an HP value between 0 and 1 trillion.")]
        public int? HP { get; set; }

        public string Slug
        {
            get
            {
                string value = (Name == null ? "" : Name);
                value = value.Trim().ToLower().Replace(" ", "-");
                Regex re = new Regex("[^a-zA-Z0-9-_]");
                value = re.Replace(value, "");
                return value;
            }
        }
    }
}
