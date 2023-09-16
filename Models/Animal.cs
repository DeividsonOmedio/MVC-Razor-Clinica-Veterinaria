namespace ClinicaVeterinaria.Models
{
    public class Animal : Generic
    {
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public int Idade { get; set; }
        public string Dono { get; set; }
    }
}
