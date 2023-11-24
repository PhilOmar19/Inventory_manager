using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cp_Entidad;
using Cp_Datos;
using System.Data;

namespace Cp_Logica_Negocio
{
    public class C_LN
    {
        C_Datos Datos = new C_Datos();
        public DataTable LN_ShowProducts()
        {
            return Datos.D_ShowProducts();
        }
        public void LN_DeleteProducts(int id)
        {
            Datos.D_DeleteProducts(id);
        }
        public void LN_AddProducts(string Nombre, string Codigo, int Cantidad, string Fecha_entrada, string Fecha_expiracion)
        {
            Datos.D_AddProducts(Nombre,Codigo,Cantidad,Fecha_entrada,Fecha_expiracion);
        }
        public DataTable LN_GetProducts(int id)
        {
            return Datos.D_GetProducts(id);
        }
        public void LN_UpdateProducts(int id, string Nombre, string Codigo, int Cantidad, string Fecha_entrada, string Fecha_expiracion)
        {
            Datos.D_UpdateProducts(id, Nombre, Codigo, Cantidad, Fecha_entrada, Fecha_expiracion);
        }
    }
}
