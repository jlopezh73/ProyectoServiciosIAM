using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TorneoServiciosIAM.Domain
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String ID { get; set; }        
        public String CorreoElectronico { get; set; }
        

        public string? Paterno { get; set; }

        public string? Materno { get; set; }

        public string? Nombre { get; set; }
        public string? Puesto { get; set; }

        public string? Password { get; set; }


        public string? PasswordValidacion { get; set; }

        public ulong? Activo { get; set; }

        public Boolean ActivoBoolean
        {
            get
            {
                return Activo == 1;
            }
            set
            {
                Activo = value ? (ulong)1 : (ulong)0;
            }
        }
    }
}