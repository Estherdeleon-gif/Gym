namespace Gym
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            lbUsuario = new Label();
            txtUsuario = new TextBox();
            lbPassword = new Label();
            txtPassword = new TextBox();
            btnIngresar = new Button();
            foto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)foto).BeginInit();
            SuspendLayout();
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.BackColor = SystemColors.ActiveCaptionText;
            lbUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUsuario.ForeColor = Color.White;
            lbUsuario.Location = new Point(900, 68);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(94, 32);
            lbUsuario.TabIndex = 0;
            lbUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI Light", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(1059, 68);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(150, 37);
            txtUsuario.TabIndex = 1;
            txtUsuario.TextChanged += textBox1_TextChanged;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.BackColor = SystemColors.ActiveCaptionText;
            lbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPassword.ForeColor = Color.White;
            lbPassword.Location = new Point(900, 164);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(134, 32);
            lbPassword.TabIndex = 2;
            lbPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI Light", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(1059, 164);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(150, 37);
            txtPassword.TabIndex = 3;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.DodgerBlue;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(973, 263);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(152, 68);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Iniciar sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // foto
            // 
            foto.Image = (Image)resources.GetObject("foto.Image");
            foto.Location = new Point(70, 12);
            foto.Name = "foto";
            foto.Size = new Size(741, 413);
            foto.SizeMode = PictureBoxSizeMode.Zoom;
            foto.TabIndex = 5;
            foto.TabStop = false;
            foto.Click += foto_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1271, 523);
            Controls.Add(foto);
            Controls.Add(btnIngresar);
            Controls.Add(txtPassword);
            Controls.Add(lbPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lbUsuario);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gimnasio";
            ((System.ComponentModel.ISupportInitialize)foto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbUsuario;
        private TextBox txtUsuario;
        private Label lbPassword;
        private TextBox txtPassword;
        private Button btnIngresar;
        private PictureBox foto;
    }
}
