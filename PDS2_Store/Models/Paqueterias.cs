using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class Paqueterias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public int CorreosId { get; set; }
        public int TelefonosId { get; set; }
        public int PaquetesId { get; set; }
        public int PaquetesExpressId { get; set; }
        public int DestinosId { get; set; }

    }

    public class Correos
    {
        public int id { get; set; }
        public string correo1 { get; set; }
        public string correo2 { get; set; }
        public string correo3 { get; set; }
        public string correo4 { get; set; }
        public string correo5 { get; set; }
    }

    public class Telefonos
    {
        public int id { get; set; }
        public long tel1 { get; set; }
        public long tel2 { get; set; }
        public long tel3 { get; set; }
        public long tel4 { get; set; }
        public long tel5 { get; set; }
    }

    public class Paquete
    {
        public int id { get; set; }
        public decimal Precio { get; set; }
        public int DiasMin { get; set; }
        public int DiasMax { get; set; }
    }

    public class PaqueteExpress
    {
        public int id { get; set; }
        public decimal Precio { get; set; }
        public int DiasMin { get; set; }
        public int DiasMax { get; set; }
    }

    public class Destino
    {
        public int id { get; set; }
        public bool Centro { get; set; }
        public bool Noroeste { get; set; }
        public bool Noreste { get; set; }
        public bool Oeste { get; set; }
        public bool Sureste { get; set; }
    }

    public class PaqueteriaCompraViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int PaquetesId { get; set; }
        public decimal Precio { get; set; }

        public int PaquetesExpressId { get; set; }
        public decimal PrecioEx { get; set; }
    }
}