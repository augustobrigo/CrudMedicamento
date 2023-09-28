using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrudMedicamento
{
    class conectarBD
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;
        List<ClaseMedicamento> listaMedicamentos = new List<ClaseMedicamento>();
        public conectarBD()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=db4free.net;Database=dam2024;" +
                "user=vituki;pwd=pilukina2024;old guids=true";
            //conexion.ConnectionString = "server=localhost;Database=dam2023;" +
            //  "user=root;pwd='';old guids=true";
        }

        internal void InsertarMedicamento(string nombre, double precio, short StockActual, short StockMin)
        {
            conexion.Open();
            String cadenaSql = "insert into medicamento(indice,nombre,precio,stockactual,stockminimo,activo) values(null,?nom,?pre,?stA,?stM,1)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?nom", MySqlDbType.VarChar).Value = nombre;
            comando.Parameters.AddWithValue("?pre", precio);
            //comando.Parameters.AddWithValue("i)
            comando.Parameters.AddWithValue("?stA", StockActual);
            comando.Parameters.AddWithValue("?stM", StockMin);

            comando.ExecuteNonQuery();

            conexion.Close();
        }
       

        public List<ClaseMedicamento> listarMedicamentos()
        {
            conexion.Open();
            String cadenaSql = "select * from medicamento where activo=1 ";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                ClaseMedicamento m = new ClaseMedicamento();
                m.Indice = Convert.ToInt16(datos["indice"]);
                m.Nombre = Convert.ToString(datos["nombre"]); ;
                m.Precio = Convert.ToDouble(datos["precio"]);
                m.Imagen = (byte[])datos["imagen"];
                m.StockActual = Convert.ToInt16(datos["stockactual"]);
                m.StockMinimo = Convert.ToInt16(datos["stockminimo"]);
                m.Activo = Convert.ToInt16(datos["activo"]);
                listaMedicamentos.Add(m);
            }
            conexion.Close();
            return listaMedicamentos;
        }
    }
}
