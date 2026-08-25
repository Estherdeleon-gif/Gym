using System;

public class PagoDiario
{
    public int IdPago { get; set; }

    public DateTime Fecha { get; set; }

    public decimal PrecioEntrada { get; set; }

    public string MetodoPago { get; set; }

    public string Concepto { get; set; }

    public string Estado { get; set; }
}