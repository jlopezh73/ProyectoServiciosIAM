using MediatR;
using TorneoServiciosIAM.Application.UseCases.Queries;
using TorneoServiciosIAM.Application.UseCases.Commands;
using TorneoServiciosIAM.Application.DTOs;

namespace TorneoServiciosIAM.Api;

public static class IAMEndpoints
{
    public static void MapIAMEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/iam")
                       .WithTags("IAM");

        

        group.MapPost("/validarUsuario", async (ISender mediator,
                                              PeticionInicioSesionDTO peticion,
                                              HttpContext context) =>
         {
             var ip = context.Connection.RemoteIpAddress.ToString();
             var command = new ValidarUsuarioCommand(peticion, ip);
             var respuesta = await mediator.Send(command);
             return Results.Ok(respuesta);             
             
         })
        .WithName("ValidarUsuario");



        group.MapGet("/usuarios", async (ISender mediator) =>
        {
            System.Console.WriteLine("Devolviendo todos los usuarios...");
            var resultado = await mediator.Send(new GetAllUsuariosQuery());            
            return Results.Ok(resultado);
        })
        .WithName("ObtenerTodosLosUsuarios");
        /*.RequireAuthorization(auth =>
        {
           auth.RequireRole("Administrador General");
        });*/


        /*app.MapPost("/api/Identidad/usuario", async (IIdentidadService service,
                                                            UsuarioDTO usuarioDTO) =>
         {
             await service.CrearUsuarioAsync(usuarioDTO);
         })
        .WithName("AgregarUsuario")
        .RequireAuthorization(auth =>
            {
                auth.RequireRole("Administrador General");
            });

        app.MapPut("/api/Identidad/usuario", async (IIdentidadService service,
                                                            UsuarioDTO usuarioDTO) =>
         {
             await service.ActualizarUsuarioAsync(usuarioDTO);
         })
        .WithName("ActualizarUsuario")
        .RequireAuthorization(auth =>
            {
                auth.RequireRole("Administrador General");
            });


        app.MapDelete("/api/Identidad/usuario", async (IIdentidadService service,
                                                            int usuarioDTO) =>
         {
             await service.EliminarUsuarioAsync(usuarioDTO);
         })
        .WithName("EliminarUsuario")
        .RequireAuthorization(auth =>
            {
                auth.RequireRole("Administrador General");
            });*/

    }
}