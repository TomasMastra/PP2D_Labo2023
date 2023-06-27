namespace FormApp
{
    partial class FormVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Corte = new DataGridViewTextBoxColumn();
            DatosCorteCarne = new Label();
            botonRegresar = new Button();
            BotonAgregarCarro = new Button();
            DatosCarne = new ListBox();
            GrupoCarne = new GroupBox();
            CosteCarrro = new Label();
            Pagar = new Label();
            TotalComprar = new Label();
            TotalPagar = new Label();
            CantidadComprar = new NumericUpDown();
            CantidadDisponible = new Label();
            Precio = new Label();
            Tipo = new Label();
            TextBoxBuscar = new TextBox();
            Buscar = new Button();
            BotonSiguiente = new Button();
            BotonCarro = new Button();
            BotonBorrar = new Button();
            BotonUsuario = new Button();
            TextMontoMaximo = new TextBox();
            MontoText = new Label();
            BotonIngresarMonto = new Button();
            TextoMonto = new Label();
            BotonComprar = new Button();
            Recargo = new CheckBox();
            ValorCarro = new Label();
            GrupoCarne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CantidadComprar).BeginInit();
            SuspendLayout();
            // 
            // Corte
            // 
            Corte.HeaderText = "Column1";
            Corte.Name = "Corte";
            // 
            // DatosCorteCarne
            // 
            DatosCorteCarne.AutoSize = true;
            DatosCorteCarne.Enabled = false;
            DatosCorteCarne.ForeColor = SystemColors.ButtonFace;
            DatosCorteCarne.Location = new Point(565, 20);
            DatosCorteCarne.Name = "DatosCorteCarne";
            DatosCorteCarne.Size = new Size(0, 15);
            DatosCorteCarne.TabIndex = 0;
            // 
            // botonRegresar
            // 
            botonRegresar.BackColor = Color.Black;
            botonRegresar.FlatStyle = FlatStyle.Flat;
            botonRegresar.ForeColor = SystemColors.ButtonHighlight;
            botonRegresar.Location = new Point(12, 12);
            botonRegresar.Name = "botonRegresar";
            botonRegresar.Size = new Size(75, 23);
            botonRegresar.TabIndex = 3;
            botonRegresar.Text = "Regresar";
            botonRegresar.UseVisualStyleBackColor = false;
            botonRegresar.Click += botonRegresar_Click;
            // 
            // BotonAgregarCarro
            // 
            BotonAgregarCarro.BackColor = Color.Black;
            BotonAgregarCarro.Enabled = false;
            BotonAgregarCarro.FlatStyle = FlatStyle.Flat;
            BotonAgregarCarro.ForeColor = SystemColors.ButtonHighlight;
            BotonAgregarCarro.Location = new Point(375, 310);
            BotonAgregarCarro.Name = "BotonAgregarCarro";
            BotonAgregarCarro.Size = new Size(334, 45);
            BotonAgregarCarro.TabIndex = 6;
            BotonAgregarCarro.Text = "Agregar al carro";
            BotonAgregarCarro.UseVisualStyleBackColor = false;
            BotonAgregarCarro.Click += BotonComprar_Click;
            // 
            // DatosCarne
            // 
            DatosCarne.BackColor = SystemColors.MenuText;
            DatosCarne.Enabled = false;
            DatosCarne.ForeColor = SystemColors.MenuBar;
            DatosCarne.FormattingEnabled = true;
            DatosCarne.ItemHeight = 15;
            DatosCarne.Location = new Point(30, 167);
            DatosCarne.Name = "DatosCarne";
            DatosCarne.Size = new Size(329, 244);
            DatosCarne.TabIndex = 11;
            DatosCarne.SelectedIndexChanged += DatosCarne_SelectedIndexChanged;
            // 
            // GrupoCarne
            // 
            GrupoCarne.BackColor = Color.Black;
            GrupoCarne.Controls.Add(CosteCarrro);
            GrupoCarne.Controls.Add(Pagar);
            GrupoCarne.Controls.Add(TotalComprar);
            GrupoCarne.Controls.Add(TotalPagar);
            GrupoCarne.Controls.Add(CantidadComprar);
            GrupoCarne.Controls.Add(CantidadDisponible);
            GrupoCarne.Controls.Add(Precio);
            GrupoCarne.Controls.Add(Tipo);
            GrupoCarne.Enabled = false;
            GrupoCarne.ForeColor = SystemColors.Control;
            GrupoCarne.Location = new Point(375, 204);
            GrupoCarne.Name = "GrupoCarne";
            GrupoCarne.Size = new Size(334, 100);
            GrupoCarne.TabIndex = 12;
            GrupoCarne.TabStop = false;
            GrupoCarne.Text = "Datos del corte de carne";
            // 
            // CosteCarrro
            // 
            CosteCarrro.AutoSize = true;
            CosteCarrro.Location = new Point(190, 82);
            CosteCarrro.Name = "CosteCarrro";
            CosteCarrro.Size = new Size(91, 15);
            CosteCarrro.TabIndex = 8;
            CosteCarrro.Text = "Coste del Carro:";
            // 
            // Pagar
            // 
            Pagar.AutoSize = true;
            Pagar.Location = new Point(154, 57);
            Pagar.Name = "Pagar";
            Pagar.Size = new Size(145, 15);
            Pagar.TabIndex = 7;
            Pagar.Text = "Costo de corte comprado:";
            // 
            // TotalComprar
            // 
            TotalComprar.AutoSize = true;
            TotalComprar.Location = new Point(286, 82);
            TotalComprar.Name = "TotalComprar";
            TotalComprar.Size = new Size(13, 15);
            TotalComprar.TabIndex = 6;
            TotalComprar.Text = "0";
            // 
            // TotalPagar
            // 
            TotalPagar.AutoSize = true;
            TotalPagar.Location = new Point(295, 57);
            TotalPagar.Name = "TotalPagar";
            TotalPagar.Size = new Size(13, 15);
            TotalPagar.TabIndex = 5;
            TotalPagar.Text = "0";
            TotalPagar.Click += TotalPagar_Click;
            // 
            // CantidadComprar
            // 
            CantidadComprar.BackColor = Color.Black;
            CantidadComprar.ForeColor = SystemColors.ButtonHighlight;
            CantidadComprar.Location = new Point(257, 31);
            CantidadComprar.Name = "CantidadComprar";
            CantidadComprar.Size = new Size(51, 23);
            CantidadComprar.TabIndex = 3;
            CantidadComprar.ValueChanged += CantidadComprar_ValueChanged;
            // 
            // CantidadDisponible
            // 
            CantidadDisponible.AutoSize = true;
            CantidadDisponible.BackColor = Color.Black;
            CantidadDisponible.Location = new Point(22, 55);
            CantidadDisponible.Name = "CantidadDisponible";
            CantidadDisponible.Size = new Size(0, 15);
            CantidadDisponible.TabIndex = 2;
            // 
            // Precio
            // 
            Precio.AutoSize = true;
            Precio.BackColor = Color.Black;
            Precio.Location = new Point(22, 40);
            Precio.Name = "Precio";
            Precio.Size = new Size(0, 15);
            Precio.TabIndex = 1;
            // 
            // Tipo
            // 
            Tipo.AutoSize = true;
            Tipo.BackColor = Color.Black;
            Tipo.Location = new Point(22, 25);
            Tipo.Name = "Tipo";
            Tipo.Size = new Size(0, 15);
            Tipo.TabIndex = 0;
            // 
            // TextBoxBuscar
            // 
            TextBoxBuscar.BackColor = SystemColors.InfoText;
            TextBoxBuscar.Enabled = false;
            TextBoxBuscar.ForeColor = SystemColors.Window;
            TextBoxBuscar.Location = new Point(30, 138);
            TextBoxBuscar.Name = "TextBoxBuscar";
            TextBoxBuscar.PlaceholderText = "Busqueda";
            TextBoxBuscar.Size = new Size(100, 23);
            TextBoxBuscar.TabIndex = 13;
            // 
            // Buscar
            // 
            Buscar.BackColor = Color.Black;
            Buscar.Enabled = false;
            Buscar.FlatStyle = FlatStyle.Flat;
            Buscar.ForeColor = SystemColors.ButtonHighlight;
            Buscar.Location = new Point(136, 138);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(75, 23);
            Buscar.TabIndex = 14;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = false;
            Buscar.Click += Buscar_Click;
            // 
            // BotonSiguiente
            // 
            BotonSiguiente.BackColor = Color.Black;
            BotonSiguiente.Enabled = false;
            BotonSiguiente.FlatStyle = FlatStyle.Flat;
            BotonSiguiente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BotonSiguiente.ForeColor = SystemColors.ButtonHighlight;
            BotonSiguiente.Location = new Point(217, 138);
            BotonSiguiente.Name = "BotonSiguiente";
            BotonSiguiente.Size = new Size(27, 23);
            BotonSiguiente.TabIndex = 15;
            BotonSiguiente.Text = "➡";
            BotonSiguiente.UseVisualStyleBackColor = false;
            BotonSiguiente.Click += BotonSiguiente_Click;
            // 
            // BotonCarro
            // 
            BotonCarro.BackColor = Color.Black;
            BotonCarro.Enabled = false;
            BotonCarro.FlatStyle = FlatStyle.Flat;
            BotonCarro.ForeColor = SystemColors.ButtonHighlight;
            BotonCarro.Location = new Point(355, 16);
            BotonCarro.Name = "BotonCarro";
            BotonCarro.Size = new Size(103, 23);
            BotonCarro.TabIndex = 16;
            BotonCarro.Text = "Ver carro \U0001f6d2";
            BotonCarro.UseVisualStyleBackColor = false;
            BotonCarro.Click += BotonCarro_Click;
            // 
            // BotonBorrar
            // 
            BotonBorrar.BackColor = Color.Black;
            BotonBorrar.Enabled = false;
            BotonBorrar.FlatStyle = FlatStyle.Flat;
            BotonBorrar.ForeColor = SystemColors.ButtonHighlight;
            BotonBorrar.Location = new Point(375, 361);
            BotonBorrar.Name = "BotonBorrar";
            BotonBorrar.Size = new Size(334, 39);
            BotonBorrar.TabIndex = 17;
            BotonBorrar.Text = "Vaciar carro";
            BotonBorrar.UseVisualStyleBackColor = false;
            BotonBorrar.Click += BotonCancelarCompra_Click;
            // 
            // BotonUsuario
            // 
            BotonUsuario.BackColor = Color.Black;
            BotonUsuario.Enabled = false;
            BotonUsuario.FlatStyle = FlatStyle.Flat;
            BotonUsuario.ForeColor = SystemColors.ButtonHighlight;
            BotonUsuario.Location = new Point(571, 16);
            BotonUsuario.Name = "BotonUsuario";
            BotonUsuario.Size = new Size(103, 23);
            BotonUsuario.TabIndex = 18;
            BotonUsuario.Text = "Usuario";
            BotonUsuario.UseVisualStyleBackColor = false;
            BotonUsuario.Click += BotonUsuario_Click;
            // 
            // TextMontoMaximo
            // 
            TextMontoMaximo.BackColor = SystemColors.InactiveCaptionText;
            TextMontoMaximo.ForeColor = SystemColors.MenuBar;
            TextMontoMaximo.Location = new Point(12, 41);
            TextMontoMaximo.Name = "TextMontoMaximo";
            TextMontoMaximo.PlaceholderText = "Monto";
            TextMontoMaximo.Size = new Size(100, 23);
            TextMontoMaximo.TabIndex = 19;
            // 
            // MontoText
            // 
            MontoText.AutoSize = true;
            MontoText.ForeColor = SystemColors.ButtonHighlight;
            MontoText.Location = new Point(441, 403);
            MontoText.Name = "MontoText";
            MontoText.Size = new Size(191, 15);
            MontoText.TabIndex = 20;
            MontoText.Text = "Ingrese el monto antes de comprar";
            // 
            // BotonIngresarMonto
            // 
            BotonIngresarMonto.BackColor = Color.Black;
            BotonIngresarMonto.FlatStyle = FlatStyle.Flat;
            BotonIngresarMonto.ForeColor = SystemColors.ButtonHighlight;
            BotonIngresarMonto.Location = new Point(118, 42);
            BotonIngresarMonto.Name = "BotonIngresarMonto";
            BotonIngresarMonto.Size = new Size(75, 22);
            BotonIngresarMonto.TabIndex = 21;
            BotonIngresarMonto.Text = "Ingresar";
            BotonIngresarMonto.UseVisualStyleBackColor = false;
            BotonIngresarMonto.Click += BotonIngresarMonto_Click;
            // 
            // TextoMonto
            // 
            TextoMonto.AutoSize = true;
            TextoMonto.ForeColor = Color.Red;
            TextoMonto.Location = new Point(12, 67);
            TextoMonto.Name = "TextoMonto";
            TextoMonto.Size = new Size(302, 15);
            TextoMonto.TabIndex = 22;
            TextoMonto.Text = "Ingrese el monto para acceder al resto de las funcionnes";
            // 
            // BotonComprar
            // 
            BotonComprar.BackColor = Color.Black;
            BotonComprar.Enabled = false;
            BotonComprar.FlatStyle = FlatStyle.Flat;
            BotonComprar.ForeColor = SystemColors.ButtonHighlight;
            BotonComprar.Location = new Point(464, 16);
            BotonComprar.Name = "BotonComprar";
            BotonComprar.Size = new Size(103, 23);
            BotonComprar.TabIndex = 23;
            BotonComprar.Text = "Comprar carro \U0001f6d2";
            BotonComprar.UseVisualStyleBackColor = false;
            BotonComprar.Click += BotonComprar_Click_1;
            // 
            // Recargo
            // 
            Recargo.AutoSize = true;
            Recargo.Enabled = false;
            Recargo.ForeColor = SystemColors.ButtonHighlight;
            Recargo.Location = new Point(464, 42);
            Recargo.Name = "Recargo";
            Recargo.Size = new Size(91, 19);
            Recargo.TabIndex = 24;
            Recargo.Text = "Con recargo";
            Recargo.UseVisualStyleBackColor = true;
            // 
            // ValorCarro
            // 
            ValorCarro.AutoSize = true;
            ValorCarro.ForeColor = Color.White;
            ValorCarro.Location = new Point(381, 186);
            ValorCarro.Name = "ValorCarro";
            ValorCarro.Size = new Size(85, 15);
            ValorCarro.TabIndex = 25;
            ValorCarro.Text = "Valor del carro:";
            // 
            // FormVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 16, 47);
            ClientSize = new Size(800, 450);
            Controls.Add(ValorCarro);
            Controls.Add(Recargo);
            Controls.Add(BotonComprar);
            Controls.Add(TextoMonto);
            Controls.Add(BotonIngresarMonto);
            Controls.Add(MontoText);
            Controls.Add(TextMontoMaximo);
            Controls.Add(BotonUsuario);
            Controls.Add(BotonBorrar);
            Controls.Add(BotonCarro);
            Controls.Add(BotonSiguiente);
            Controls.Add(Buscar);
            Controls.Add(TextBoxBuscar);
            Controls.Add(GrupoCarne);
            Controls.Add(DatosCarne);
            Controls.Add(BotonAgregarCarro);
            Controls.Add(botonRegresar);
            Controls.Add(DatosCorteCarne);
            Name = "FormVenta";
            Text = "Compre aqui!";
            Load += FormCliente_Load;
            GrupoCarne.ResumeLayout(false);
            GrupoCarne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CantidadComprar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
