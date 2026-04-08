
using MediatR;
using TorneoServiciosIAM.Application.DTOs;

namespace TorneoServiciosIAM.Application.UseCases.Queries;

public record GetAllUsuariosQuery : IRequest<List<UsuarioDTO>>;