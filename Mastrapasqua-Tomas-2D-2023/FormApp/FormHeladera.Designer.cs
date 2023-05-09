namespace FormApp
{
    partial class Heladera
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            pictureBox3 = new PictureBox();
            saludo = new Label();
            botonRegresar = new Button();
            dataGridViewCarne = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            ColumnTipo = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewImageColumn();
            FotoCarne = new PictureBox();
            botoAgregar = new Button();
            button1 = new Button();
            Eliminar = new Button();
            button7 = new Button();
            Actualizar = new Button();
            ListaProductos = new ListView();
            columnHeader1 = new ColumnHeader();
            ListClientes = new ListBox();
            lista = new Label();
            button2 = new Button();
            BotonFacturas = new Button();
            BotonUsuario = new Button();
            esRecargo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FotoCarne).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(30, 30, 30);
            pictureBox3.Image = Properties.Resources.Carniceria_Mastra_26_4_2023__1_1;
            pictureBox3.Location = new Point(884, 182);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(197, 92);
            pictureBox3.TabIndex = 35;
            pictureBox3.TabStop = false;
            // 
            // saludo
            // 
            saludo.AutoSize = true;
            saludo.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            saludo.ForeColor = SystemColors.ControlLight;
            saludo.Location = new Point(153, 41);
            saludo.Name = "saludo";
            saludo.Size = new Size(47, 14);
            saludo.TabIndex = 27;
            saludo.Text = "Saludo";
            // 
            // botonRegresar
            // 
            botonRegresar.BackColor = Color.Black;
            botonRegresar.FlatStyle = FlatStyle.Flat;
            botonRegresar.ForeColor = SystemColors.ButtonHighlight;
            botonRegresar.Location = new Point(12, 6);
            botonRegresar.Name = "botonRegresar";
            botonRegresar.Size = new Size(135, 49);
            botonRegresar.TabIndex = 54;
            botonRegresar.Text = "Regresar al menu";
            botonRegresar.UseVisualStyleBackColor = false;
            botonRegresar.Click += botonRegresar_Click;
            // 
            // dataGridViewCarne
            // 
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.ForeColor = SystemColors.ButtonShadow;
            dataGridViewCarne.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCarne.BackgroundColor = Color.Black;
            dataGridViewCarne.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCarne.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCarne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarne.Columns.AddRange(new DataGridViewColumn[] { Column1, ColumnTipo, Column2, Column3, Column4 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle3.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewCarne.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCarne.GridColor = SystemColors.ActiveCaptionText;
            dataGridViewCarne.Location = new Point(12, 61);
            dataGridViewCarne.Name = "dataGridViewCarne";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle4.SelectionBackColor = Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewCarne.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle5.SelectionBackColor = Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCarne.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCarne.RowTemplate.Height = 25;
            dataGridViewCarne.Size = new Size(592, 528);
            dataGridViewCarne.TabIndex = 55;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "(ninguno)";
            Column1.HeaderText = "Corte de carne";
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // ColumnTipo
            // 
            ColumnTipo.HeaderText = "Tipo";
            ColumnTipo.Name = "ColumnTipo";
            // 
            // Column2
            // 
            Column2.HeaderText = "Precio";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Cantidad disponible";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Imagen";
            Column4.Name = "Column4";
            Column4.Resizable = DataGridViewTriState.True;
            Column4.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // FotoCarne
            // 
            FotoCarne.BackColor = Color.Black;
            FotoCarne.BorderStyle = BorderStyle.Fixed3D;
            FotoCarne.Location = new Point(620, 112);
            FotoCarne.Name = "FotoCarne";
            FotoCarne.Size = new Size(229, 196);
            FotoCarne.TabIndex = 58;
            FotoCarne.TabStop = false;
            // 
            // botoAgregar
            // 
            botoAgregar.BackColor = Color.Black;
            botoAgregar.FlatStyle = FlatStyle.Flat;
            botoAgregar.ForeColor = Color.Lime;
            botoAgregar.Location = new Point(153, 6);
            botoAgregar.Name = "botoAgregar";
            botoAgregar.Size = new Size(100, 31);
            botoAgregar.TabIndex = 65;
            botoAgregar.Text = "Agregar";
            botoAgregar.UseVisualStyleBackColor = false;
            botoAgregar.Click += botoAgregar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonShadow;
            button1.Location = new Point(624, 61);
            button1.Name = "button1";
            button1.Size = new Size(21, 23);
            button1.TabIndex = 73;
            button1.Text = "?";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // Eliminar
            // 
            Eliminar.BackColor = Color.Black;
            Eliminar.FlatStyle = FlatStyle.Flat;
            Eliminar.ForeColor = Color.Red;
            Eliminar.Location = new Point(365, 6);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(100, 31);
            Eliminar.TabIndex = 90;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.Black;
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.Yellow;
            button7.Location = new Point(259, 6);
            button7.Name = "button7";
            button7.Size = new Size(100, 31);
            button7.TabIndex = 91;
            button7.Text = "Modificar";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // Actualizar
            // 
            Actualizar.BackColor = Color.Black;
            Actualizar.FlatStyle = FlatStyle.Flat;
            Actualizar.ForeColor = Color.LightGray;
            Actualizar.Location = new Point(471, 6);
            Actualizar.Name = "Actualizar";
            Actualizar.Size = new Size(100, 31);
            Actualizar.TabIndex = 92;
            Actualizar.Text = "Actualizar lista";
            Actualizar.UseVisualStyleBackColor = false;
            Actualizar.Click += Actualizar_Click;
            // 
            // ListaProductos
            // 
            ListaProductos.BackColor = SystemColors.MenuText;
            ListaProductos.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            ListaProductos.ForeColor = SystemColors.ButtonHighlight;
            ListaProductos.Location = new Point(884, 292);
            ListaProductos.Name = "ListaProductos";
            ListaProductos.Size = new Size(229, 182);
            ListaProductos.TabIndex = 93;
            ListaProductos.UseCompatibleStateImageBehavior = false;
            // 
            // ListClientes
            // 
            ListClientes.BackColor = SystemColors.MenuText;
            ListClientes.ForeColor = SystemColors.ButtonHighlight;
            ListClientes.FormattingEnabled = true;
            ListClientes.ItemHeight = 15;
            ListClientes.Location = new Point(620, 345);
            ListClientes.Name = "ListClientes";
            ListClientes.Size = new Size(225, 244);
            ListClientes.TabIndex = 94;
            ListClientes.SelectedIndexChanged += ListClientes_SelectedIndexChanged;
            // 
            // lista
            // 
            lista.AutoSize = true;
            lista.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lista.ForeColor = SystemColors.ControlLight;
            lista.Location = new Point(624, 328);
            lista.Name = "lista";
            lista.Size = new Size(123, 14);
            lista.TabIndex = 95;
            lista.Text = "Listado de compras";
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(884, 485);
            button2.Name = "button2";
            button2.Size = new Size(229, 44);
            button2.TabIndex = 97;
            button2.Text = "Aceptar compra";
            button2.UseVisualStyleBackColor = false;
            button2.Click += BotonAceptar_Click;
            // 
            // BotonFacturas
            // 
            BotonFacturas.BackColor = Color.Black;
            BotonFacturas.FlatStyle = FlatStyle.Flat;
            BotonFacturas.ForeColor = Color.LightGray;
            BotonFacturas.Location = new Point(577, 6);
            BotonFacturas.Name = "BotonFacturas";
            BotonFacturas.Size = new Size(100, 31);
            BotonFacturas.TabIndex = 98;
            BotonFacturas.Text = "Ver facturas";
            BotonFacturas.UseVisualStyleBackColor = false;
            BotonFacturas.Click += BotonFacturas_Click;
            // 
            // BotonUsuario
            // 
            BotonUsuario.BackColor = Color.Black;
            BotonUsuario.FlatStyle = FlatStyle.Flat;
            BotonUsuario.ForeColor = Color.LightGray;
            BotonUsuario.Location = new Point(683, 6);
            BotonUsuario.Name = "BotonUsuario";
            BotonUsuario.Size = new Size(100, 31);
            BotonUsuario.TabIndex = 99;
            BotonUsuario.Text = "Usuario";
            BotonUsuario.UseVisualStyleBackColor = false;
            BotonUsuario.Click += BotonUsuario_Click;
            // 
            // esRecargo
            // 
            esRecargo.AutoSize = true;
            esRecargo.ForeColor = SystemColors.ButtonHighlight;
            esRecargo.Location = new Point(884, 535);
            esRecargo.Name = "esRecargo";
            esRecargo.Size = new Size(119, 19);
            esRecargo.TabIndex = 100;
            esRecargo.Text = "Pago con recargo";
            esRecargo.UseVisualStyleBackColor = true;
            // 
            // Heladera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1390, 651);
            Controls.Add(esRecargo);
            Controls.Add(BotonUsuario);
            Controls.Add(BotonFacturas);
            Controls.Add(button2);
            Controls.Add(lista);
            Controls.Add(ListClientes);
            Controls.Add(ListaProductos);
            Controls.Add(Actualizar);
            Controls.Add(button7);
            Controls.Add(Eliminar);
            Controls.Add(button1);
            Controls.Add(botoAgregar);
            Controls.Add(FotoCarne);
            Controls.Add(dataGridViewCarne);
            Controls.Add(botonRegresar);
            Controls.Add(pictureBox3);
            Controls.Add(saludo);
            Name = "Heladera";
            Text = "FormVendedor";
            Load += FormVendedor_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarne).EndInit();
            ((System.ComponentModel.ISupportInitialize)FotoCarne).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox3;
        private Label saludo;
        private Button botonRegresar;
        private PictureBox FotoCarne;
#pragma warning disable CS0169 // El campo 'Heladera.numericUpDown11' nunca se usa
        private NumericUpDown numericUpDown11;
#pragma warning restore CS0169 // El campo 'Heladera.numericUpDown11' nunca se usa
#pragma warning disable CS0169 // El campo 'Heladera.numericUpDown12' nunca se usa
        private NumericUpDown numericUpDown12;
#pragma warning restore CS0169 // El campo 'Heladera.numericUpDown12' nunca se usa
        public DataGridView dataGridView1;
        private Button botoAgregar;
#pragma warning disable CS0169 // El campo 'Heladera.checkedListBox1' nunca se usa
        private CheckedListBox checkedListBox1;
        private Button Eliminar;
        private Button button7;
        public DataGridView dataGridViewCarne;
        private Button Actualizar;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn ColumnTipo;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewImageColumn Column4;
        private ListView ListaProductos;
        private ColumnHeader columnHeader1;
        private ListBox ListClientes;
        private Label lista;
        private Button button2;
        private Button BotonFacturas;
        private Button BotonUsuario;
        private CheckBox esRecargo;
    }
}