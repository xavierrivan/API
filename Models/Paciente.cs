using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Paciente
    {

        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }

        public int edad { get; set; }
        [Required]
        public string genero { get; set; }


    }

}
