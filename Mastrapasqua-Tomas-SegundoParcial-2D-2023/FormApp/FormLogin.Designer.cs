namespace FormApp
{
    partial class FormLogin
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
            components = new System.ComponentModel.Container();
            BotonLogin = new Button();
            TextMail = new TextBox();
            TextPassword = new TextBox();
            TextError = new Label();
            pictureBox1 = new PictureBox();
            bindingSource1 = new BindingSource(components);
            Cliente = new Button();
            Vendedor = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // BotonLogin
            // 
            BotonLogin.BackColor = Color.Black;
            BotonLogin.Cursor = Cursors.Hand;
            BotonLogin.FlatStyle = FlatStyle.Flat;
            BotonLogin.ForeColor = Color.White;
            BotonLogin.Location = new Point(30, 317);
            BotonLogin.Name = "BotonLogin";
            BotonLogin.Size = new Size(194, 35);
            BotonLogin.TabIndex = 1;
            BotonLogin.Text = "Login";
            BotonLogin.UseVisualStyleBackColor = false;
            BotonLogin.Click += BotonLogin_Click;
            // 
            // TextMail
            // 
            TextMail.BackColor = SystemColors.MenuText;
            TextMail.BorderStyle = BorderStyle.FixedSingle;
            TextMail.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TextMail.ForeColor = Color.DimGray;
            TextMail.Location = new Point(30, 197);
            TextMail.Name = "TextMail";
            TextMail.PlaceholderText = "Mail";
            TextMail.Size = new Size(194, 25);
            TextMail.TabIndex = 3;
            // 
            // TextPassword
            // 
            TextPassword.BackColor = SystemColors.MenuText;
            TextPassword.BorderStyle = BorderStyle.FixedSingle;
            TextPassword.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TextPassword.ForeColor = Color.DimGray;
            TextPassword.Location = new Point(30, 243);
            TextPassword.Name = "TextPassword";
            TextPassword.PasswordChar = '*';
            TextPassword.PlaceholderText = "Password";
            TextPassword.Size = new Size(194, 25);
            TextPassword.TabIndex = 4;
            TextPassword.TabStop = false;
            TextPassword.Tag = "";
            // 
            // TextError
            // 
            TextError.AutoSize = true;
            TextError.BackColor = Color.Transparent;
            TextError.ForeColor = Color.FromArgb(30, 30, 30);
            TextError.Location = new Point(27, 271);
            TextError.Name = "TextError";
            TextError.Size = new Size(197, 15);
            TextError.TabIndex = 8;
            TextError.Text = "No se encontro el usuario ingresado";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Carniceria_Mastra_26_4_2023__1_1;
            pictureBox1.Location = new Point(22, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(202, 94);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // Cliente
            // 
            Cliente.BackColor = Color.Black;
            Cliente.FlatStyle = FlatStyle.Flat;
            Cliente.ForeColor = SystemColors.ButtonHighlight;
            Cliente.Location = new Point(31, 426);
            Cliente.Name = "Cliente";
            Cliente.Size = new Size(75, 23);
            Cliente.TabIndex = 11;
            Cliente.Text = "Cliente";
            Cliente.UseVisualStyleBackColor = false;
            Cliente.Click += Cliente_Click;
            // 
            // Vendedor
            // 
            Vendedor.BackColor = Color.Black;
            Vendedor.FlatStyle = FlatStyle.Flat;
            Vendedor.ForeColor = SystemColors.ButtonHighlight;
            Vendedor.Location = new Point(149, 426);
            Vendedor.Name = "Vendedor";
            Vendedor.Size = new Size(75, 23);
            Vendedor.TabIndex = 12;
            Vendedor.Text = "Vendedor";
            Vendedor.UseVisualStyleBackColor = false;
            Vendedor.Click += Vendedor_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(273, 479);
            Controls.Add(Vendedor);
            Controls.Add(Cliente);
            Controls.Add(pictureBox1);
            Controls.Add(TextError);
            Controls.Add(TextPassword);
            Controls.Add(TextMail);
            Controls.Add(BotonLogin);
            Name = "FormLogin";
            RightToLeft = RightToLeft.No;
            Text = "Ingrese su usuario";
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BotonLogin;
        private TextBox TextMail;
        private TextBox TextPassword;
        private Label TextError;
        private PictureBox pictureBox1;
        private BindingSource bindingSource1;
        private Button Cliente;
        private Button Vendedor;
    }
}