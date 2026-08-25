using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gym
{
    public partial class Principal : Form
    {
        private int idRolSeleccionado = 0;
        private int idUsuarioSeleccionado = 0;
        private int idClienteSeleccionado = 0;
        private int idRolUsuario;
        private int idUsuarioActual;
        private string rutaFotoEntrenador = null;
        private int idEntrenadorSeleccionado = 0;
        private string rutaFotoProducto = null;
        private int idProductoSeleccionado = 0;
        private int idProveedorSeleccionado = 0;
        private int idMembresiaSeleccionada = 0;
        private int idPagoSeleccionado = 0;
        private int idMantenimientoSeleccionado = 0;
        private int idClienteCobroSeleccionado = 0;


        public Principal()
        {
            InitializeComponent();
            nudPagoDiarioPrecio1.Value = Properties.Settings.Default.PrecioEntrada;
            CargarRoles();
            CargarComboRoles();
            CargarUsuarios();
            CargarClientes();
            ConfigurarSexoCliente();
            CargarProveedores();
            CargarClientesMembresia();
            CargarPagosDiarios();
            ActualizarTotalPagoDiario();
            ConfigurarPantallaCliente();

        }


        public Principal(int idRol, int idUsuario)
        {
            InitializeComponent();

            CargarRoles();
            CargarComboRoles();
            CargarUsuarios();
            CargarClientes();
            ConfigurarSexoCliente();
            CargarProveedores();
            CargarMembresias();
            CargarClientesMembresia();
            CargarTiposMembresia();
            CargarPagosDiarios();
            ActualizarTotalPagoDiario();

            idRolUsuario = idRol;
            idUsuarioActual = idUsuario;

            if (idRolUsuario == 17)
            {
                CargarMiPerfil();
                tabProductosClientes.TabPages.Remove(tabClientes);
            }

        }

        private void ConfigurarSexoCliente()
        {
            cbSexoCliente.Items.Clear();

            cbSexoCliente.Items.Add("Masculino");
            cbSexoCliente.Items.Add("Femenino");
            cbSexoCliente.Items.Add("Otro");

            cbSexoCliente.SelectedIndex = -1;
        }
        private void CargarComboRoles()
        {
            RolDAO rolDAO = new RolDAO();

            cbRol.DataSource = rolDAO.CargarComboRoles();
            cbRol.DisplayMember = "nombre";
            cbRol.ValueMember = "id_rol";
        }
        private void CargarMembresias()
        {
            MembresiaDAO membresiaDAO = new MembresiaDAO();

            dgvMembresias1.DataSource = null;
            dgvMembresias1.DataSource = membresiaDAO.Listar();
        }
        private void CargarTiposMembresia()
        {
            cbMembresiaTipo1.Items.Clear();

            cbMembresiaTipo1.Items.Add("Mensual");
            cbMembresiaTipo1.Items.Add("Trimestral");
            cbMembresiaTipo1.Items.Add("Semestral");
            cbMembresiaTipo1.Items.Add("Anual");
        }
        private void CargarRoles()
        {
            RolDAO rolDAO = new RolDAO();
            tablaRoles.DataSource = rolDAO.Listar();
        }
        private void CargarUsuarios()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            tablaUsuarios.DataSource = usuarioDAO.Listar();
        }
        private void CargarProveedores()
        {
            ProveedorDAO proveedorDAO = new ProveedorDAO();

            dgvProveedores1.DataSource = null;
            dgvProveedores1.DataSource = proveedorDAO.Listar();
        }
        private void CargarMembrecias()
        {
            MembresiaDAO membresiaDAO = new MembresiaDAO();

            dgvMembresias1.DataSource = null;
            dgvMembresias1.DataSource = membresiaDAO.Listar();
        }
        private void CargarPagosDiarios()
        {
            PagoDiarioDAO pagoDiarioDAO = new PagoDiarioDAO();

            dgvPagosDiarios1.DataSource = null;
            dgvPagosDiarios1.DataSource = pagoDiarioDAO.Listar();
        }
        private void CargarClientes()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            tablaClientes.DataSource = clienteDAO.Listar();
        }
        private void CargarClientesMembresia()
        {
            ClienteDAO clienteDAO = new ClienteDAO();

            cbMembresiaCliente1.DataSource = null;
            cbMembresiaCliente1.DataSource = clienteDAO.Listar();
            cbMembresiaCliente1.DisplayMember = "Nombre";
            cbMembresiaCliente1.ValueMember = "IdCliente";
        }
        private void CargarMantenimientos()
        {
            MantenimientoDAO mantenimientoDAO = new MantenimientoDAO();

            dtpMantenimientoProximo1.DataSource = mantenimientoDAO.Listar();
        }
        private void LimpiarMantenimiento()
        {
            txtMantenimientoEquipo1.Clear();

            dtpMantenimientoFecha1.Value = DateTime.Now;

            cbMantenimientoTipo1.SelectedIndex = -1;

            txtMantenimientoDescripcion1.Clear();

            nudMantenimientoCosto1.Value = 0;

            cbMantenimientoEstado1.SelectedIndex = -1;

            dtpMantenimientoProximoMantenimiento.Value = DateTime.Now;
        }


        private void txtCobroCliente1_Leave(object sender, EventArgs e)
        {
            SeleccionarClienteCobro();
        }
        private void CargarMiPerfil()
        {

            ClienteDAO clienteDAO = new ClienteDAO();

            Cliente cliente = clienteDAO.ObtenerPorUsuario(idUsuarioActual);

            if (cliente == null)
            {
                MessageBox.Show(
                    "No se encontró un perfil asociado a este usuario.",
                    "Mi Perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            txtPerfilNombre1.Text = cliente.Nombre;
            txtPerfilApellido1.Text = cliente.Apellido;
            txtPerfilCedula1.Text = cliente.Cedula;
            txtPerfilTelefono1.Text = cliente.Telefono;
            txtPerfilCorreo1.Text = cliente.Correo;
            txtPerfilDireccion1.Text = cliente.Direccion;

            dtpPerfilFechaNacimiento1.Value = cliente.FechaNacimiento;

            if (cbPerfilSexo1.Items.Contains(cliente.Sexo))
                cbPerfilSexo1.SelectedItem = cliente.Sexo;

            txtPerfilPassword1.Clear();

            if (!string.IsNullOrEmpty(cliente.Foto) &&
                File.Exists(cliente.Foto))
            {
                picPerfilFoto1.Image = Image.FromFile(cliente.Foto);
                picPerfilFoto1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picPerfilFoto1.Image = null;
            }
        }
        private void HabilitarEdicionPerfil(bool habilitar)
        {
            txtPerfilNombre1.Enabled = habilitar;
            txtPerfilApellido1.Enabled = habilitar;
            txtPerfilCedula1.Enabled = habilitar;
            txtPerfilTelefono1.Enabled = habilitar;
            txtPerfilCorreo1.Enabled = habilitar;
            txtPerfilDireccion1.Enabled = habilitar;
            dtpPerfilFechaNacimiento1.Enabled = habilitar;
            cbPerfilSexo1.Enabled = habilitar;
            txtPerfilPassword1.Enabled = habilitar;

            btnPerfilGuardar1.Enabled = habilitar;
        }



        private void tabInicio_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //este era el que me daba antes o me manba cuando le daba al boton a eliminar asi que quiero liminarlo porque ya le tengo con nombre a gregado pero no me salia y me salia este asi que sali y entre de nuevo y despues me salio el boton con el nombr que le habia puesto pero este se quedo aqui y lo quiero eliminar.
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol();

            rol.Nombre = txtNombreRol.Text;
            rol.Descripcion = txtDescripcion.Text;
            // rol.Estado = rbActivo.Checked;

            RolDAO rolDAO = new RolDAO();

            if (rolDAO.Guardar(rol))
            {
                MessageBox.Show("Rol guardado correctamente.");
                CargarRoles();
                CargarComboRoles();

                txtNombreRol.Clear();
                txtDescripcion.Clear();

                //rbActivo.Checked = true;
                txtNombreRol.Focus();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el rol.");
            }
        }






        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idRolSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un rol para editar.");
                return;
            }

            Rol rol = new Rol();

            rol.IdRol = idRolSeleccionado;
            rol.Nombre = txtNombreRol.Text;
            rol.Descripcion = txtDescripcion.Text;
            //rol.Estado = rbActivo.Checked;

            RolDAO rolDAO = new RolDAO();

            if (rolDAO.Actualizar(rol))
            {
                MessageBox.Show("Rol actualizado correctamente.");
                CargarRoles();
                btnLimpiar.PerformClick();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el rol.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreRol.Clear();
            txtDescripcion.Clear();

            // rbActivo.Checked = true;
            // rbInactivo.Checked = false;

            idRolSeleccionado = 0;

            txtNombreRol.Focus();
        }

        private void tablaRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void tablaRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idRolSeleccionado = Convert.ToInt32(tablaRoles.Rows[e.RowIndex].Cells["id_rol"].Value);

                txtNombreRol.Text = tablaRoles.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtDescripcion.Text = tablaRoles.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();

                bool estado = Convert.ToBoolean(tablaRoles.Rows[e.RowIndex].Cells["estado"].Value);

                //rbActivo.Checked = estado;
                //rbInactivo.Checked = !estado;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idRolSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un rol para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea eliminar este rol?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                RolDAO rolDAO = new RolDAO();

                if (rolDAO.Eliminar(idRolSeleccionado))
                {
                    MessageBox.Show("Rol eliminado correctamente.");

                    CargarRoles();

                    txtNombreRol.Clear();
                    txtDescripcion.Clear();

                    //rbActivo.Checked = true;
                    idRolSeleccionado = 0;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el rol.");
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el usuario.");
                txtUsuario.Focus();
                return;
            }

            if (txtContrasena.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la contraseña.");
                txtContrasena.Focus();
                return;
            }

            if (txtNombreCompleto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre completo.");
                txtNombreCompleto.Focus();
                return;
            }

            Usuario usuario = new Usuario();

            usuario.Nombre = txtNombreCompleto.Text.Trim();
            usuario.UsuarioLogin = txtUsuario.Text.Trim();
            usuario.Contrasena = txtContrasena.Text;
            usuario.IdRol = Convert.ToInt32(cbRol.SelectedValue);
            usuario.Estado = cbEstado.Text == "Activo";

            UsuarioDAO usuarioDAO = new UsuarioDAO();

            int idUsuario = usuarioDAO.Guardar(usuario);

            if (idUsuario > 0)
            {
                MessageBox.Show("Usuario guardado correctamente.");

                CargarUsuarios();

                btnLimpiarUsuario.PerformClick();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el usuario.");
            }
        }


        private void tablaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idUsuarioSeleccionado = Convert.ToInt32(
                    tablaUsuarios.Rows[e.RowIndex].Cells["id_usuario"].Value);

                txtNombreCompleto.Text =
                    tablaUsuarios.Rows[e.RowIndex].Cells["nombre"].Value.ToString();

                txtUsuario.Text =
                    tablaUsuarios.Rows[e.RowIndex].Cells["usuario"].Value.ToString();

                cbRol.SelectedValue =
                    tablaUsuarios.Rows[e.RowIndex].Cells["id_rol"].Value;

                bool estado = Convert.ToBoolean(
                    tablaUsuarios.Rows[e.RowIndex].Cells["estado"].Value);

                //rbActivoUsuario.Checked = estado;
                //rbInactivoUsuario.Checked = !estado;
            }

        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario para editar.");
                return;
            }

            if (txtUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el usuario.");
                txtUsuario.Focus();
                return;
            }

            if (txtContrasena.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la contraseña.");
                txtContrasena.Focus();
                return;
            }

            if (txtNombreCompleto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre completo.");
                txtNombreCompleto.Focus();
                return;
            }

            Usuario usuario = new Usuario();

            usuario.IdUsuario = idUsuarioSeleccionado;
            usuario.Nombre = txtNombreCompleto.Text;
            usuario.UsuarioLogin = txtUsuario.Text;
            usuario.Contrasena = txtContrasena.Text;
            usuario.IdRol = Convert.ToInt32(cbRol.SelectedValue);
            //usuario.Estado = rbActivoUsuario.Checked;

            UsuarioDAO usuarioDAO = new UsuarioDAO();

            if (usuarioDAO.Actualizar(usuario))
            {
                MessageBox.Show("Usuario actualizado correctamente.");

                CargarUsuarios();

                btnLimpiarUsuario.PerformClick();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el usuario.");
            }

        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                UsuarioDAO usuarioDAO = new UsuarioDAO();

                if (usuarioDAO.Eliminar(idUsuarioSeleccionado))
                {
                    MessageBox.Show("Usuario eliminado correctamente.");

                    CargarUsuarios();

                    txtUsuario.Clear();
                    txtContrasena.Clear();
                    txtNombreCompleto.Clear();

                    cbRol.SelectedIndex = 0;

                    //rbActivoUsuario.Checked = true;
                    //rbInactivoUsuario.Checked = false;

                    idUsuarioSeleccionado = 0;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.");
                }
            }
        }

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtNombreCompleto.Clear();

            cbRol.SelectedIndex = 0;

            cbEstado.SelectedItem = "Activo";
            //rbInactivoUsuario.Checked = false;

            idUsuarioSeleccionado = 0;

            txtUsuario.Focus();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            btnLimpiarUsuario.PerformClick();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //este era el que me daba antes o me manba cuando le daba al boton a activo asi que quiero liminarlo porque ya le tengo con nombre a gregado pero no me salia y me salia este asi que sali y entre de nuevo y despues me salio el boton con el nombr que le habia puesto pero este se quedo aqui y lo quiero eliminar.
        }

        private void lblSexoCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente.");
                txtNombreCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellidoCliente.Text))
            {
                MessageBox.Show("Ingrese el apellido del cliente.");
                txtApellidoCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCedulaCliente.Text))
            {
                MessageBox.Show("Ingrese la cédula del cliente.");
                txtCedulaCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefonoCliente.Text))
            {
                MessageBox.Show("Ingrese el teléfono del cliente.");
                txtTelefonoCliente.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cbSexoCliente.Text))
            {
                MessageBox.Show("Seleccione el sexo del cliente.");
                cbSexoCliente.Focus();
                return;
            }
            Cliente cliente = new Cliente();

            cliente.Nombre = txtNombreCliente.Text;
            cliente.Apellido = txtApellidoCliente.Text;
            cliente.Cedula = txtCedulaCliente.Text;
            cliente.Telefono = txtTelefonoCliente.Text;
            cliente.Correo = txtCorreoCliente.Text;
            cliente.Direccion = txtDireccionCliente.Text;
            cliente.FechaNacimiento = dtpFechaNacimiento.Value;
            cliente.Sexo = cbSexoCliente.Text;
            cliente.Foto = picFotoCliente.Tag?.ToString() ?? "";
            cliente.FechaRegistro = DateTime.Now;
            //cliente.Estado = rbActivoCliente.Checked;

            ClienteDAO clienteDAO = new ClienteDAO();

            if (clienteDAO.Guardar(cliente))
            {
                MessageBox.Show("Cliente guardado correctamente.");
                CargarClientes();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el cliente.");
            }

        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente para editar.");
                return;
            }

            Cliente cliente = new Cliente();

            cliente.IdCliente = idClienteSeleccionado;
            cliente.Nombre = txtNombreCliente.Text;
            cliente.Apellido = txtApellidoCliente.Text;
            cliente.Cedula = txtCedulaCliente.Text;
            cliente.Telefono = txtTelefonoCliente.Text;
            cliente.Correo = txtCorreoCliente.Text;
            cliente.Direccion = txtDireccionCliente.Text;
            cliente.FechaNacimiento = dtpFechaNacimiento.Value;
            cliente.Sexo = cbSexoCliente.Text;
            cliente.Foto = picFotoCliente.Tag?.ToString() ?? "";
            // cliente.Estado = rbActivoCliente.Checked;

            ClienteDAO clienteDAO = new ClienteDAO();

            if (clienteDAO.Actualizar(cliente))
            {
                MessageBox.Show("Cliente actualizado correctamente.");
                CargarClientes();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el cliente.");
            }
        }

        private void tablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idClienteSeleccionado = Convert.ToInt32(
                    tablaClientes.Rows[e.RowIndex].Cells["idcliente"].Value);

                txtNombreCliente.Text =
                    tablaClientes.Rows[e.RowIndex].Cells["nombre"].Value.ToString();

                txtApellidoCliente.Text =
                    tablaClientes.Rows[e.RowIndex].Cells["apellido"].Value.ToString();

                txtCedulaCliente.Text =
                    tablaClientes.Rows[e.RowIndex].Cells["cedula"].Value.ToString();

                txtTelefonoCliente.Text =
                    tablaClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();

                txtCorreoCliente.Text =
                    tablaClientes.Rows[e.RowIndex].Cells["correo"].Value.ToString();

                txtDireccionCliente.Text =
                    tablaClientes.Rows[e.RowIndex].Cells["direccion"].Value.ToString();

                dtpFechaNacimiento.Value =
                    Convert.ToDateTime(
                        tablaClientes.Rows[e.RowIndex].Cells["fechanacimiento"].Value);

                cbSexoCliente.Text =
                    tablaClientes.Rows[e.RowIndex].Cells["sexo"].Value.ToString();
                string rutaFoto = tablaClientes.Rows[e.RowIndex].Cells["Foto"].Value?.ToString();

                if (!string.IsNullOrEmpty(rutaFoto) && System.IO.File.Exists(rutaFoto))
                {
                    picFotoCliente.Image = Image.FromFile(rutaFoto);
                    picFotoCliente.Tag = rutaFoto;
                }
                else
                {
                    picFotoCliente.Image = null;
                    picFotoCliente.Tag = null;
                }

                bool estado = Convert.ToBoolean(
                    tablaClientes.Rows[e.RowIndex].Cells["estado"].Value);

                //rbActivoCliente.Checked = estado;
                //rbInactivoCliente.Checked = !estado;
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea eliminar este cliente?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                ClienteDAO clienteDAO = new ClienteDAO();

                if (clienteDAO.Eliminar(idClienteSeleccionado))
                {
                    MessageBox.Show("Cliente eliminado correctamente.");

                    CargarClientes();

                    txtNombreCliente.Clear();
                    txtApellidoCliente.Clear();
                    txtCedulaCliente.Clear();
                    txtTelefonoCliente.Clear();
                    txtCorreoCliente.Clear();
                    txtDireccionCliente.Clear();

                    //rbActivoCliente.Checked = true;
                    //rbInactivoCliente.Checked = false;

                    idClienteSeleccionado = 0;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente.");
                }
            }
        }

        private void btnLimpiarCliente_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtCedulaCliente.Clear();
            txtTelefonoCliente.Clear();
            txtCorreoCliente.Clear();
            txtDireccionCliente.Clear();

            dtpFechaNacimiento.Value = DateTime.Today;

            cbSexoCliente.SelectedIndex = -1;

            //rbActivoCliente.Checked = true;
            // rbInactivoCliente.Checked = false;

            picFotoCliente.Image = null;

            idClienteSeleccionado = 0;

            txtNombreCliente.Focus();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            btnLimpiarCliente.PerformClick();
        }

        private void btnAgregarFotoCliente_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirFoto = new OpenFileDialog();

            abrirFoto.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (abrirFoto.ShowDialog() == DialogResult.OK)
            {
                picFotoCliente.Image = Image.FromFile(abrirFoto.FileName);
                picFotoCliente.Tag = abrirFoto.FileName;
            }
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarCliente.Text.Trim().ToLower();

            ClienteDAO clienteDAO = new ClienteDAO();

            List<Cliente> clientes = clienteDAO.Listar();

            if (string.IsNullOrEmpty(texto))
            {
                tablaClientes.DataSource = clientes;
            }
            else
            {
                tablaClientes.DataSource = clientes
                    .Where(c =>
                        c.Nombre.ToLower().Contains(texto) ||
                        c.Apellido.ToLower().Contains(texto) ||
                        c.Cedula.ToLower().Contains(texto))
                    .ToList();
            }
        }

        private void cbSexoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Permisos(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbRolPermiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRolPermiso.SelectedIndex < 0)
                return;

            if (cbRolPermiso.SelectedValue == null ||
                cbRolPermiso.SelectedValue is DataRowView)
                return;

            int idRol = Convert.ToInt32(cbRolPermiso.SelectedValue);

            PermisosDAO permisosDAO = new PermisosDAO();

            List<Permiso> permisos = permisosDAO.ObtenerPorRol(idRol);

            LimpiarCheckBoxPermisos();

            foreach (Permiso permiso in permisos)
            {
                MarcarPermiso(permiso);
            }
        }
        private void LimpiarCheckBoxPermisos()
        {
            // Clientes
            chkClientesVer1.Checked = false;
            chkClientesCrear1.Checked = false;
            chkClientesEditar1.Checked = false;
            chkClientesEliminar1.Checked = false;

            // Usuarios
            chkUsuariosVer1.Checked = false;
            chkUsuariosCrear1.Checked = false;
            chkUsuariosEditar1.Checked = false;
            chkUsuariosEliminar1.Checked = false;

            // Roles
            chkRolesVer1.Checked = false;
            chkRolesCrear1.Checked = false;
            chkRolesEditar1.Checked = false;
            chkRolesEliminar1.Checked = false;

            // Entrenadores
            chkEntrenadoresVer1.Checked = false;
            chkEntrenadoresCrear1.Checked = false;
            chkEntrenadoresEditar1.Checked = false;
            chkEntrenadoresEliminar1.Checked = false;

            // Membresías
            chkMembresiasVer1.Checked = false;
            chkMembresiasCrear1.Checked = false;
            chkMembresiasEditar1.Checked = false;
            chkMembresiasEliminar1.Checked = false;

            // Productos
            chkProductosVer1.Checked = false;
            chkProductosCrear1.Checked = false;
            chkProductosEditar1.Checked = false;
            chkProductosEliminar1.Checked = false;

            // Proveedores
            chkProveedoresVer1.Checked = false;
            chkProveedoresCrear1.Checked = false;
            chkProveedoresEditar1.Checked = false;
            chkProveedoresEliminar1.Checked = false;
        }
        private void MarcarPermiso(Permiso permiso)
        {
            switch (permiso.Modulo)
            {
                case "Clientes":
                    chkClientesVer1.Checked = permiso.Ver;
                    chkClientesCrear1.Checked = permiso.Crear;
                    chkClientesEditar1.Checked = permiso.Editar;
                    chkClientesEliminar1.Checked = permiso.Eliminar;
                    break;

                case "Usuarios":
                    chkUsuariosVer1.Checked = permiso.Ver;
                    chkUsuariosCrear1.Checked = permiso.Crear;
                    chkUsuariosEditar1.Checked = permiso.Editar;
                    chkUsuariosEliminar1.Checked = permiso.Eliminar;
                    break;

                case "Roles":
                    chkRolesVer1.Checked = permiso.Ver;
                    chkRolesCrear1.Checked = permiso.Crear;
                    chkRolesEditar1.Checked = permiso.Editar;
                    chkRolesEliminar1.Checked = permiso.Eliminar;
                    break;

                case "Entrenadores":
                    chkEntrenadoresVer1.Checked = permiso.Ver;
                    chkEntrenadoresCrear1.Checked = permiso.Crear;
                    chkEntrenadoresEditar1.Checked = permiso.Editar;
                    chkEntrenadoresEliminar1.Checked = permiso.Eliminar;
                    break;

                case "Membresias":
                    chkMembresiasVer1.Checked = permiso.Ver;
                    chkMembresiasCrear1.Checked = permiso.Crear;
                    chkMembresiasEditar1.Checked = permiso.Editar;
                    chkMembresiasEliminar1.Checked = permiso.Eliminar;
                    break;

                case "Productos":
                    chkProductosVer1.Checked = permiso.Ver;
                    chkProductosCrear1.Checked = permiso.Crear;
                    chkProductosEditar1.Checked = permiso.Editar;
                    chkProductosEliminar1.Checked = permiso.Eliminar;
                    break;

                case "Proveedores":
                    chkProveedoresVer1.Checked = permiso.Ver;
                    chkProveedoresCrear1.Checked = permiso.Crear;
                    chkProveedoresEditar1.Checked = permiso.Editar;
                    chkProveedoresEliminar1.Checked = permiso.Eliminar;
                    break;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            RolDAO rolDAO = new RolDAO();

            cbRolPermiso.DataSource = rolDAO.CargarComboRoles();
            cbRolPermiso.DisplayMember = "nombre";
            cbRolPermiso.ValueMember = "id_rol";
            CargarEntrenadores();
            CargarProductos();
            CargarCategoriasYMarcas();
            CargarProveedores();
            CargarProductosCliente();


            cbProductoEstado1.Items.Clear();
            cbProductoEstado1.Items.Add("Activo");
            cbProductoEstado1.Items.Add("Inactivo");
            cbProductoEstado1.SelectedIndex = 0;

            AplicarPermisos();
            cbEntrenadorEstado1.Items.Clear();
            cbEntrenadorEstado1.Items.Add("Activo");
            cbEntrenadorEstado1.Items.Add("Inactivo");
            cbEntrenadorEstado1.SelectedIndex = 0;

            cbEntrenadorHoraInicio1.Items.Clear();
            cbEntrenadorHoraFin1.Items.Clear();

            string[] horarios =
            {
        "06:00 AM",
        "07:00 AM",
        "08:00 AM",
        "09:00 AM",
        "10:00 AM",
        "11:00 AM",
        "12:00 PM",
        "01:00 PM",
        "02:00 PM",
        "03:00 PM",
        "04:00 PM",
        "05:00 PM",
        "06:00 PM",
        "07:00 PM",
        "08:00 PM",
        "09:00 PM"
    };

            foreach (string hora in horarios)
            {
                cbEntrenadorHoraInicio1.Items.Add(hora);
                cbEntrenadorHoraFin1.Items.Add(hora);
            }
        }
        private void CargarEntrenadores()
        {
            EntrenadorDAO entrenadorDAO = new EntrenadorDAO();

            dgvEntrenadores1.DataSource = entrenadorDAO.Listar();
        }
        private void CargarProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();

            dgvProductos1.DataSource = productoDAO.Listar();
        }

        private void CargarCategoriasYMarcas()
        {
            ProductoDAO productoDAO = new ProductoDAO();

            cbProductoCategoria1.DataSource = productoDAO.CargarCategorias();
            cbProductoCategoria1.DisplayMember = "nombre";
            cbProductoCategoria1.ValueMember = "id_categoria";

            cbProductoMarca1.DataSource = productoDAO.CargarMarcas();
            cbProductoMarca1.DisplayMember = "nombre";
            cbProductoMarca1.ValueMember = "id_marca";
        }


        private void AplicarPermisos()
        {
            PermisosDAO permisosDAO = new PermisosDAO();

            List<Permiso> permisos = permisosDAO.ObtenerPorRol(idRolUsuario);

            // Guardamos qué módulos puede ver el usuario
            bool verRoles = false;
            bool verUsuarios = false;
            bool verClientes = false;
            bool verEntrenadores = false;
            bool verMembresias = false;
            bool verProductos = false;
            bool verProveedores = false;
            bool verPermisos = false;
            bool crearProductos = false;
            bool editarProductos = false;
            bool eliminarProductos = false;



            foreach (Permiso permiso in permisos)
            {
                if (!permiso.Ver)
                    continue;

                switch (permiso.Modulo)
                {
                    case "Roles":
                        verRoles = true;
                        break;

                    case "Usuarios":
                        verUsuarios = true;
                        break;

                    case "Clientes":
                        verClientes = true;
                        break;

                    case "Entrenadores":
                        verEntrenadores = true;
                        break;

                    case "Membresias":
                        verMembresias = true;
                        break;

                    case "Productos":
                        verProductos = true;
                        break;

                    case "Proveedores":
                        verProveedores = permiso.Ver;
                        break;


                    case "Permisos":
                        verPermisos = true;
                        break;
                }
            }

            // Quitamos solamente las pestañas controladas por permisos
            tabProductosClientes.TabPages.Remove(tabRoles);
            tabProductosClientes.TabPages.Remove(tabUsuarios);
            tabProductosClientes.TabPages.Remove(tabClientes);
            tabProductosClientes.TabPages.Remove(tabEntrenador);
            tabProductosClientes.TabPages.Remove(tabMembresias);
            tabProductosClientes.TabPages.Remove(tabProducto);
            tabProductosClientes.TabPages.Remove(tabProveedores);
            tabProductosClientes.TabPages.Remove(tabPermisos);

            if (verRoles)
                tabProductosClientes.TabPages.Add(tabRoles);

            if (verUsuarios)
                tabProductosClientes.TabPages.Add(tabUsuarios);

            if (verClientes)
                tabProductosClientes.TabPages.Add(tabClientes);

            if (verEntrenadores)
                tabProductosClientes.TabPages.Add(tabEntrenador);

            if (verMembresias)
                tabProductosClientes.TabPages.Add(tabMembresias);

            if (verProductos)
                tabProductosClientes.TabPages.Add(tabProducto);

            if (verProveedores)
                tabProductosClientes.TabPages.Add(tabProveedores);

            if (verPermisos)
                tabProductosClientes.TabPages.Add(tabPermisos);
            // Permisos de Productos
            btnProductoNuevo1.Enabled = crearProductos;
            btnProductoGuardar1.Enabled = crearProductos;
            btnProductoEditar1.Enabled = editarProductos;
            //btnProductoEliminar1.Enabled = eliminarProductos;
        }

        private void tabPermisos_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            if (cbRolPermiso.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un rol.");
                return;
            }

            int idRol = Convert.ToInt32(cbRolPermiso.SelectedValue);

            PermisosDAO permisosDAO = new PermisosDAO();

            bool resultado = true;

            // Clientes
            resultado &= permisosDAO.Guardar(new Permiso
            {
                IdRol = idRol,
                Modulo = "Clientes",
                Ver = chkClientesVer1.Checked,
                Crear = chkClientesCrear1.Checked,
                Editar = chkClientesEditar1.Checked,
                Eliminar = chkClientesEliminar1.Checked
            });

            // Usuarios
            resultado &= permisosDAO.Guardar(new Permiso
            {
                IdRol = idRol,
                Modulo = "Usuarios",
                Ver = chkUsuariosVer1.Checked,
                Crear = chkUsuariosCrear1.Checked,
                Editar = chkUsuariosEditar1.Checked,
                Eliminar = chkUsuariosEliminar1.Checked
            });

            // Roles
            resultado &= permisosDAO.Guardar(new Permiso
            {
                IdRol = idRol,
                Modulo = "Roles",
                Ver = chkRolesVer1.Checked,
                Crear = chkRolesCrear1.Checked,
                Editar = chkRolesEditar1.Checked,
                Eliminar = chkRolesEliminar1.Checked
            });

            // Entrenadores
            resultado &= permisosDAO.Guardar(new Permiso
            {
                IdRol = idRol,
                Modulo = "Entrenadores",
                Ver = chkEntrenadoresVer1.Checked,
                Crear = chkEntrenadoresCrear1.Checked,
                Editar = chkEntrenadoresEditar1.Checked,
                Eliminar = chkEntrenadoresEliminar1.Checked
            });

            // Membresías
            resultado &= permisosDAO.Guardar(new Permiso
            {
                IdRol = idRol,
                Modulo = "Membresias",
                Ver = chkMembresiasVer1.Checked,
                Crear = chkMembresiasCrear1.Checked,
                Editar = chkMembresiasEditar1.Checked,
                Eliminar = chkMembresiasEliminar1.Checked
            });

            // Productos
            resultado &= permisosDAO.Guardar(new Permiso
            {
                IdRol = idRol,
                Modulo = "Productos",
                Ver = chkProductosVer1.Checked,
                Crear = chkProductosCrear1.Checked,
                Editar = chkProductosEditar1.Checked,
                Eliminar = chkProductosEliminar1.Checked
            });

            // Proveedores
            resultado &= permisosDAO.Guardar(new Permiso
            {
                IdRol = idRol,
                Modulo = "Proveedores",
                Ver = chkProveedoresVer1.Checked,
                Crear = chkProveedoresCrear1.Checked,
                Editar = chkProveedoresEditar1.Checked,
                Eliminar = chkProveedoresEliminar1.Checked
            });

            if (resultado)
            {
                MessageBox.Show("Permisos guardados correctamente.");
            }
            else
            {
                MessageBox.Show("No se pudieron guardar los permisos.");
            }
        }

        private void btnEntrenadorGuardar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEntrenadorNombre1.Text) ||
    string.IsNullOrWhiteSpace(txtEntrenadorApellido1.Text) ||
    string.IsNullOrWhiteSpace(txtEntrenadorTelefono1.Text) ||
    string.IsNullOrWhiteSpace(txtEntrenadorCorreo1.Text) ||
    string.IsNullOrWhiteSpace(txtEntrenadorEspecialidad1.Text))
                {
                    MessageBox.Show(
                        "Por favor, complete todos los campos del entrenador.",
                        "Campos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cbEntrenadorHoraInicio1.SelectedIndex == -1 ||
                    cbEntrenadorHoraFin1.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Seleccione la hora de inicio y la hora de fin.",
                        "Horario",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cbEntrenadorHoraInicio1.SelectedIndex >=
                    cbEntrenadorHoraFin1.SelectedIndex)
                {
                    MessageBox.Show(
                        "La hora de inicio debe ser menor que la hora de fin.",
                        "Horario inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cbEntrenadorEstado1.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Seleccione el estado del entrenador.",
                        "Estado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Entrenador entrenador = new Entrenador();

                entrenador.Nombre = txtEntrenadorNombre1.Text.Trim();
                entrenador.Apellido = txtEntrenadorApellido1.Text.Trim();
                entrenador.Telefono = txtEntrenadorTelefono1.Text.Trim();
                entrenador.Correo = txtEntrenadorCorreo1.Text.Trim();
                entrenador.Especialidad = txtEntrenadorEspecialidad1.Text.Trim();
                entrenador.Horario =
                cbEntrenadorHoraInicio1.Text + " - " +
                cbEntrenadorHoraFin1.Text;

                entrenador.Estado = picEntrenadorFoto1.Text == "Activo";

                entrenador.Foto = rutaFotoEntrenador;

                EntrenadorDAO entrenadorDAO = new EntrenadorDAO();

                bool resultado = entrenadorDAO.Guardar(entrenador);

                if (resultado)
                {
                    MessageBox.Show(
                        "Entrenador guardado correctamente.",
                        "Entrenadores",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarEntrenadores();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo guardar el entrenador.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEntrenadorFoto1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar foto del entrenador";
                dialogo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    rutaFotoEntrenador = dialogo.FileName;

                    picEntrenadorFoto1.Image = Image.FromFile(rutaFotoEntrenador);
                    picEntrenadorFoto1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void txtEntrenadorNombre1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrenadorNuevo1_Click(object sender, EventArgs e)
        {
            txtEntrenadorNombre1.Clear();
            txtEntrenadorApellido1.Clear();
            txtEntrenadorTelefono1.Clear();
            txtEntrenadorCorreo1.Clear();
            txtEntrenadorEspecialidad1.Clear();

            cbEntrenadorHoraInicio1.SelectedIndex = -1;
            cbEntrenadorHoraFin1.SelectedIndex = -1;
            cbEntrenadorEstado1.SelectedIndex = -1;

            picEntrenadorFoto1.Image = null;

            rutaFotoEntrenador = null;
        }

        private void dgvEntrenadores1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            idEntrenadorSeleccionado =
            Convert.ToInt32(dgvEntrenadores1.Rows[e.RowIndex].Cells["id_entrenador"].Value);

            DataGridViewRow fila = dgvEntrenadores1.Rows[e.RowIndex];

            txtEntrenadorNombre1.Text = fila.Cells["nombre"].Value?.ToString();
            txtEntrenadorApellido1.Text = fila.Cells["apellido"].Value?.ToString();
            txtEntrenadorTelefono1.Text = fila.Cells["telefono"].Value?.ToString();
            txtEntrenadorCorreo1.Text = fila.Cells["correo"].Value?.ToString();
            txtEntrenadorEspecialidad1.Text = fila.Cells["especialidad"].Value?.ToString();

            string horario = fila.Cells["horario"].Value?.ToString();

            if (!string.IsNullOrEmpty(horario) && horario.Contains(" - "))
            {
                string[] partes = horario.Split(new[] { " - " }, StringSplitOptions.None);

                cbEntrenadorHoraInicio1.Text = partes[0];
                cbEntrenadorHoraFin1.Text = partes[1];
            }

            bool estado = Convert.ToBoolean(fila.Cells["estado"].Value);
            cbEntrenadorEstado1.Text = estado ? "Activo" : "Inactivo";

            rutaFotoEntrenador = fila.Cells["foto"].Value?.ToString();

            if (!string.IsNullOrEmpty(rutaFotoEntrenador) &&
                File.Exists(rutaFotoEntrenador))
            {
                picEntrenadorFoto1.Image = Image.FromFile(rutaFotoEntrenador);
                picEntrenadorFoto1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picEntrenadorFoto1.Image = null;
            }
        }

        private void btnEntrenadorEditar1_Click(object sender, EventArgs e)
        {
            if (idEntrenadorSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un entrenador para editar.",
                    "Editar entrenador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            Entrenador entrenador = new Entrenador();

            entrenador.IdEntrenador = idEntrenadorSeleccionado;

            entrenador.Nombre = txtEntrenadorNombre1.Text.Trim();
            entrenador.Apellido = txtEntrenadorApellido1.Text.Trim();
            entrenador.Telefono = txtEntrenadorTelefono1.Text.Trim();
            entrenador.Correo = txtEntrenadorCorreo1.Text.Trim();
            entrenador.Especialidad = txtEntrenadorEspecialidad1.Text.Trim();

            entrenador.Horario =
                cbEntrenadorHoraInicio1.Text + " - " +
                cbEntrenadorHoraFin1.Text;

            entrenador.Estado = cbEntrenadorEstado1.Text == "Activo";

            entrenador.Foto = rutaFotoEntrenador;

            EntrenadorDAO entrenadorDAO = new EntrenadorDAO();

            bool resultado = entrenadorDAO.Actualizar(entrenador);

            if (resultado)
            {
                MessageBox.Show(
                    "Entrenador actualizado correctamente.",
                    "Editar entrenador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarEntrenadores();

                idEntrenadorSeleccionado = 0;
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar el entrenador.",
                    "Editar entrenador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEntrenadorEliminar1_Click(object sender, EventArgs e)
        {
            if (idEntrenadorSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un entrenador para eliminar.",
                    "Eliminar entrenador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar este entrenador?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            EntrenadorDAO entrenadorDAO = new EntrenadorDAO();

            bool resultado = entrenadorDAO.Eliminar(idEntrenadorSeleccionado);

            if (resultado)
            {
                MessageBox.Show(
                    "Entrenador eliminado correctamente.",
                    "Eliminar entrenador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarEntrenadores();

                idEntrenadorSeleccionado = 0;


                txtEntrenadorNombre1.Clear();
                txtEntrenadorApellido1.Clear();
                txtEntrenadorTelefono1.Clear();
                txtEntrenadorCorreo1.Clear();
                txtEntrenadorEspecialidad1.Clear();

                cbEntrenadorHoraInicio1.SelectedIndex = -1;
                cbEntrenadorHoraFin1.SelectedIndex = -1;
                cbEntrenadorEstado1.SelectedIndex = -1;

                picEntrenadorFoto1.Image = null;
                rutaFotoEntrenador = null;
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar el entrenador.",
                    "Eliminar entrenador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnProductoGuardar1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El botón Guardar sí está entrando al código.");
            if (string.IsNullOrWhiteSpace(txtProductoCodigo1.Text))
            {
                MessageBox.Show(
                    "Ingrese el código del producto.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtProductoCodigo1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductoNombre1.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del producto.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtProductoNombre1.Focus();
                return;
            }

            if (cbProductoCategoria1.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione una categoría.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cbProductoMarca1.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione una marca.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (nudProductoPrecioVenta1.Value <= 0)
            {
                MessageBox.Show(
                    "El precio de venta debe ser mayor que 0.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                nudProductoPrecioVenta1.Focus();
                return;
            }
            Producto producto = new Producto();

            producto.Codigo = txtProductoCodigo1.Text.Trim();
            producto.Nombre = txtProductoNombre1.Text.Trim();
            producto.Descripcion = txtProductoDescripcion1.Text.Trim();

            producto.IdCategoria =
                Convert.ToInt32(cbProductoCategoria1.SelectedValue);

            producto.PrecioCompra = nudProductoPrecioCompra1.Value;
            producto.PrecioVenta = nudProductoPrecioVenta1.Value;

            producto.Stock = Convert.ToInt32(nudProductoStock1.Value);
            producto.StockMinimo = Convert.ToInt32(nudProductoStockMinimo1.Value);

            producto.IdMarca =
                Convert.ToInt32(cbProductoMarca1.SelectedValue);

            producto.Estado = cbProductoEstado1.Text == "Activo";

            producto.Imagen = rutaFotoProducto;

            ProductoDAO productoDAO = new ProductoDAO();

            bool resultado = productoDAO.Guardar(producto);

            if (resultado)
            {
                MessageBox.Show(
                    "Producto guardado correctamente.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarProductos();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo guardar el producto.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cbProductoMarca1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnProductoNuevo1_Click(object sender, EventArgs e)
        {
            txtProductoCodigo1.Clear();
            txtProductoNombre1.Clear();
            txtProductoDescripcion1.Clear();

            nudProductoPrecioCompra1.Value = 0;
            nudProductoPrecioVenta1.Value = 0;
            nudProductoStock1.Value = 0;
            nudProductoStockMinimo1.Value = 0;

            if (cbProductoCategoria1.Items.Count > 0)
                cbProductoCategoria1.SelectedIndex = 0;

            if (cbProductoMarca1.Items.Count > 0)
                cbProductoMarca1.SelectedIndex = 0;

            cbProductoEstado1.SelectedIndex = 0;

            picProductoFoto1.Image = null;

            rutaFotoProducto = null;

            txtProductoCodigo1.Focus();
        }

        private void picProductoFoto1_Click(object sender, EventArgs e)
        {

        }

        private void btnProductoFoto1_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirFoto = new OpenFileDialog();

            abrirFoto.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
            abrirFoto.Title = "Seleccionar foto del producto";

            if (abrirFoto.ShowDialog() == DialogResult.OK)
            {
                rutaFotoProducto = abrirFoto.FileName;

                picProductoFoto1.Image = Image.FromFile(rutaFotoProducto);
                picProductoFoto1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }


        private void tabProducto_Click(object sender, EventArgs e)
        {

        }
        private void dgvProductos1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvProductos1.Rows[e.RowIndex];

            idProductoSeleccionado = Convert.ToInt32(fila.Cells["id_producto"].Value);

            txtProductoCodigo1.Text = fila.Cells["codigo"].Value?.ToString();
            txtProductoNombre1.Text = fila.Cells["nombre"].Value?.ToString();
            txtProductoDescripcion1.Text = fila.Cells["descripcion"].Value?.ToString();

            if (fila.Cells["id_categoria"].Value != DBNull.Value)
            {
                cbProductoCategoria1.SelectedValue =
                    Convert.ToInt32(fila.Cells["id_categoria"].Value);
            }

            if (fila.Cells["id_marca"].Value != DBNull.Value)
            {
                cbProductoMarca1.SelectedValue =
                    Convert.ToInt32(fila.Cells["id_marca"].Value);
            }

            if (fila.Cells["precio_compra"].Value != DBNull.Value)
            {
                nudProductoPrecioCompra1.Value =
                    Convert.ToDecimal(fila.Cells["precio_compra"].Value);
            }

            if (fila.Cells["precio_venta"].Value != DBNull.Value)
            {
                nudProductoPrecioVenta1.Value =
                    Convert.ToDecimal(fila.Cells["precio_venta"].Value);
            }

            if (fila.Cells["stock"].Value != DBNull.Value)
            {
                nudProductoStock1.Value =
                    Convert.ToDecimal(fila.Cells["stock"].Value);
            }

            if (fila.Cells["stock_minimo"].Value != DBNull.Value)
            {
                nudProductoStockMinimo1.Value =
                    Convert.ToDecimal(fila.Cells["stock_minimo"].Value);
            }

            if (fila.Cells["estado"].Value != DBNull.Value)
            {
                bool estado = Convert.ToBoolean(fila.Cells["estado"].Value);
                cbProductoEstado1.Text = estado ? "Activo" : "Inactivo";
            }

            rutaFotoProducto = fila.Cells["imagen"].Value?.ToString();
        }

        private void btnProductoEditar1_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto para editar.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            Producto producto = new Producto();

            producto.IdProducto = idProductoSeleccionado;
            producto.Codigo = txtProductoCodigo1.Text.Trim();
            producto.Nombre = txtProductoNombre1.Text.Trim();
            producto.Descripcion = txtProductoDescripcion1.Text.Trim();

            producto.IdCategoria = Convert.ToInt32(cbProductoCategoria1.SelectedValue);
            producto.IdMarca = Convert.ToInt32(cbProductoMarca1.SelectedValue);

            producto.PrecioCompra = nudProductoPrecioCompra1.Value;
            producto.PrecioVenta = nudProductoPrecioVenta1.Value;
            producto.Stock = Convert.ToInt32(nudProductoStock1.Value);
            producto.StockMinimo = Convert.ToInt32(nudProductoStockMinimo1.Value);

            producto.Estado = cbProductoEstado1.Text == "Activo";
            producto.Imagen = rutaFotoProducto;

            ProductoDAO productoDAO = new ProductoDAO();

            if (productoDAO.Actualizar(producto))
            {
                MessageBox.Show(
                    "Producto actualizado correctamente.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarProductos();

                idProductoSeleccionado = 0;
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar el producto.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnProductoEliminar1_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto para eliminar.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            DialogResult confirmar = MessageBox.Show(
              "¿Está seguro de que desea eliminar este producto?",
               "Eliminar producto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
            {
                return;
            }

            ProductoDAO productoDAO = new ProductoDAO();

            if (productoDAO.Eliminar(idProductoSeleccionado))
            {
                MessageBox.Show(
                    "Producto eliminado correctamente.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarProductos();

                idProductoSeleccionado = 0;
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar el producto.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtProductoBuscar1_TextChanged(object sender, EventArgs e)
        {
            ProductoDAO productoDAO = new ProductoDAO();

            string texto = txtProductoBuscar1.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                dgvProductos1.DataSource = productoDAO.Listar();
            }
            else
            {
                dgvProductos1.DataSource = productoDAO.Buscar(texto);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPerfilEditar1_Click(object sender, EventArgs e)
        {

        }

        private void btnPerfilFoto1_Click(object sender, EventArgs e)
        {
            HabilitarEdicionPerfil(true);
        }

        private void picPerfilFoto1_Click(object sender, EventArgs e)
        {

        }

        private void tabMiPerfil_Click(object sender, EventArgs e)
        {

        }

        private void btnProveedorGuardar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProveedor1.Text))
            {
                MessageBox.Show("Ingrese el nombre del proveedor.");
                txtNombreProveedor1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmpresaProveedor1.Text))
            {
                MessageBox.Show("Ingrese la empresa.");
                txtEmpresaProveedor1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefonoProveedor1.Text))
            {
                MessageBox.Show("Ingrese el teléfono.");
                txtTelefonoProveedor1.Focus();
                return;
            }

            Proveedor proveedor = new Proveedor();

            proveedor.Nombre = txtNombreProveedor1.Text;
            proveedor.Empresa = txtEmpresaProveedor1.Text;
            proveedor.Telefono = txtTelefonoProveedor1.Text;
            proveedor.Correo = txtCorreoProveedor1.Text;
            proveedor.Direccion = txtDireccionProveedor1.Text;
            //proveedor.Estado = rbActivoProveedor1.Checked;

            ProveedorDAO proveedorDAO = new ProveedorDAO();

            if (proveedorDAO.Guardar(proveedor))
            {
                MessageBox.Show("Proveedor guardado correctamente.");

                CargarProveedores();

                btnProveedorNuevo1.PerformClick();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el proveedor.");
            }
        }

        private void dgvProveedores1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProveedores1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvProveedores1.Rows[e.RowIndex];

            idProveedorSeleccionado = Convert.ToInt32(
                fila.Cells["IdProveedor"].Value
            );

            txtNombreProveedor1.Text =
                fila.Cells["Nombre"].Value?.ToString() ?? "";

            txtEmpresaProveedor1.Text =
                fila.Cells["Empresa"].Value?.ToString() ?? "";

            txtTelefonoProveedor1.Text =
                fila.Cells["Telefono"].Value?.ToString() ?? "";

            txtCorreoProveedor1.Text =
                fila.Cells["Correo"].Value?.ToString() ?? "";

            txtDireccionProveedor1.Text =
                fila.Cells["Direccion"].Value?.ToString() ?? "";

            bool estado = Convert.ToBoolean(
                fila.Cells["Estado"].Value
            );

            //rbActivoProveedor1.Checked = estado;
            //rbInactivoProveedor1.Checked = !estado;
        }

        private void btnProveedorEditar1_Click(object sender, EventArgs e)
        {
            if (idProveedorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un proveedor para editar.");
                return;
            }

            Proveedor proveedor = new Proveedor();

            proveedor.IdProveedor = idProveedorSeleccionado;
            proveedor.Nombre = txtNombreProveedor1.Text;
            proveedor.Empresa = txtEmpresaProveedor1.Text;
            proveedor.Telefono = txtTelefonoProveedor1.Text;
            proveedor.Correo = txtCorreoProveedor1.Text;
            proveedor.Direccion = txtDireccionProveedor1.Text;
            //proveedor.Estado = rbActivoProveedor1.Checked;

            ProveedorDAO proveedorDAO = new ProveedorDAO();

            if (proveedorDAO.Actualizar(proveedor))
            {
                MessageBox.Show("Proveedor actualizado correctamente.");

                CargarProveedores();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el proveedor.");
            }
        }

        private void btnProveedorEliminar1_Click(object sender, EventArgs e)
        {
            if (idProveedorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar este proveedor?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.No)
            {
                return;
            }

            ProveedorDAO proveedorDAO = new ProveedorDAO();

            if (proveedorDAO.Eliminar(idProveedorSeleccionado))
            {
                MessageBox.Show("Proveedor eliminado correctamente.");

                CargarProveedores();

                idProveedorSeleccionado = 0;
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el proveedor.");
            }
        }

        private void btnProveedorNuevo1_Click(object sender, EventArgs e)
        {
            txtNombreProveedor1.Clear();
            txtEmpresaProveedor1.Clear();
            txtTelefonoProveedor1.Clear();
            txtCorreoProveedor1.Clear();
            txtDireccionProveedor1.Clear();
            txtBuscarProveedor1.Clear();
            //rbActivoProveedor1.Checked = true;
            //rbInactivoProveedor1.Checked = false;

            idProveedorSeleccionado = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarProveedor1_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarProveedor1.Text.Trim().ToLower();

            ProveedorDAO proveedorDAO = new ProveedorDAO();

            List<Proveedor> proveedores = proveedorDAO.Listar();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvProveedores1.DataSource = proveedores;
                return;
            }

            List<Proveedor> resultados = proveedores
                .Where(p =>
                    p.Nombre.ToLower().Contains(texto) ||
                    p.Empresa.ToLower().Contains(texto) ||
                    p.Telefono.ToLower().Contains(texto) ||
                    p.Correo.ToLower().Contains(texto))
                .ToList();

            dgvProveedores1.DataSource = resultados;
        }

        private void btnMembresiaGuardar1_Click(object sender, EventArgs e)
        {
            if (cbMembresiaCliente1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            if (cbMembresiaTipo1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el tipo de membresía.");
                return;
            }

            if (textCostodeMembresia.Text == "")
            {
                MessageBox.Show("Ingrese el costo de la membresía.");
                textCostodeMembresia.Focus();
                return;
            }

            Membresia membresia = new Membresia();

            membresia.IdCliente = Convert.ToInt32(cbMembresiaCliente1.SelectedValue);
            membresia.Tipo = cbMembresiaTipo1.SelectedItem.ToString();
            membresia.FechaInicio = dtpMembresiaFechaInicio1.Value.Date;
            membresia.FechadeExpiracion = dtpMembresiaFechadeExpiracion1.Value.Date;
            membresia.CostodeMembresia = Convert.ToDecimal(textCostodeMembresia.Text);
            //membresia.Estado = rbActivoMembresia1.Checked;

            MembresiaDAO membresiaDAO = new MembresiaDAO();

            if (membresiaDAO.Guardar(membresia))
            {
                MessageBox.Show("Membresía guardada correctamente.");

                CargarMembrecias();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la membresía.");
            }
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabRoles;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabUsuarios;
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabPermisos;
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabClientes;
        }

        private void entrenadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabEntrenador;
        }

        private void membresiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabMembresias;
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabProducto;
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabProveedores;
        }

        private void miPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabMiPerfil;
        }

        private void btnMembresiaNuevo1_Click(object sender, EventArgs e)
        {
            cbMembresiaCliente1.SelectedIndex = -1;
            cbMembresiaTipo1.SelectedIndex = -1;

            dtpMembresiaFechaInicio1.Value = DateTime.Today;
            dtpMembresiaFechadeExpiracion1.Value = DateTime.Today;

            textCostodeMembresia.Clear();

            //rbActivoMembresia1.Checked = true;

            cbMembresiaCliente1.Focus();
        }

        private void btnMembresiaEditar1_Click(object sender, EventArgs e)
        {
            if (idMembresiaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una membresía para editar.");
                return;
            }

            try
            {
                Membresia membresia = new Membresia();

                membresia.IdMembresia = idMembresiaSeleccionada;

                if (cbMembresiaCliente1.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un cliente.");
                    return;
                }

                if (cbMembresiaTipo1.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione el tipo de membresía.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textCostodeMembresia.Text))
                {
                    MessageBox.Show("Ingrese el costo de la membresía.");
                    return;
                }

                membresia.IdCliente = Convert.ToInt32(
                    cbMembresiaCliente1.SelectedValue);

                membresia.Tipo = cbMembresiaTipo1.SelectedItem.ToString();

                membresia.FechaInicio =
                    dtpMembresiaFechaInicio1.Value.Date;

                membresia.FechadeExpiracion =
                    dtpMembresiaFechadeExpiracion1.Value.Date;

                membresia.CostodeMembresia =
                    Convert.ToDecimal(textCostodeMembresia.Text);

                //membresia.Estado =
                //rbActivoMembresia1.Checked;

                MembresiaDAO membresiaDAO = new MembresiaDAO();

                if (membresiaDAO.Actualizar(membresia))
                {
                    MessageBox.Show("Membresía actualizada correctamente.");

                    CargarMembrecias();

                    idMembresiaSeleccionada = 0;
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la membresía.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al editar la membresía: " + ex.Message);
            }
        }

        private void btnMembresiaEliminar1_Click(object sender, EventArgs e)
        {
            if (idMembresiaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una membresía para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta membresía?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado != DialogResult.Yes)
                return;

            MembresiaDAO membresiaDAO = new MembresiaDAO();

            if (membresiaDAO.Eliminar(idMembresiaSeleccionada))
            {
                MessageBox.Show("Membresía eliminada correctamente.");

                CargarMembrecias();

                idMembresiaSeleccionada = 0;
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la membresía.");
            }
        }

        private void dgvMembresias1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvMembresias1.Rows[e.RowIndex];

            idMembresiaSeleccionada = Convert.ToInt32(
                fila.Cells["IdMembresia"].Value);

            cbMembresiaCliente1.SelectedValue = Convert.ToInt32(
                fila.Cells["IdCliente"].Value);

            cbMembresiaTipo1.Text =
                fila.Cells["Tipo"].Value.ToString();

            dtpMembresiaFechaInicio1.Value = Convert.ToDateTime(
                fila.Cells["FechaInicio"].Value);

            dtpMembresiaFechadeExpiracion1.Value = Convert.ToDateTime(
                fila.Cells["FechadeExpiracion"].Value);

            textCostodeMembresia.Text =
                fila.Cells["CostodeMembresia"].Value.ToString();

            // rbActivoMembresia1.Checked =
            Convert.ToBoolean(fila.Cells["Estado"].Value);
        }

        private void cbMembresiaCliente1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPagoDiarioGuardarPrecio1_Click(object sender, EventArgs e)
        {
            decimal precio = nudPagoDiarioPrecio1.Value;

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que 0.");
                nudPagoDiarioPrecio1.Focus();
                return;
            }

            Properties.Settings.Default.PrecioEntrada = precio;
            Properties.Settings.Default.Save();

            MessageBox.Show("Precio guardado correctamente.");
        }

        private void btnPagoDiarioGuardar1_Click(object sender, EventArgs e)
        {
            if (nudPagoDiarioPrecio1.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que 0.");
                nudPagoDiarioPrecio1.Focus();
                return;
            }

            if (cbPagoDiarioMetodoPago1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el método de pago.");
                cbPagoDiarioMetodoPago1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPagoDiarioConcepto1.Text))
            {
                MessageBox.Show("Ingrese el concepto.");
                txtPagoDiarioConcepto1.Focus();
                return;
            }

            if (cbPagoDiarioEstado1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado.");
                cbPagoDiarioEstado1.Focus();
                return;
            }

            PagoDiario pago = new PagoDiario();

            pago.Fecha = dtpPagoDiarioFecha1.Value.Date;

            pago.PrecioEntrada = nudPagoDiarioPrecio1.Value;

            pago.MetodoPago =
                cbPagoDiarioMetodoPago1.SelectedItem.ToString();

            pago.Concepto =
                txtPagoDiarioConcepto1.Text.Trim();

            pago.Estado =
      cbPagoDiarioEstado1.SelectedItem.ToString();

            PagoDiarioDAO pagoDiarioDAO = new PagoDiarioDAO();

            if (pagoDiarioDAO.Guardar(pago))
            {
                MessageBox.Show("Pago diario guardado correctamente.");

                if (pagoDiarioDAO.Guardar(pago))
                {
                    MessageBox.Show("Pago diario guardado correctamente.");

                    CargarPagosDiarios();

                    nudPagoDiarioPrecio1.Value = 0;
                    dtpPagoDiarioFecha1.Value = DateTime.Today;
                    cbPagoDiarioMetodoPago1.SelectedIndex = -1;
                    txtPagoDiarioConcepto1.Text = "Entrada diaria";
                    cbPagoDiarioEstado1.SelectedIndex = -1;
                }
                nudPagoDiarioPrecio1.Value = 0;
                dtpPagoDiarioFecha1.Value = DateTime.Today;
                cbPagoDiarioMetodoPago1.SelectedIndex = -1;
                txtPagoDiarioConcepto1.Text = "Entrada diaria";
                cbPagoDiarioEstado1.SelectedIndex = -1;


            }
            else
            {
                MessageBox.Show("No se pudo guardar el pago diario.");
            }

        }

        private void btnPagoDiarioNuevo1_Click(object sender, EventArgs e)
        {
            nudPagoDiarioPrecio1.Value = 0;

            dtpPagoDiarioFecha1.Value = DateTime.Today;

            cbPagoDiarioMetodoPago1.SelectedIndex = -1;

            txtPagoDiarioConcepto1.Text = "Entrada diaria";

            cbPagoDiarioEstado1.SelectedIndex = -1;

            nudPagoDiarioPrecio1.Focus();
        }

        private void dgvPagosDiarios1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { // por error le di a el que no era y no lo puedo eliminar por que me da error.
        }

        private void dgvPagosDiarios1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvPagosDiarios1.Rows[e.RowIndex];

            PagoDiario pago = fila.DataBoundItem as PagoDiario;

            if (pago == null)
                return;

            idPagoSeleccionado = pago.IdPago;

            nudPagoDiarioPrecio1.Value = pago.PrecioEntrada;

            dtpPagoDiarioFecha1.Value = pago.Fecha;

            cbPagoDiarioMetodoPago1.Text = pago.MetodoPago;

            txtPagoDiarioConcepto1.Text = pago.Concepto;

            cbPagoDiarioEstado1.Text = pago.Estado;

        }

        private void btnPagoDiarioEditar1_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un pago para editar.");
                return;
            }

            if (nudPagoDiarioPrecio1.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que 0.");
                nudPagoDiarioPrecio1.Focus();
                return;
            }

            if (cbPagoDiarioMetodoPago1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el método de pago.");
                cbPagoDiarioMetodoPago1.Focus();
                return;
            }

            PagoDiario pago = new PagoDiario();

            pago.IdPago = idPagoSeleccionado;
            pago.Fecha = dtpPagoDiarioFecha1.Value.Date;
            pago.PrecioEntrada = nudPagoDiarioPrecio1.Value;
            pago.MetodoPago =
                cbPagoDiarioMetodoPago1.SelectedItem.ToString();
            pago.Concepto =
                txtPagoDiarioConcepto1.Text.Trim();
            pago.Estado =
    cbPagoDiarioEstado1.SelectedItem.ToString();

            PagoDiarioDAO pagoDiarioDAO = new PagoDiarioDAO();

            if (pagoDiarioDAO.Actualizar(pago))
            {
                MessageBox.Show("Pago actualizado correctamente.");

                CargarPagosDiarios();

                idPagoSeleccionado = 0;
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el pago.");
            }
        }

        private void btnPagoDiarioConsultar1_Click(object sender, EventArgs e)
        {

        }

        private void cbPagoDiarioMetodoPago1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PagoDiarioDAO pagoDAO = new PagoDiarioDAO();

            DateTime fecha = dtpPagoDiarioFecha1.Value.Date;

            dgvPagosDiarios1.DataSource = null;
            dgvPagosDiarios1.DataSource = pagoDAO.ListarPorFecha(fecha);
        }

        private void btnPagoDiarioEliminar1_Click(object sender, EventArgs e)
        {
            if (idPagoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un pago para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar este pago?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado != DialogResult.Yes)
                return;

            PagoDiarioDAO pagoDiarioDAO = new PagoDiarioDAO();

            if (pagoDiarioDAO.Eliminar(idPagoSeleccionado))
            {
                MessageBox.Show("Pago eliminado correctamente.");

                CargarPagosDiarios();

                idPagoSeleccionado = 0;

                nudPagoDiarioPrecio1.Value = 0;
                dtpPagoDiarioFecha1.Value = DateTime.Today;
                cbPagoDiarioMetodoPago1.SelectedIndex = -1;
                txtPagoDiarioConcepto1.Text = "Entrada diaria";
                cbPagoDiarioEstado1.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el pago.");
            }
        }

        private void tabPagoDiario_Click(object sender, EventArgs e)
        {

        }

        private void lblPagoDiarioTotalMonto1_Click(object sender, EventArgs e)
        {

        }

        private void MostrarTotalDelDia()
        {
            PagoDiarioDAO pagoDAO = new PagoDiarioDAO();

            DateTime fecha = dtpPagoDiarioFecha1.Value.Date;

            decimal total = pagoDAO.ObtenerTotalDelDia(fecha);

            lblPagoDiarioTotalMonto1.Text = total.ToString("C2");
        }

        private void lblPagoDiarioTotal1_Click(object sender, EventArgs e)
        {
            PagoDiarioDAO pagoDAO = new PagoDiarioDAO();

            DateTime fecha = dtpPagoDiarioFecha1.Value.Date;

            dgvPagosDiarios1.DataSource = null;
            dgvPagosDiarios1.DataSource = pagoDAO.ListarPorFecha(fecha);

            MostrarTotalDelDia();
        }

        private void ActualizarTotalPagoDiario()
        {
            PagoDiarioDAO pagoDAO = new PagoDiarioDAO();

            DateTime fecha = dtpPagoDiarioFecha1.Value.Date;

            decimal total = pagoDAO.ObtenerTotalDelDia(fecha);

            lblPagoDiarioTotalMonto1.Text = total.ToString("C2");
        }

        private void lblProductosClienteBuscar1_Click(object sender, EventArgs e)
        {

        }
        private void CargarProductosCliente()
        {
            ProductoDAO productoDAO = new ProductoDAO();

            DataTable tabla = productoDAO.Listar();

            dgvProductosCliente1.DataSource = tabla;

            // Ocultar información que el cliente NO debe ver
            dgvProductosCliente1.Columns["id_producto"].Visible = false;
            dgvProductosCliente1.Columns["codigo"].Visible = false;
            dgvProductosCliente1.Columns["id_categoria"].Visible = false;
            dgvProductosCliente1.Columns["categoria"].Visible = false;
            dgvProductosCliente1.Columns["precio_compra"].Visible = false;
            dgvProductosCliente1.Columns["stock_minimo"].Visible = false;
            dgvProductosCliente1.Columns["imagen"].Visible = false;
            dgvProductosCliente1.Columns["id_marca"].Visible = false;
            dgvProductosCliente1.Columns["marca"].Visible = false;

            // Nombres que verá el cliente
            dgvProductosCliente1.Columns["nombre"].HeaderText = "Producto";
            dgvProductosCliente1.Columns["descripcion"].HeaderText = "Descripción";
            dgvProductosCliente1.Columns["precio_venta"].HeaderText = "Precio de venta";
            dgvProductosCliente1.Columns["stock"].HeaderText = "Disponibilidad";
        }

        private void btnProductosClienteBuscar1_Click(object sender, EventArgs e)
        {
            string texto = txtProductosClienteBuscar1.Text.Trim();

            ProductoDAO productoDAO = new ProductoDAO();

            dgvProductosCliente1.DataSource = productoDAO.BuscarParaCliente(texto);
        }

        private void btnProductosClienteLimpiar1_Click(object sender, EventArgs e)
        {
            txtProductosClienteBuscar1.Clear();

            CargarProductosCliente();
        }

        private void btnMantenimientoGuardar1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtMantenimientoEquipo1.Text))
            {
                MessageBox.Show("Ingrese el equipo.");
                txtMantenimientoEquipo1.Focus();
                return;
            }

            if (cbMantenimientoTipo1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el tipo de mantenimiento.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMantenimientoDescripcion1.Text))
            {
                MessageBox.Show("Ingrese una descripción.");
                txtMantenimientoDescripcion1.Focus();
                return;
            }

            if (cbMantenimientoEstado1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el estado.");
                return;
            }

            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.Equipo = txtMantenimientoEquipo1.Text.Trim();
            mantenimiento.Fecha = dtpMantenimientoFecha1.Value;
            mantenimiento.Tipo = cbMantenimientoTipo1.Text;
            mantenimiento.Descripcion = txtMantenimientoDescripcion1.Text.Trim();
            mantenimiento.Costo = nudMantenimientoCosto1.Value;
            mantenimiento.Estado = cbMantenimientoEstado1.Text;
            mantenimiento.ProximoMantenimiento = dtpMantenimientoProximoMantenimiento.Value;

            MantenimientoDAO mantenimientoDAO = new MantenimientoDAO();

            if (mantenimientoDAO.Guardar(mantenimiento))
            {
                MessageBox.Show(
                    "Mantenimiento guardado correctamente.",
                    "Mantenimiento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarMantenimientos();
                LimpiarMantenimiento();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el mantenimiento.");
            }
        }

        private void btnMantenimientoNuevo1_Click(object sender, EventArgs e)
        {
            txtMantenimientoEquipo1.Clear();

            dtpMantenimientoFecha1.Value = DateTime.Now;

            cbMantenimientoTipo1.SelectedIndex = -1;

            txtMantenimientoDescripcion1.Clear();

            nudMantenimientoCosto1.Value = 0;

            cbMantenimientoEstado1.SelectedIndex = -1;

            dtpMantenimientoProximoMantenimiento.Value = DateTime.Now;

            txtMantenimientoEquipo1.Focus();

        }

        private void dtpMantenimientoProximo1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            idMantenimientoSeleccionado = Convert.ToInt32(
    dtpMantenimientoProximo1.Rows[e.RowIndex].Cells[0].Value);

            txtMantenimientoEquipo1.Text =
                dtpMantenimientoProximo1.Rows[e.RowIndex]
                .Cells["equipo"].Value?.ToString();

            dtpMantenimientoFecha1.Value =
                Convert.ToDateTime(
                    dtpMantenimientoProximo1.Rows[e.RowIndex]
                    .Cells["fecha"].Value);

            cbMantenimientoTipo1.Text =
                dtpMantenimientoProximo1.Rows[e.RowIndex]
                .Cells["tipo"].Value?.ToString();

            txtMantenimientoDescripcion1.Text =
                dtpMantenimientoProximo1.Rows[e.RowIndex]
                .Cells["descripcion"].Value?.ToString();

            nudMantenimientoCosto1.Value =
                Convert.ToDecimal(
                    dtpMantenimientoProximo1.Rows[e.RowIndex]
                    .Cells["costo"].Value);

            cbMantenimientoEstado1.Text =
                dtpMantenimientoProximo1.Rows[e.RowIndex]
                .Cells["estado"].Value?.ToString();

        }

        private void btnMantenimientoEliminar1_Click(object sender, EventArgs e)
        {
            if (idMantenimientoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un mantenimiento para eliminar.",
                    "Mantenimiento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar este mantenimiento?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            MantenimientoDAO mantenimientoDAO = new MantenimientoDAO();

            if (mantenimientoDAO.Eliminar(idMantenimientoSeleccionado))
            {
                MessageBox.Show(
                    "Mantenimiento eliminado correctamente.",
                    "Mantenimiento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                idMantenimientoSeleccionado = 0;

                CargarMantenimientos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el mantenimiento.");
            }

        }

        private void btnMantenimientoEditar1_Click(object sender, EventArgs e)
        {
            if (idMantenimientoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un mantenimiento para editar.",
                    "Mantenimiento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.IdMantenimiento = idMantenimientoSeleccionado;
            mantenimiento.Equipo = txtMantenimientoEquipo1.Text.Trim();
            mantenimiento.Fecha = dtpMantenimientoFecha1.Value;
            mantenimiento.Tipo = cbMantenimientoTipo1.Text;
            mantenimiento.Descripcion = txtMantenimientoDescripcion1.Text.Trim();
            mantenimiento.Costo = nudMantenimientoCosto1.Value;
            mantenimiento.Estado = cbMantenimientoEstado1.Text;

            MantenimientoDAO mantenimientoDAO = new MantenimientoDAO();

            if (mantenimientoDAO.Actualizar(mantenimiento))
            {
                MessageBox.Show(
                    "Mantenimiento actualizado correctamente.",
                    "Mantenimiento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                idMantenimientoSeleccionado = 0;

                CargarMantenimientos();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el mantenimiento.");
            }
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabMantenimento;
        }

        private void gestiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabProductosCliente2;
        }

        private void pagoDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabProductosClientes.SelectedTab = tabPagoDiario;
        }

        private void btnUsuarioFoto1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrirFoto = new OpenFileDialog())
            {
                abrirFoto.Title = "Seleccionar foto";
                abrirFoto.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (abrirFoto.ShowDialog() == DialogResult.OK)
                {
                    pbUsuarioFoto1.Image = Image.FromFile(abrirFoto.FileName);
                    pbUsuarioFoto1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void tablaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(
            tablaUsuarios.Rows[e.RowIndex].Cells["estado"].Value);

            cbEstado.Text = estado ? "Activo" : "Inactivo";
        }

        private void cbPagoDiarioEstado1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMovimientos1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbMovimientos1.SelectedItem == null)
                return;

            string movimiento = cbMovimientos1.SelectedItem.ToString();

            pnlCobros1.Visible = false;

            if (movimiento == "Cobros")
            {
                pnlCobros1.Visible = true;

                CargarClientesCobro();
                CargarCobros();
            }
        }

        private void lblCobroPrecio1_Click(object sender, EventArgs e)
        {

        }
        private void CargarClientesCobro()
        {
            try
            {
                using (NpgsqlConnection con = new Conexion().ObtenerConexion())
                {
                    string sql = @"SELECT id_cliente,
                                  nombre || ' ' || apellido AS nombre_completo
                           FROM clientes
                           ORDER BY nombre, apellido";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                    {
                        DataTable tabla = new DataTable();

                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(tabla);

                        }

                        AutoCompleteStringCollection clientes =
                            new AutoCompleteStringCollection();

                        foreach (DataRow fila in tabla.Rows)
                        {
                            clientes.Add(
                                fila["nombre_completo"].ToString()
                            );
                        }

                        txtCobroCliente1.AutoCompleteMode =
                            AutoCompleteMode.SuggestAppend;

                        txtCobroCliente1.AutoCompleteSource =
                            AutoCompleteSource.CustomSource;

                        txtCobroCliente1.AutoCompleteCustomSource =
                            clientes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los clientes: " + ex.Message
                );
            }
        }
        private void SeleccionarClienteCobro()
        {
            if (string.IsNullOrWhiteSpace(txtCobroCliente1.Text))
                return;

            try
            {
                using (NpgsqlConnection con = new Conexion().ObtenerConexion())
                {
                    string sql = @"SELECT id_cliente
                           FROM clientes
                           WHERE LOWER(nombre || ' ' || apellido) = LOWER(@nombre)
                           LIMIT 1";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nombre",
                            txtCobroCliente1.Text.Trim());

                        con.Open();

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            idClienteCobroSeleccionado = Convert.ToInt32(resultado);

                            CargarMembresiasCobro(
                                idClienteCobroSeleccionado);
                        }
                        else
                        {
                            idClienteCobroSeleccionado = 0;

                            cbCobroMembresia1.DataSource = null;

                            MessageBox.Show(
                                "No se encontró ese cliente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar el cliente: " + ex.Message);
            }
        }
        private void CargarMembresiasCobro(int idCliente)
        {
            try
            {
                using (NpgsqlConnection con = new Conexion().ObtenerConexion())
                {
                    string sql = @"SELECT id_membresia,
                                  tipo,
                                  precio,
                                  fecha_inicio,
                                  fecha_fin,
                                  estado
                           FROM ""Membresia""
                           WHERE id_cliente = @id_cliente
                           ORDER BY fecha_inicio DESC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                        DataTable tabla = new DataTable();

                        using (NpgsqlDataAdapter da =
                               new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(tabla);
                        }
                        MessageBox.Show("Membresías encontradas: " + tabla.Rows.Count);

                        cbCobroMembresia1.DataSource = null;

                        cbCobroMembresia1.DisplayMember = "tipo";
                        cbCobroMembresia1.ValueMember = "id_membresia";

                        cbCobroMembresia1.DataSource = tabla;

                        cbCobroMembresia1.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las membresías:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cbCobroMembresia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCobroMembresia1.SelectedIndex == -1)
                return;

            if (cbCobroMembresia1.SelectedItem is DataRowView fila)
            {
                decimal precio = Convert.ToDecimal(fila["precio"]);

                nudCobroPrecio1.Value = precio;
            }
        }

        private void txtCobroCliente1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCobroGuardar1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (idClienteCobroSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Primero debes seleccionar un cliente.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                
                if (cbCobroMembresia1.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Selecciona una membresía.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                
                if (cbCobroMetodo1.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Selecciona el método de pago.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

               
                if (cbCobroEstado1.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Selecciona el estado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                PagoDiario pago = new PagoDiario();

                pago.PrecioEntrada = nudCobroPrecio1.Value;
                pago.Fecha = dtpCobroFecha1.Value;
                pago.MetodoPago = cbCobroMetodo1.Text;
                pago.Concepto = cbCobroMembresia1.Text;
                pago.Estado = cbCobroEstado1.Text;

                PagoDiarioDAO dao = new PagoDiarioDAO();

                if (dao.Guardar(pago))
                {
                    MessageBox.Show(
                        "Cobro guardado correctamente.",
                        "Cobro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarCobro();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo guardar el cobro.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar el cobro:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
        private void LimpiarCobro()
        {
            txtCobroCliente1.Clear();

            cbCobroMembresia1.DataSource = null;
            cbCobroMembresia1.Items.Clear();

            nudCobroPrecio1.Value = 0;

            dtpCobroFecha1.Value = DateTime.Now;

            cbCobroMetodo1.SelectedIndex = -1;
            cbCobroEstado1.SelectedIndex = -1;

            idClienteCobroSeleccionado = 0;
        }
        private void btnCobroLimpiar1_Click(object sender, EventArgs e)
        {

        }
        private void CargarCobros()
        {
            try
            {
                PagoDiarioDAO dao = new PagoDiarioDAO();

                dgvCobros1.DataSource = null;
                dgvCobros1.DataSource = dao.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los cobros:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private int idCobroSeleccionado = 0;
        private void dgvCobros1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvCobros1.Rows[e.RowIndex];

            idCobroSeleccionado = Convert.ToInt32(
                fila.Cells["IdPago"].Value);

            txtCobroCliente1.Text =
                fila.Cells["Cliente"].Value?.ToString();

            cbCobroMetodo1.Text =
                fila.Cells["MetodoPago"].Value?.ToString();

            cbCobroEstado1.Text =
                fila.Cells["Estado"].Value?.ToString();

            nudCobroPrecio1.Value =
                Convert.ToDecimal(fila.Cells["PrecioEntrada"].Value);

            dtpCobroFecha1.Value =
                Convert.ToDateTime(fila.Cells["Fecha"].Value);
        }
        private void ConfigurarPantallaCliente()
        {
            if (tabProductosClientes.Parent == null)
                return;

            TabControl tabs = (TabControl)tabProductosClientes.Parent;

            for (int i = tabs.TabPages.Count - 1; i >= 0; i--)
            {
                TabPage pagina = tabs.TabPages[i];

                if (pagina.Text != "Inicio" &&
                    pagina.Text != "Mi Perfil" &&
                    pagina.Text != "ProductoCliente")
                {
                    tabs.TabPages.Remove(pagina);
                }
            }
        }
    }


}





