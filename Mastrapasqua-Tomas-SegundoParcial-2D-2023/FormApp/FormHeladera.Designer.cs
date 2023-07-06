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
            botoAgregar = new Button();
            button1 = new Button();
            BotonEliminar = new Button();
            button7 = new Button();
            Actualizar = new Button();
            ListClientes = new ListBox();
            lista = new Label();
            BotonComprar = new Button();
            BotonFacturas = new Button();
            BotonUsuario = new Button();
            esRecargo = new CheckBox();
            BotonAgregarCarro = new Button();
            BotonVerCarro = new Button();
            ListCarro = new ListBox();
            Cantidad = new NumericUpDown();
            cantidadComprarCarne = new Label();
            PrecioKilo = new Label();
            PrecioTotal = new Label();
            BotonCancelarCliente = new Button();
            button2 = new Button();
            button3 = new Button();
            labelHora = new Label();
            button4 = new Button();
            BotonSerializarJson = new Button();
            button6 = new Button();
            BotonDeserializarJson = new Button();
            BotonAgregarStock = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Cantidad).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(30, 30, 30);
            pictureBox3.Image = Properties.Resources.Carniceria_Mastra_26_4_2023__1_1;
            pictureBox3.Location = new Point(613, 43);
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
            button1.Location = new Point(789, 6);
            button1.Name = "button1";
            button1.Size = new Size(21, 23);
            button1.TabIndex = 73;
            button1.Text = "?";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // BotonEliminar
            // 
            BotonEliminar.BackColor = Color.Black;
            BotonEliminar.FlatStyle = FlatStyle.Flat;
            BotonEliminar.ForeColor = Color.Red;
            BotonEliminar.Location = new Point(365, 6);
            BotonEliminar.Name = "BotonEliminar";
            BotonEliminar.Size = new Size(100, 31);
            BotonEliminar.TabIndex = 90;
            BotonEliminar.Text = "Eliminar";
            BotonEliminar.UseVisualStyleBackColor = false;
            BotonEliminar.Click += Eliminar_Click;
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
            button7.Click += BotonModificar_Click;
            // 
            // Actualizar
            // 
            Actualizar.BackColor = Color.Black;
            Actualizar.FlatStyle = FlatStyle.Flat;
            Actualizar.ForeColor = Color.LightGray;
            Actualizar.Location = new Point(1280, 435);
            Actualizar.Name = "Actualizar";
            Actualizar.Size = new Size(100, 31);
            Actualizar.TabIndex = 92;
            Actualizar.Text = "Actualizar lista";
            Actualizar.UseVisualStyleBackColor = false;
            Actualizar.Visible = false;
            Actualizar.Click += Actualizar_Click;
            // 
            // ListClientes
            // 
            ListClientes.BackColor = SystemColors.MenuText;
            ListClientes.ForeColor = SystemColors.ButtonHighlight;
            ListClientes.FormattingEnabled = true;
            ListClientes.ItemHeight = 15;
            ListClientes.Location = new Point(906, 41);
            ListClientes.Name = "ListClientes";
            ListClientes.Size = new Size(225, 184);
            ListClientes.TabIndex = 94;
            ListClientes.SelectedIndexChanged += ListClientes_SelectedIndexChanged;
            // 
            // lista
            // 
            lista.AutoSize = true;
            lista.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lista.ForeColor = SystemColors.ControlLight;
            lista.Location = new Point(909, 24);
            lista.Name = "lista";
            lista.Size = new Size(116, 14);
            lista.TabIndex = 95;
            lista.Text = "Listado de clientes";
            // 
            // BotonComprar
            // 
            BotonComprar.BackColor = Color.Black;
            BotonComprar.FlatStyle = FlatStyle.Flat;
            BotonComprar.ForeColor = Color.Lime;
            BotonComprar.Location = new Point(906, 266);
            BotonComprar.Name = "BotonComprar";
            BotonComprar.Size = new Size(225, 44);
            BotonComprar.TabIndex = 97;
            BotonComprar.Text = "Finalizar compra";
            BotonComprar.UseVisualStyleBackColor = false;
            BotonComprar.Click += BotonAceptar_Click;
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
            esRecargo.Location = new Point(909, 241);
            esRecargo.Name = "esRecargo";
            esRecargo.Size = new Size(118, 19);
            esRecargo.TabIndex = 100;
            esRecargo.Text = "Paga con recargo";
            esRecargo.UseVisualStyleBackColor = true;
            // 
            // BotonAgregarCarro
            // 
            BotonAgregarCarro.BackColor = Color.Black;
            BotonAgregarCarro.FlatStyle = FlatStyle.Flat;
            BotonAgregarCarro.ForeColor = SystemColors.ButtonHighlight;
            BotonAgregarCarro.Location = new Point(1149, 266);
            BotonAgregarCarro.Name = "BotonAgregarCarro";
            BotonAgregarCarro.Size = new Size(229, 44);
            BotonAgregarCarro.TabIndex = 101;
            BotonAgregarCarro.Text = "Agregar al carro";
            BotonAgregarCarro.UseVisualStyleBackColor = false;
            BotonAgregarCarro.Click += FormVender_Click;
            // 
            // BotonVerCarro
            // 
            BotonVerCarro.BackColor = Color.Black;
            BotonVerCarro.FlatStyle = FlatStyle.Flat;
            BotonVerCarro.ForeColor = SystemColors.ButtonHighlight;
            BotonVerCarro.Location = new Point(1149, 316);
            BotonVerCarro.Name = "BotonVerCarro";
            BotonVerCarro.Size = new Size(229, 44);
            BotonVerCarro.TabIndex = 102;
            BotonVerCarro.Text = "Ver carro";
            BotonVerCarro.UseVisualStyleBackColor = false;
            BotonVerCarro.Click += BotonVerCarro_Click;
            // 
            // ListCarro
            // 
            ListCarro.BackColor = Color.Black;
            ListCarro.ForeColor = SystemColors.MenuBar;
            ListCarro.FormattingEnabled = true;
            ListCarro.ItemHeight = 15;
            ListCarro.Location = new Point(1145, 42);
            ListCarro.Name = "ListCarro";
            ListCarro.Size = new Size(233, 169);
            ListCarro.TabIndex = 103;
            ListCarro.SelectedIndexChanged += ListCarro_SelectedIndexChanged;
            // 
            // Cantidad
            // 
            Cantidad.BackColor = Color.Black;
            Cantidad.ForeColor = SystemColors.ButtonHighlight;
            Cantidad.Location = new Point(1258, 217);
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(120, 23);
            Cantidad.TabIndex = 104;
            Cantidad.ValueChanged += Cantidad_ValueChanged;
            // 
            // cantidadComprarCarne
            // 
            cantidadComprarCarne.AutoSize = true;
            cantidadComprarCarne.ForeColor = SystemColors.ButtonHighlight;
            cantidadComprarCarne.Location = new Point(1145, 219);
            cantidadComprarCarne.Name = "cantidadComprarCarne";
            cantidadComprarCarne.Size = new Size(112, 15);
            cantidadComprarCarne.TabIndex = 105;
            cantidadComprarCarne.Text = "Cantidad a comprar";
            // 
            // PrecioKilo
            // 
            PrecioKilo.AutoSize = true;
            PrecioKilo.ForeColor = SystemColors.ButtonHighlight;
            PrecioKilo.Location = new Point(1145, 240);
            PrecioKilo.Name = "PrecioKilo";
            PrecioKilo.Size = new Size(81, 15);
            PrecioKilo.TabIndex = 106;
            PrecioKilo.Text = "Precio por KG:";
            // 
            // PrecioTotal
            // 
            PrecioTotal.AutoSize = true;
            PrecioTotal.ForeColor = SystemColors.ButtonHighlight;
            PrecioTotal.Location = new Point(1258, 242);
            PrecioTotal.Name = "PrecioTotal";
            PrecioTotal.Size = new Size(70, 15);
            PrecioTotal.TabIndex = 107;
            PrecioTotal.Text = "Precio total:";
            // 
            // BotonCancelarCliente
            // 
            BotonCancelarCliente.BackColor = Color.Black;
            BotonCancelarCliente.FlatStyle = FlatStyle.Flat;
            BotonCancelarCliente.ForeColor = Color.Red;
            BotonCancelarCliente.Location = new Point(906, 316);
            BotonCancelarCliente.Name = "BotonCancelarCliente";
            BotonCancelarCliente.Size = new Size(225, 44);
            BotonCancelarCliente.TabIndex = 108;
            BotonCancelarCliente.Text = "Cancelar compra";
            BotonCancelarCliente.UseVisualStyleBackColor = false;
            BotonCancelarCliente.Click += BotonCancelarCliente_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.DeepSkyBlue;
            button2.Location = new Point(471, 6);
            button2.Name = "button2";
            button2.Size = new Size(100, 31);
            button2.TabIndex = 109;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.LightGray;
            button3.Location = new Point(1174, 421);
            button3.Name = "button3";
            button3.Size = new Size(100, 58);
            button3.TabIndex = 110;
            button3.Text = "Guardar facturas";
            button3.UseVisualStyleBackColor = false;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // labelHora
            // 
            labelHora.AutoSize = true;
            labelHora.ForeColor = SystemColors.ButtonHighlight;
            labelHora.Location = new Point(1324, 14);
            labelHora.Name = "labelHora";
            labelHora.Size = new Size(13, 15);
            labelHora.TabIndex = 111;
            labelHora.Text = "0";
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(255, 128, 0);
            button4.Location = new Point(613, 157);
            button4.Name = "button4";
            button4.Size = new Size(120, 23);
            button4.TabIndex = 112;
            button4.Text = "Serializar en Xml";
            button4.UseVisualStyleBackColor = false;
            button4.Click += BotonSerializarXml_Click;
            // 
            // BotonSerializarJson
            // 
            BotonSerializarJson.BackColor = Color.Black;
            BotonSerializarJson.FlatStyle = FlatStyle.Flat;
            BotonSerializarJson.ForeColor = Color.FromArgb(128, 128, 255);
            BotonSerializarJson.Location = new Point(613, 202);
            BotonSerializarJson.Name = "BotonSerializarJson";
            BotonSerializarJson.Size = new Size(120, 23);
            BotonSerializarJson.TabIndex = 113;
            BotonSerializarJson.Text = "Serializar en Json";
            BotonSerializarJson.UseVisualStyleBackColor = false;
            BotonSerializarJson.Click += BotonSerializarJson_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.FromArgb(255, 128, 0);
            button6.Location = new Point(739, 157);
            button6.Name = "button6";
            button6.Size = new Size(120, 23);
            button6.TabIndex = 114;
            button6.Text = "Deserializar en Xml";
            button6.UseVisualStyleBackColor = false;
            button6.Click += BotonDeserializarXml_Click;
            // 
            // BotonDeserializarJson
            // 
            BotonDeserializarJson.BackColor = Color.Black;
            BotonDeserializarJson.FlatStyle = FlatStyle.Flat;
            BotonDeserializarJson.ForeColor = Color.FromArgb(128, 128, 255);
            BotonDeserializarJson.Location = new Point(739, 202);
            BotonDeserializarJson.Name = "BotonDeserializarJson";
            BotonDeserializarJson.Size = new Size(120, 23);
            BotonDeserializarJson.TabIndex = 115;
            BotonDeserializarJson.Text = "Deserializar en Json";
            BotonDeserializarJson.UseVisualStyleBackColor = false;
            BotonDeserializarJson.Click += BotonDeserializarJson_Click;
            // 
            // BotonAgregarStock
            // 
            BotonAgregarStock.BackColor = Color.Black;
            BotonAgregarStock.FlatStyle = FlatStyle.Flat;
            BotonAgregarStock.ForeColor = Color.HotPink;
            BotonAgregarStock.Location = new Point(610, 266);
            BotonAgregarStock.Name = "BotonAgregarStock";
            BotonAgregarStock.Size = new Size(120, 44);
            BotonAgregarStock.TabIndex = 116;
            BotonAgregarStock.Text = "Agregar stock (+50)";
            BotonAgregarStock.UseVisualStyleBackColor = false;
            BotonAgregarStock.Click += BotonAgregarStock_Click;
            // 
            // Heladera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1390, 651);
            Controls.Add(BotonAgregarStock);
            Controls.Add(BotonDeserializarJson);
            Controls.Add(button6);
            Controls.Add(BotonSerializarJson);
            Controls.Add(button4);
            Controls.Add(labelHora);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(BotonCancelarCliente);
            Controls.Add(PrecioTotal);
            Controls.Add(PrecioKilo);
            Controls.Add(cantidadComprarCarne);
            Controls.Add(Cantidad);
            Controls.Add(ListCarro);
            Controls.Add(BotonVerCarro);
            Controls.Add(BotonAgregarCarro);
            Controls.Add(esRecargo);
            Controls.Add(BotonUsuario);
            Controls.Add(BotonFacturas);
            Controls.Add(BotonComprar);
            Controls.Add(lista);
            Controls.Add(ListClientes);
            Controls.Add(Actualizar);
            Controls.Add(button7);
            Controls.Add(BotonEliminar);
            Controls.Add(button1);
            Controls.Add(botoAgregar);
            Controls.Add(dataGridViewCarne);
            Controls.Add(botonRegresar);
            Controls.Add(pictureBox3);
            Controls.Add(saludo);
            Name = "Heladera";
            Text = "Heladera \U0001f969";
            Load += FormVendedor_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarne).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox3;
        private Label saludo;
        private Button botonRegresar;
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
        private Button BotonEliminar;
        private Button button7;
        public DataGridView dataGridViewCarne;
        private Button Actualizar;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn ColumnTipo;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewImageColumn Column4;
        private ListView CarroCliente;
        private ColumnHeader columnHeader1;
        private ListBox ListClientes;
        private Label lista;
        private Button BotonComprar;
        private Button BotonFacturas;
        private Button BotonUsuario;
        private CheckBox esRecargo;
        private Button BotonAgregarCarro;
        private Button BotonVerCarro;
        private ListBox ListCarro;
        private NumericUpDown Cantidad;
        private Label cantidadComprarCarne;
        private Label PrecioKilo;
        private Label PrecioTotal;
        private Button BotonCancelarCliente;
        private Button button2;
        private Button button3;
        private Label labelHora;
        private Button button4;
        private Button BotonSerializarJson;
        private Button button6;
        private Button BotonDeserializarJson;
        private Button BotonAgregarStock;
        //private ListBox CarroCliente;
    }
}