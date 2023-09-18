namespace ClinicaVeterinaria.Models
{
    public class Funcionario : Generic
    {
        public string Email { get; set; } = "admin@admin.com";
        public string Senha { get; set; } = "amin";
        public string Funcao { get; set; } = "admin";
        public bool Ativo { get; set; } = false;

    }
}
