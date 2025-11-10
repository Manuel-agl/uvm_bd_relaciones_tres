using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Proyecto_B2
{
    public class Persona
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("apellido")]
        public string Apellido { get; set; }

        [BsonElement("edad")]
        public int Edad { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("telefono")]
        public string Telefono { get; set; }

        [BsonElement("ciudad")]
        public string Ciudad { get; set; }

        [BsonElement("saldo")]
        public double Saldo { get; set; }

        [BsonElement("fecha_nacimiento")]
        public string FechaNacimiento { get; set; }

        [BsonElement("ocupacion")]
        public string Ocupacion { get; set; }
    }
}
