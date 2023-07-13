namespace FormApp
{
    partial class FormAlta
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
            TextBoxCorte = new TextBox();
            Precio = new NumericUpDown();
            Cantidad = new NumericUpDown();
            ListaCortesCarne = new ComboBox();
            BotonAgregar = new Button();
            TextError = new Label();
            TextCorte = new Label();
            ListaTipos = new ComboBox();
            TextModificar = new Label();
            label2 = new Label();
            TextPrecio = new Label();
            TextCantidad = new Label();
            BotonRegresar = new Button();
            GroupBoxDatos = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)Precio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Cantidad).BeginInit();
            GroupBoxDatos.SuspendLayout();
            SuspendLayout();
            // 
            // TextBoxCorte
            // 
            TextBoxCorte.BackColor = SystemColors.InfoText;
            TextBoxCorte.ForeColor = SystemColors.ButtonHighlight;
            TextBoxCorte.Location = new Point(68, 29);
            TextBoxCorte.Name = "TextBoxCorte";
            TextBoxCorte.PlaceholderText = "Corte";
            TextBoxCorte.Size = new Size(120, 23);
            TextBoxCorte.TabIndex = 0;
            // 
            // Precio
            // 
            Precio.BackColor = SystemColors.InfoText;
            Precio.ForeColor = SystemColors.ButtonHighlight;
            Precio.Location = new Point(68, 99);
            Precio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            Precio.Name = "Precio";
            Precio.Size = new Size(120, 23);
            Precio.TabIndex = 1;
            // 
            // Cantidad
            // 
            Cantidad.BackColor = SystemColors.InfoText;
            Cantidad.ForeColor = SystemColors.ButtonHighlight;
            Cantidad.Location = new Point(68, 128);
            Cantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(120, 23);
            Cantidad.TabIndex = 2;
            // 
            // ListaCortesCarne
            // 
            ListaCortesCarne.BackColor = SystemColors.MenuText;
            ListaCortesCarne.DropDownStyle = ComboBoxStyle.DropDownList;
            ListaCortesCarne.FlatStyle = FlatStyle.Flat;
            ListaCortesCarne.ForeColor = SystemColors.ButtonHighlight;
            ListaCortesCarne.FormattingEnabled = true;
            ListaCortesCarne.Location = new Point(34, 70);
            ListaCortesCarne.Name = "ListaCortesCarne";
            ListaCortesCarne.Size = new Size(121, 23);
            ListaCortesCarne.TabIndex = 3;
            ListaCortesCarne.Visible = false;
            ListaCortesCarne.SelectedIndexChanged += ListaCortesCarne_SelectedIndexChanged;
            // 
            // BotonAgregar
            // 
            BotonAgregar.BackColor = Color.Black;
            BotonAgregar.FlatStyle = FlatStyle.Flat;
            BotonAgregar.ForeColor = Color.Lime;
            BotonAgregar.Location = new Point(32, 275);
            BotonAgregar.Name = "BotonAgregar";
            BotonAgregar.Size = new Size(200, 71);
            BotonAgregar.TabIndex = 4;
            BotonAgregar.Text = "Agregar";
            BotonAgregar.UseVisualStyleBackColor = false;
            BotonAgregar.Click += BotonAgregar_Click;
            // 
            // TextError
            // 
            TextError.AutoSize = true;
            TextError.ForeColor = Color.FromArgb(30, 30, 30);
            TextError.Location = new Point(1, 246);
            TextError.Name = "TextError";
            TextError.Size = new Size(259, 15);
            TextError.TabIndex = 5;
            TextError.Text = "Hay campos vacios, revise el tipo, corte y precio";
            // 
            // TextCorte
            // 
            TextCorte.AutoSize = true;
            TextCorte.BackColor = Color.FromArgb(30, 30, 30);
            TextCorte.ForeColor = Color.White;
            TextCorte.Location = new Point(31, 58);
            TextCorte.Name = "TextCorte";
            TextCorte.Size = new Size(30, 15);
            TextCorte.TabIndex = 6;
            TextCorte.Text = "Tipo";
            // 
            // ListaTipos
            // 
            ListaTipos.BackColor = SystemColors.MenuText;
            ListaTipos.DropDownStyle = ComboBoxStyle.DropDownList;
            ListaTipos.FlatStyle = FlatStyle.Flat;
            ListaTipos.ForeColor = SystemColors.ButtonHighlight;
            ListaTipos.FormattingEnabled = true;
            ListaTipos.Location = new Point(68, 58);
            ListaTipos.Name = "ListaTipos";
            ListaTipos.Size = new Size(121, 23);
            ListaTipos.TabIndex = 7;
            // 
            // TextModificar
            // 
            TextModificar.AutoSize = true;
            TextModificar.ForeColor = Color.FromArgb(30, 30, 30);
            TextModificar.Location = new Point(34, 52);
            TextModificar.Name = "TextModificar";
            TextModificar.Size = new Size(153, 15);
            TextModificar.TabIndex = 8;
            TextModificar.Text = "Elija la opcion a modificar ⬇";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(30, 30, 30);
            label2.ForeColor = Color.White;
            label2.Location = new Point(26, 32);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 9;
            label2.Text = "Corte";
            // 
            // TextPrecio
            // 
            TextPrecio.AutoSize = true;
            TextPrecio.BackColor = Color.FromArgb(30, 30, 30);
            TextPrecio.ForeColor = Color.White;
            TextPrecio.Location = new Point(21, 101);
            TextPrecio.Name = "TextPrecio";
            TextPrecio.Size = new Size(40, 15);
            TextPrecio.TabIndex = 10;
            TextPrecio.Text = "Precio";
            // 
            // TextCantidad
            // 
            TextCantidad.AutoSize = true;
            TextCantidad.BackColor = Color.FromArgb(30, 30, 30);
            TextCantidad.ForeColor = Color.White;
            TextCantidad.Location = new Point(7, 130);
            TextCantidad.Name = "TextCantidad";
            TextCantidad.Size = new Size(55, 15);
            TextCantidad.TabIndex = 11;
            TextCantidad.Text = "Cantidad";
            // 
            // BotonRegresar
            // 
            BotonRegresar.BackColor = Color.Black;
            BotonRegresar.FlatStyle = FlatStyle.Flat;
            BotonRegresar.ForeColor = Color.Red;
            BotonRegresar.Location = new Point(176, 11);
            BotonRegresar.Name = "BotonRegresar";
            BotonRegresar.Size = new Size(75, 23);
            BotonRegresar.TabIndex = 12;
            BotonRegresar.Text = "Regresar";
            BotonRegresar.UseVisualStyleBackColor = false;
            BotonRegresar.Click += BotonRegresar_Click;
            // 
            // GroupBoxDatos
            // 
            GroupBoxDatos.Controls.Add(TextBoxCorte);
            GroupBoxDatos.Controls.Add(Precio);
            GroupBoxDatos.Controls.Add(TextCantidad);
            GroupBoxDatos.Controls.Add(Cantidad);
            GroupBoxDatos.Controls.Add(TextPrecio);
            GroupBoxDatos.Controls.Add(TextCorte);
            GroupBoxDatos.Controls.Add(label2);
            GroupBoxDatos.Controls.Add(ListaTipos);
            GroupBoxDatos.ForeColor = SystemColors.ButtonHighlight;
            GroupBoxDatos.Location = new Point(34, 99);
            GroupBoxDatos.Name = "GroupBoxDatos";
            GroupBoxDatos.Size = new Size(198, 162);
            GroupBoxDatos.TabIndex = 13;
            GroupBoxDatos.TabStop = false;
            GroupBoxDatos.Text = "Datos";
            // 
            // FormAlta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(269, 381);
            Controls.Add(GroupBoxDatos);
            Controls.Add(BotonRegresar);
            Controls.Add(TextModificar);
            Controls.Add(TextError);
            Controls.Add(BotonAgregar);
            Controls.Add(ListaCortesCarne);
            Name = "FormAlta";
            Text = "FormAlta";
            Load += FormAlta_Load;
            ((System.ComponentModel.ISupportInitialize)Precio).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cantidad).EndInit();
            GroupBoxDatos.ResumeLayout(false);
            GroupBoxDatos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxCorte;
        private NumericUpDown Precio;
        private NumericUpDown Cantidad;
        private ComboBox ListaCortesCarne;
        private Button BotonAgregar;
        private Label TextError;
        private Label TextCorte;
        private ComboBox ListaTipos;
        private Label TextModificar;
        private Label label2;
        private Label TextPrecio;
        private Label TextCantidad;
        private Button BotonRegresar;
        private GroupBox GroupBoxDatos;
    }
}