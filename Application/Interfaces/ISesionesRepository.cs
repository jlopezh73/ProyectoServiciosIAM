using TorneoServiciosIAM.Application.DTOs;

namespace TorneoServiciosIAM.Application.Interfaces;

public interface ISesionesRepository
{

    public UsuarioSesionDTO? BuscarUltimaSesion(UsuarioDTO usuario);

    public UsuarioSesionDTO? GenerarSesion(UsuarioDTO usuario, string ip);

}