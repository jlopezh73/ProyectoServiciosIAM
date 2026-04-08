using MediatR;
using TorneoServiciosIAM.Application.DTOs;

namespace TorneoServiciosIAM.Application.UseCases.Commands;
public record ValidarUsuarioCommand(
    PeticionInicioSesionDTO peticion,
    string IP
) : IRequest<RespuestaValidacionUsuarioDTO>;