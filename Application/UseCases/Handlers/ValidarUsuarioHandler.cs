using MediatR;
using TorneoServiciosIAM.Application.Interfaces;
using TorneoServiciosIAM.Application.DTOs;
using TorneoServiciosIAM.Application.UseCases.Commands;
using TorneoServiciosIAM.Domain;

namespace TorneoServiciosEquipos.Application.UseCases;

public class ValidarUsuarioHandler : IRequestHandler<ValidarUsuarioCommand, RespuestaValidacionUsuarioDTO>
{
    private readonly IUsuariosRepository _repository;

    public ValidarUsuarioHandler(IUsuariosRepository repository)
    {
        _repository = repository;
    }

    public async Task<RespuestaValidacionUsuarioDTO> Handle(ValidarUsuarioCommand request, CancellationToken cancellationToken)
    {        

        var respuesta = await _repository.ValidarUsuario(request.peticion, request.IP);
        return respuesta;
    }
}