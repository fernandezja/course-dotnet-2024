namespace CursoAppWin
{
    partial class Form1
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            btnBuscar = new Button();
            txtTextoABuscar = new TextBox();
            pnlCurso = new Panel();
            btnGuardar = new Button();
            label1 = new Label();
            txtNombre = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlCurso.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(600, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Listado";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(643, 192);
            dataGridView1.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(257, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtTextoABuscar
            // 
            txtTextoABuscar.Location = new Point(32, 12);
            txtTextoABuscar.Name = "txtTextoABuscar";
            txtTextoABuscar.Size = new Size(219, 23);
            txtTextoABuscar.TabIndex = 3;
            // 
            // pnlCurso
            // 
            pnlCurso.Controls.Add(txtNombre);
            pnlCurso.Controls.Add(label1);
            pnlCurso.Controls.Add(btnGuardar);
            pnlCurso.Location = new Point(32, 272);
            pnlCurso.Name = "pnlCurso";
            pnlCurso.Size = new Size(314, 110);
            pnlCurso.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(19, 68);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 5);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(19, 23);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(260, 23);
            txtNombre.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlCurso);
            Controls.Add(txtTextoABuscar);
            Controls.Add(btnBuscar);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlCurso.ResumeLayout(false);
            pnlCurso.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button btnBuscar;
        private TextBox txtTextoABuscar;
        private Panel pnlCurso;
        private TextBox txtNombre;
        private Label label1;
        private Button btnGuardar;
    }
}