#pragma warning disable CS0169 // El campo 'FormVenta.dataGridView1' nunca se usa
        private DataGridView dataGridView1;
#pragma warning restore CS0169 // El campo 'FormVenta.dataGridView1' nunca se usa
#pragma warning disable CS0169 // El campo 'FormVenta.Column1' nunca se usa
        private DataGridViewTextBoxColumn Column1;
#pragma warning restore CS0169 // El campo 'FormVenta.Column1' nunca se usa
#pragma warning disable CS0169 // El campo 'FormVenta.Column2' nunca se usa
        private DataGridViewTextBoxColumn Column2;
#pragma warning restore CS0169 // El campo 'FormVenta.Column2' nunca se usa
#pragma warning disable CS0169 // El campo 'FormVenta.Column3' nunca se usa
        private DataGridViewTextBoxColumn Column3;
#pragma warning restore CS0169 // El campo 'FormVenta.Column3' nunca se usa
#pragma warning disable CS0169 // El campo 'FormVenta.Column4' nunca se usa
        private DataGridViewTextBoxColumn Column4;
#pragma warning restore CS0169 // El campo 'FormVenta.Column4' nunca se usa
        private DataGridViewTextBoxColumn Corte;
#pragma warning disable CS0169 // El campo 'FormVenta.dataGridViewTextBoxColumn2' nunca se usa
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
#pragma warning restore CS0169 // El campo 'FormVenta.dataGridViewTextBoxColumn2' nunca se usa
#pragma warning disable CS0169 // El campo 'FormVenta.dataGridViewTextBoxColumn3' nunca se usa
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
#pragma warning restore CS0169 // El campo 'FormVenta.dataGridViewTextBoxColumn3' nunca se usa
#pragma warning disable CS0169 // El campo 'FormVenta.dataGridViewTextBoxColumn4' nunca se usa
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
#pragma warning restore CS0169 // El campo 'FormVenta.dataGridViewTextBoxColumn4' nunca se usa
        private Label DatosCorteCarne;
#pragma warning disable CS0169 // El campo 'FormVenta.Carro' nunca se usa
        private Label Carro;
#pragma warning restore CS0169 // El campo 'FormVenta.Carro' nunca se usa
        private Button botonRegresar;
        private Button BotonAgregarCarro;
        private ListBox DatosCarne;
        private GroupBox GrupoCarne;
        private Label CantidadDisponible;
        private Label Precio;
        private Label Tipo;
        private TextBox TextBoxBuscar;
        private Button Buscar;
        private Button BotonSiguiente;
        private NumericUpDown CantidadComprar;
        private Button BotonCarro;
        private Label TotalPagar;
        private Button BotonBorrar;
        private Button BotonUsuario;
        private TextBox TextMontoMaximo;
        private Label MontoText;
        private Button BotonIngresarMonto;
        private Label TextoMonto;
        private Button BotonComprar;
        private CheckBox Recargo;
        private Label ValorCarro;
        private Label TotalComprar;
        private Label CosteCarrro;
        private Label Pagar;
    }
}