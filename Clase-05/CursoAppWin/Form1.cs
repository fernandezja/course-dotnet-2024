using Curso.Core.Datos;
using Curso.Core.Entidades;
using Curso.Core.Negocio;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CursoAppWin
{
    public partial class Form1 : Form
    {
        private CursoNegocio _cursoNegocio;

        private Curso.Core.Entidades.Curso _cursoSeleccionado;

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
                ; MessageBox.Show($"Error: {ex.Message}");
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            _cursoSeleccionado = (Curso.Core.Entidades.Curso)dataGridView1.CurrentRow.DataBoundItem;

            if (_cursoSeleccionado is not null)
            {
                btnEliminar.Enabled = true;
                //btnEliminar.Tag = cursoSeleccionado.CursoId;

                //Para editar
                txtNombreParaEditar.Text = _cursoSeleccionado.CursoNombre;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seElimino = false;
            try
            {
                seElimino = _cursoNegocio.Eliminar(_cursoSeleccionado.CursoId);
            }
            catch (Exception ex)
            {
                ; MessageBox.Show($"Error: {ex.Message}");
            }

            if (seElimino)
            {
                MessageBox.Show("Curso eliminado");
            }
            else
            {
                MessageBox.Show("Error al eliminar el curso");
            }

            Actualizar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var cursoParaEditar = new Curso.Core.Entidades.Curso()
            {
                CursoId = _cursoSeleccionado.CursoId,
                CursoNombre = txtNombreParaEditar.Text
            };

            var seEdito = false;

            try
            {
                seEdito = _cursoNegocio.Editar(cursoParaEditar);
            }
            catch (Exception ex)
            {
                ; MessageBox.Show($"Error: {ex.Message}");
            }

            Actualizar();
        }
    }
}
