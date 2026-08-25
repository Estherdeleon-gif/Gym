using Npgsql;
using System.Data;
using System.Security.Principal;
namespace Gym
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conexionBD = new Conexion();

                using (NpgsqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    conexion.Open();
                    string consulta = @"SELECT *
                    FROM usuarios
                    WHERE usuario = @usuario
                    AND contrasena = @password
                    AND estado = true";

                    NpgsqlCommand cmd = new NpgsqlCommand(consulta, conexion);

                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        MessageBox.Show("Bienvenido al sistema.",
                            "Login",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        int idUsuario = Convert.ToInt32(reader["id_usuario"]);
                        int idRol = Convert.ToInt32(reader["id_rol"]);

                        Principal principal = new Principal(idRol, idUsuario);
                        principal.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void foto_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
