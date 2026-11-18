using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace FlightLib
{
    public class UsuarioList
    {
        string conexion = "Data Source=usuarios.db;Version=3;";

        public void CrearBaseDeDatos()
        {
            SQLiteConnection con = new SQLiteConnection(conexion);
            con.Open(); 

            SQLiteCommand comando = new SQLiteCommand(
                "CREATE TABLE IF NOT EXISTS usuarios (nombre TEXT PRIMARY KEY, contrasena TEXT NOT NULL)", con);
            comando.ExecuteNonQuery();

            con.Close();
        }

        // true si hi ha un usuari amb aquest nom a la base de dades
        public bool Existe(string nombre)
        {
            SQLiteConnection con = new SQLiteConnection(conexion);
            con.Open();

            SQLiteCommand comando = new SQLiteCommand(
                "SELECT COUNT(*) FROM usuarios WHERE nombre = @nombre", con);
            comando.Parameters.AddWithValue("@nombre", nombre);
            int cantidad = Convert.ToInt32(comando.ExecuteScalar());

            con.Close();
            return cantidad > 0;
        }

        // true si el nom y la contra coincideixen amb les de l'usuari
        public bool Autenticar(string nombre, string contrasena)
        {
            SQLiteConnection con = new SQLiteConnection(conexion);
            con.Open();

            SQLiteCommand comando = new SQLiteCommand(
                "SELECT COUNT(*) FROM usuarios WHERE nombre = @nombre AND contrasena = @contrasena", con);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@contrasena", contrasena);
            int cantidad = Convert.ToInt32(comando.ExecuteScalar());

            con.Close();
            return cantidad > 0;
        }

        public bool Registrar(string nombre, string contrasena)
        {
            if (Existe(nombre) == true)
                return false;

            SQLiteConnection con = new SQLiteConnection(conexion);
            con.Open();

            SQLiteCommand comando = new SQLiteCommand(
                "INSERT INTO usuarios (nombre, contrasena) VALUES (@nombre, @contrasena)", con);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@contrasena", contrasena);
            comando.ExecuteNonQuery();

            con.Close();
            return true;
        }
    }
}