using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cp_Entidad;

namespace Cp_Datos
{
    public class C_Datos
    {
        SqlConnection conexion = new SqlConnection("Server= DESKTOP-TFNBFUK; database= Gestion; integrated security= true");

        public DataTable D_ShowProducts()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("ShowProducts", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public void D_DeleteProducts(int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteProducts", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_producto", id);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void D_AddProducts(string Nombre, string Codigo, int Cantidad, string Fecha_entrada, string Fecha_expiracion)
        {
            SqlCommand cmd = new SqlCommand("AddProducts", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Codigo", Codigo);
            cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
            cmd.Parameters.AddWithValue("@Fecha_entrada", Fecha_entrada);
            cmd.Parameters.AddWithValue("@Fecha_expiracion", Fecha_expiracion);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable D_GetProducts(int id)
        {
            SqlCommand cmd = new SqlCommand("GetProducts", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_producto", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public void D_UpdateProducts(int id, string Nombre, string Codigo, int Cantidad, string Fecha_entrada, string Fecha_expiracion)
        {
            SqlCommand cmd = new SqlCommand("UpdateProducts", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_producto", id);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Codigo", Codigo);
            cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
            cmd.Parameters.AddWithValue("@Fecha_entrada", Fecha_entrada);
            cmd.Parameters.AddWithValue("@Fecha_expiracion", Fecha_expiracion);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
