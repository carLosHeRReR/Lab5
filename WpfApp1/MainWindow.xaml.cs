using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-54SNKJH2\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=carlos;Password=elpapugomez910";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertarEmpleados", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdEmpleado", int.Parse(txtIdEmpleado.Text));
                    cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@cargo", txtCargo.Text);
                    cmd.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(txtFechaNacimiento.Text));
                    cmd.Parameters.AddWithValue("@FechaContratacion", DateTime.Parse(txtFechaContratacion.Text));
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@ciudad", txtCiudad.Text);
                    cmd.Parameters.AddWithValue("@region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@codPostal", txtCodPostal.Text);
                    cmd.Parameters.AddWithValue("@pais", txtPais.Text);
                    cmd.Parameters.AddWithValue("@TelDomicilio", txtTelDomicilio.Text);
                    cmd.Parameters.AddWithValue("@Extension", txtExtension.Text);
                    cmd.Parameters.AddWithValue("@notas", txtNotas.Text);
                    cmd.Parameters.AddWithValue("@Jefe", int.Parse(txtJefe.Text));
                    cmd.Parameters.AddWithValue("@sueldoBasico", decimal.Parse(txtSueldoBasico.Text));
                    cmd.Parameters.AddWithValue("@Activo", chkActivo.IsChecked.Value ? 1 : 0);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Empleado ingresado correctamente.");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error en la base de datos: " + sqlEx.Message);
            }
            catch (FormatException fEx)
            {
                MessageBox.Show("Por favor, asegúrese de que todos los campos estén llenados correctamente: " + fEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el empleado: " + ex.Message);
            }
        }
    }
}
