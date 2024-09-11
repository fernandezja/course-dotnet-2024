using Curso.Core.Datos;
using Curso.Core.Negocio;

namespace CursoAppWin
{
    public partial class Form1 : Form
    {
        private CursoNegocio _cursoNegocio = new CursoNegocio();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
