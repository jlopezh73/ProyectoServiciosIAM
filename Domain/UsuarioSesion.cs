using System;
using System.Collections.Generic;

namespace TorneoServiciosIAM.Domain;

public partial class UsuarioSesion
{
    public String ID { get; set; }

    public String IDUsuario { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaUltimoAcceso { get; set; }

    public string? DireccionIP { get; set; }

    public string? Token { get; set; }
}