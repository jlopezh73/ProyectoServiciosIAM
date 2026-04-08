using MediatR;
using TorneoServiciosIAM.Application.DTOs;
using TorneoServiciosIAM.Application.Interfaces;
using TorneoServiciosIAM.Application.UseCases.Queries;

namespace TorneoServiciosIAM.Application.UseCases;

public class GetAllUsuariosHandler : IRequestHandler<GetAllUsuariosQuery, List<UsuarioDTO>>
{
    private readonly IUsuariosRepository _repository;

    public GetAllUsuariosHandler(IUsuariosRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UsuarioDTO>> Handle(GetAllUsuariosQuery request, CancellationToken ct)
    {
        var equipos = await _repository.ObtenerTodosLosUsuariosAsync();

        return equipos;
    }
}