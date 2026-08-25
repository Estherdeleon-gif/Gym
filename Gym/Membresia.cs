public class Membresia
{
    public int IdMembresia { get; set; }

    public int IdCliente { get; set; }

    public string Tipo { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechadeExpiracion { get; set; }

    public decimal CostodeMembresia { get; set; }

    public bool Estado { get; set; }
}