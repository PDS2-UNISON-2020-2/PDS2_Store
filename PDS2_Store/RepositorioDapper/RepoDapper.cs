using Dapper;
using PDS2_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PDS2_Store.RepositorioDapper
{
    public class RepoDapper
    {
        public SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }


        //Lista de categorias
        public List<Categoria> GetCategorias()
        {
            try
            {
                connection();
                con.Open();
                IList<Categoria> ReqList = SqlMapper.Query<Categoria>(
                                 con, "dbo.ListaCategorias").ToList();
                con.Close();
                return ReqList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Lista de SubCategorias
        public List<CatProducto> GetSubCategorias(string categoria)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new { @categ = categoria};
                IList<CatProducto> ReqList = SqlMapper.Query<CatProducto>(
                                 con, "dbo.ListaSubCateg").ToList();
                con.Close();
                return ReqList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Lista de Productos
        public List<CatProducto> GetProductos(string categ)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new { @categoria = categ };
                IList<CatProducto> ReqList = SqlMapper.Query<CatProducto>(
                                 con, "dbo.ListaProductos").ToList();
                con.Close();
                return ReqList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void LlenarSolicitud(Request Req)
        {
            //Procedure para llenar la solicitud de vendedor
            //falta probar que funcione bien desde aqui
            try
            {
                connection();
                con.Open();
                var parameters = new {
                    @nombre = Req.Nombre,
                    @apell = Req.Apellidos,
                    @fecha_nac = Req.FechaNacimiento,
                    @correo = Req.correo,
                    @celular = Req.celular,
                    @rfc = Req.RFC,
                    @direccion = Req.Direccion,
                    @postal = Req.CodigoPostal,
                    @estado = Req.Estado,
                    @ciudad = Req.Ciudad,
                    @userid = Req.UserId };
                con.Execute("dbo.LlenarSolicitud", parameters, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Lista de solicitudes de vendedor
        //Debe funcionar
        public List<RequestViewModel> GetRequests()
        {
            try
            {
                connection();
                con.Open();
                IList<RequestViewModel> ReqList = SqlMapper.Query<RequestViewModel>(
                                 con, "dbo.ListaSolicitudes").ToList();
                con.Close();
                return ReqList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Cambio del estado de las solicitudes de vendedor
        //Falta probar que funcione aqui
        public void Cambio_de_estado(RequestStatus status)
        {
            try
            {
                connection();   
                con.Open();
                con.Execute("dbo.Cambio_Estado_Solicitud", status, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Lista de Tarjetas
        //Funciona, manda la lista de tarjetas del usuario
        public List<Tarjeta> GetTarjetas(string user)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new { @userid = user};
                IList<Tarjeta> ReqList = SqlMapper.Query<Tarjeta>(
                                 con, "dbo.ListaTarjetas", parameters, commandType: CommandType.StoredProcedure).ToList();

                con.Close();
                con.Close();
                return ReqList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Falta probar que funcione bien desde aqui
        public void CrearTarjeta(TarjetaViewModel tar)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new
                {
                    @nombre = tar.Nombre,
                    @numero = tar.Numero,
                    @fecha = tar.Fecha,
                    @codigo = tar.Codigo,
                    @userid = tar.UserId,
                    @id = tar.id
                };
                con.Execute("dbo.CrearTarjeta", parameters, commandType: CommandType.StoredProcedure);
                
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Falta probar que funcione bien desde aqui
        public void EditarTarjeta(Tarjeta tarup)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new
                {
                    @nombre = tarup.Nombre,
                    @numero = tarup.Numero,
                    @fecha = tarup.Fecha,
                    @codigo = tarup.Codigo,
                    @id = tarup.id
                };
                con.Execute("dbo.EditarTarjeta", parameters, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Falta probar que funcione bien desde aqui
        //aun no estoy seguro, talvez modifique el procedure porque no se bien aun que hacer en caso de eliminar
        public bool BorrarTarjeta(int id)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new { @id = id };
                con.Execute("dbo.BorrarTarjeta", parameters, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need 
                throw ex;
            }
        }

        //Lista de direcciones
        //Deberia funcionar porque es igual al de las tarjetas
        public List<Direccion> GetDirecciones(string user)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new { @userid = user };
                IList<Direccion> ReqList = SqlMapper.Query<Direccion>(
                                 con, "dbo.ListaDirecciones", parameters, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return ReqList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Falta probar que funcione bien desde aqui
        public void CrearDireccion(DireccionViewModel dir)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new
                {
                    @Direccion = dir.direccion,
                    @Postal = dir.CodigoPostal,
                    @estado = dir.Estado,
                    @ciudad = dir.Ciudad,
                    @userid = dir.UserId,
                    dir.id
                };
                con.Execute("dbo.CrearDireccion", parameters, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Falta probar que funcione bien desde aqui
        public void EditarDireccion(Direccion dirup)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new
                {
                    @Direccion = dirup.direccion,
                    @Postal = dirup.CodigoPostal,
                    @estado = dirup.Estado,
                    @ciudad = dirup.Ciudad,
                    @id = dirup.id
                };
                con.Execute("dbo.EditarDireccion", parameters, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Falta probar que funcione bien desde aqui
        //aun no estoy seguro, lo mismo que las tarjetas, aun no estoy seguro de que hacer cuando se borren
        public bool BorrarDireccion(int id)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new { @id = id };
                con.Execute("dbo.BorrarDireccion", parameters, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need 
                throw ex;
            }
        }
    }
}