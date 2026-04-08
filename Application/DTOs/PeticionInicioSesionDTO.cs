using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneoServiciosIAM.Application.DTOs;

public class PeticionInicioSesionDTO
{
    public String correoElectronico { get; set; }
    public String password { get; set; }
}