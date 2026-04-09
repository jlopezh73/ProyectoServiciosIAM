using MediatR;
using TorneoServiciosIAM.Application.Interfaces;
using TorneoServiciosIAM.Application.DTOs;
using TorneoServiciosIAM.Application.UseCases.Commands;
using TorneoServiciosIAM.Domain;

namespace TorneoServiciosEquipos.Application.UseCases;

public class ValidarUsuarioHandler : IRequestHandler<ValidarUsuarioCommand, RespuestaValidacionUsuarioDTO>
{
    private readonly IUsuariosRepository _usuariosRepository;
    private readonly ISesionesRepository _sesionesRepository;

    public ValidarUsuarioHandler(IUsuariosRepository usuariosRepository, ISesionesRepository sesionesRepository)
    {
        _usuariosRepository = usuariosRepository;
        _sesionesRepository = sesionesRepository;
    }

    public async Task<RespuestaValidacionUsuarioDTO> Handle(ValidarUsuarioCommand request, CancellationToken cancellationToken)
    {

        var respuesta = await _usuariosRepository.ValidarUsuario(request.peticion);
        if (respuesta.correcto)
        {
            var sesion = _sesionesRepository.BuscarUltimaSesion(respuesta.usuario);
            if (sesion == null)            
                sesion = _sesionesRepository.GenerarSesion(respuesta.usuario, request.IP);            
            respuesta.token = sesion.Token;
        }
        return respuesta;
    }
}