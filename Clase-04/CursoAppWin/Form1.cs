using Curso.Core.Datos;

namespace CursoAppWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var cursoRepositorio = new CursoRepositorio();
            var cursos = cursoRepositorio.ObtenerListado();
            
            dataGridView1.DataSource = cursos;
        }
    }
}
