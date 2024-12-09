using ClubBackend.Enums;


namespace CLubBackend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public int? SocioId { get; set; }

        public Socio? Socio { get; set; } = null;
        public bool Eliminado { get; set; } = false;

        public override string ToString()
        {
            return Socio != null ? $"{Socio}" : string.Empty;
        }
    }
}
