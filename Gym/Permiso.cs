namespace Gym
{
    public class Permiso
    {
        public int IdPermiso { get; set; }
        public int IdRol { get; set; }
        public string Modulo { get; set; }

        public bool Ver { get; set; }
        public bool Crear { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
    }
}
