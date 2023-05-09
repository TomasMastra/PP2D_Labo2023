﻿namespace FormApp
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
            button1 = new Button();
            DatosCarne = new ListBox();
            GrupoCarne = new GroupBox();
            TotalPagar = new Label();
            CantidadComprar = new NumericUpDown();
            CantidadDisponible = new Label();
            Precio = new Label();
            Tipo = new Label();
            TextBoxBuscar = new TextBox();
            Buscar = new Button();
            BotonSiguiente = new Button();
            BotonCarro = new Button();
            Facturas = new Button();
            BotonUsuario = new Button();
            TextMontoMaximo = new TextBox();
            MontoText = new Label();
            BotonIngresarMonto = new Button();
            TextoMonto = new Label();
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
            botonRegresar.Location = new Point(25, 12);
            botonRegresar.Name = "botonRegresar";
            botonRegresar.Size = new Size(75, 23);
            botonRegresar.TabIndex = 3;
            botonRegresar.Text = "Regresar";
            botonRegresar.UseVisualStyleBackColor = false;
            botonRegresar.Click += botonRegresar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(375, 310);
            button1.Name = "button1";
            button1.Size = new Size(334, 45);
            button1.TabIndex = 6;
            button1.Text = "Agregar al carro";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BotonComprar_Click;
            // 
            // DatosCarne
            // 
            DatosCarne.BackColor = SystemColors.MenuText;
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
            GrupoCarne.Controls.Add(TotalPagar);
            GrupoCarne.Controls.Add(CantidadComprar);
            GrupoCarne.Controls.Add(CantidadDisponible);
            GrupoCarne.Controls.Add(Precio);
            GrupoCarne.Controls.Add(Tipo);
            GrupoCarne.ForeColor = SystemColors.Control;
            GrupoCarne.Location = new Point(375, 204);
            GrupoCarne.Name = "GrupoCarne";
            GrupoCarne.Size = new Size(334, 100);
            GrupoCarne.TabIndex = 12;
            GrupoCarne.TabStop = false;
            GrupoCarne.Text = "Datos del corte de carne";
            // 
            // TotalPagar
            // 
            TotalPagar.AutoSize = true;
            TotalPagar.Location = new Point(211, 71);
            TotalPagar.Name = "TotalPagar";
            TotalPagar.Size = new Size(77, 15);
            TotalPagar.TabIndex = 5;
            TotalPagar.Text = "Total a pagar:";
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
            CantidadDisponible.Location = new Point(22, 55);
            CantidadDisponible.Name = "CantidadDisponible";
            CantidadDisponible.Size = new Size(0, 15);
            CantidadDisponible.TabIndex = 2;
            // 
            // Precio
            // 
            Precio.AutoSize = true;
            Precio.Location = new Point(22, 40);
            Precio.Name = "Precio";
            Precio.Size = new Size(0, 15);
            Precio.TabIndex = 1;
            // 
            // Tipo
            // 
            Tipo.AutoSize = true;
            Tipo.Location = new Point(22, 25);
            Tipo.Name = "Tipo";
            Tipo.Size = new Size(0, 15);
            Tipo.TabIndex = 0;
            // 
            // TextBoxBuscar
            // 
            TextBoxBuscar.BackColor = SystemColors.InfoText;
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
            // Facturas
            // 
            Facturas.BackColor = Color.Black;
            Facturas.FlatStyle = FlatStyle.Flat;
            Facturas.ForeColor = SystemColors.ButtonHighlight;
            Facturas.Location = new Point(474, 16);
            Facturas.Name = "Facturas";
            Facturas.Size = new Size(103, 23);
            Facturas.TabIndex = 17;
            Facturas.Text = "Ver facturas";
            Facturas.UseVisualStyleBackColor = false;
            Facturas.Click += Facturas_Click;
            // 
            // BotonUsuario
            // 
            BotonUsuario.BackColor = Color.Black;
            BotonUsuario.FlatStyle = FlatStyle.Flat;
            BotonUsuario.ForeColor = SystemColors.ButtonHighlight;
            BotonUsuario.Location = new Point(586, 16);
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
            TextMontoMaximo.Location = new Point(12, 61);
            TextMontoMaximo.Name = "TextMontoMaximo";
            TextMontoMaximo.PlaceholderText = "Monto";
            TextMontoMaximo.Size = new Size(100, 23);
            TextMontoMaximo.TabIndex = 19;
            // 
            // MontoText
            // 
            MontoText.AutoSize = true;
            MontoText.ForeColor = SystemColors.ButtonHighlight;
            MontoText.Location = new Point(12, 43);
            MontoText.Name = "MontoText";
            MontoText.Size = new Size(194, 15);
            MontoText.TabIndex = 20;
            MontoText.Text = "Ingrese el monto antes de comprar:";
            // 
            // BotonIngresarMonto
            // 
            BotonIngresarMonto.BackColor = Color.Black;
            BotonIngresarMonto.FlatStyle = FlatStyle.Flat;
            BotonIngresarMonto.ForeColor = SystemColors.ButtonHighlight;
            BotonIngresarMonto.Location = new Point(118, 62);
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
            TextoMonto.Location = new Point(12, 87);
            TextoMonto.Name = "TextoMonto";
            TextoMonto.Size = new Size(302, 15);
            TextoMonto.TabIndex = 22;
            TextoMonto.Text = "Ingrese el monto para acceder al resto de las funcionnes";
            // 
            // FormVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 16, 47);
            ClientSize = new Size(800, 450);
            Controls.Add(TextoMonto);
            Controls.Add(BotonIngresarMonto);
            Controls.Add(MontoText);
            Controls.Add(TextMontoMaximo);
            Controls.Add(BotonUsuario);
            Controls.Add(Facturas);
            Controls.Add(BotonCarro);
            Controls.Add(BotonSiguiente);
            Controls.Add(Buscar);
            Controls.Add(TextBoxBuscar);
            Controls.Add(GrupoCarne);
            Controls.Add(DatosCarne);
            Controls.Add(button1);
            Controls.Add(botonRegresar);
            Controls.Add(DatosCorteCarne);
            Name = "FormVenta";
            Text = "FormCliente";
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
        private Button button1;
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
        private Button Facturas;
        private Button BotonUsuario;
        private TextBox TextMontoMaximo;
        private Label MontoText;
        private Button BotonIngresarMonto;
        private Label TextoMonto;
    }
}