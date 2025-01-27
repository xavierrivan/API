using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Resultado
    {

        public int Id { get; set; }
        public int PacienteId { get; set; }
        public float Hemoglobina { get; set; }
        public float GlobulosRojos { get; set; }
        public float Colesterol { get; set; }

        

    }
}
