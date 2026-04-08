
using TorneoServiciosIAM.Application.Interfaces;
using TorneoServiciosIAM.Application.DTOs;
using TorneoServiciosIAM.Domain;
using MongoDB.Driver;
using System.Text;
using System.Security.Cryptography;


namespace TorneoServiciosIAM.Infrastructure.Persistence;


public class SesionesRepository : ISesionesRepository
{
    //private IGeneradorTokensService _generadorTokensService;
    private IMongoDatabase _database;
    private int noHoras;
    private String key;
    public SesionesRepository(IConfiguration configuration,
                            IMongoDatabase _database
                            //IGeneradorTokensService _generadorTokensService
                            )
    {
        
        //this._generadorTokensService = _generadorTokensService;

        noHoras = Int32.Parse(configuration["JWTSettings:Duration"]);
        key = (String)configuration["JWTSettings:Key"];
    }

    public UsuarioSesionDTO? BuscarUltimaSesion(UsuarioDTO usuario)
    {
        var hoy = DateTime.Now.AddHours(noHoras);
        var sesion = _database.GetCollection<UsuarioSesion>("UsuariosSesiones").Find(u => u.FechaInicio > hoy).FirstOrDefaultAsync().Result;
        if (sesion != null)
        {
            return new UsuarioSesionDTO()
            {
                ID = sesion.ID,
                FechaInicio = sesion.FechaInicio,
                FechaUltimoAcceso = sesion.FechaUltimoAcceso,
                DireccionIP = sesion.DireccionIP,
                Token = sesion.Token
            };
        }
        else
        {
            return null;
        }

    }

    public UsuarioSesionDTO? GenerarSesion(UsuarioDTO usuario,
                               string ip)
    {
        var sesion = new UsuarioSesion()
        {
            IDUsuario = usuario.ID,
            FechaInicio = DateTime.Now,
            FechaUltimoAcceso = DateTime.Now,
            DireccionIP = ip,
        };
        sesion.Token = Guid.NewGuid().ToString();
        _database.GetCollection<UsuarioSesion>("UsuariosSesiones").InsertOneAsync(sesion);

        var sesionDTO = new UsuarioSesionDTO()
        {
            ID = sesion.ID,
            IDUsuario = sesion.IDUsuario,
            FechaInicio = sesion.FechaInicio,
            FechaUltimoAcceso = sesion.FechaUltimoAcceso,
            DireccionIP = sesion.DireccionIP,
            Token = sesion.Token
        };

        AsignarTokenSesion(sesionDTO, sesion.Token);
        return sesionDTO;
    }

    private void AsignarTokenSesion(UsuarioSesionDTO sesion, string token)
    {
        //_dao.AsignarTokenSesion(sesion.ID, token);
        /*_bitacoraService.RegistrarAccion(
            new UsuarioAccionDTO() {
                FechaHora = DateTime.Now,
                IDUsuario = sesion.IDUsuario, 
                IDUsuarioSesion = sesion.ID, 
                Accion = "Inicio de sesión"
            });*/
    }
}