using Curso.Core.Datos;
using Curso.Core.Entidades;
using Curso.Core.Negocio;

namespace CursoAppWin
{
    public partial class Form1 : Form
    {
        private CursoNegocio _cursoNegocio;

        public Form1()
        {
            var config = new AppConfig();
            config.ConnectionString = Properties.Settings.Default.CursoConnectionString;

            _cursoNegocio = new CursoNegocio(config);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            //var cursoNegocio = new CursoNegocio();
            var cursos = _cursoNegocio.ObtenerListado();

            dataGridView1.DataSource = cursos;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //var cursoNegocio = new CursoNegocio();
            var cursos = _cursoNegocio.Buscar(txtTextoABuscar.Text);

            dataGridView1.DataSource = cursos;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Settings.Default.Titulo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var cursoNuevo = new Curso.Core.Entidades.Curso()
            {
                CursoNombre = txtNombre.Text
            };

            var seCreo = false;

            try
            {
                seCreo = _cursoNegocio.Crear(cursoNuevo);
            }
            catch (Exception ex)
            {
;               MessageBox.Show($"Error: {ex.Message}");
            }
            


            if (seCreo)
            {
                MessageBox.Show("Curso creado correctamente");
            }
            else
            {
                MessageBox.Show("Error al crear el curso");
            }

            Actualizar();
        }
    }
}
