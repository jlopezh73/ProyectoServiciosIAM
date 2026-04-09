using TorneoServiciosIAM.Application.DTOs;

namespace TorneoServiciosIAM.Application.Interfaces;

public interface IUsuariosRepository
{
    public Task<RespuestaValidacionUsuarioDTO>
    ValidarUsuario(PeticionInicioSesionDTO peticionInicioSesion);
    public Task<List<UsuarioDTO>> ObtenerTodosLosUsuariosAsync();
    /*public Task CrearUsuarioAsync(UsuarioDTO usuarioDTO);
    public Task<UsuarioDTO> ObtenerUsuarioPorIdAsync(int idUsuario);
    public Task ActualizarUsuarioAsync(UsuarioDTO usuarioDTO);
    public Task EliminarUsuarioAsync(int idUsuario);    */
}