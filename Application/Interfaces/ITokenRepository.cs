using TorneoServiciosIAM.Application.DTOs;

namespace TorneoServiciosIAM.Application.Interfaces;

public interface ITokenRepository
{
    String GenerarToken(UsuarioDTO usuario, String key, int noHoras, String idUsuarioSesion);
}