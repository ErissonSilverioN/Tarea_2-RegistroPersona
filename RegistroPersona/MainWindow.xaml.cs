using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegistroPersona.Entidades;
using RegistroPersona.BLL;

namespace RegistroPersona
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


        private void Limpiar()
        {
            TextBoxid.Text = "0";
            TextBoxnombre.Text = string.Empty;
            TextBoxtelefono.Text = string.Empty;
            TextBoxcedula.Text = string.Empty;
            TextBoxdireccion.Text = string.Empty;
            DatePickerfechanacimiento.SelectedDate = DateTime.Now;


        }

        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.PersonaId = Convert.ToInt32(TextBoxid.Text);
            persona.Nombre = TextBoxnombre.Text;
            persona.Telefono = TextBoxtelefono.Text;
            persona.Cedula = TextBoxcedula.Text;
            persona.Direccion = TextBoxdireccion.Text;
            persona.FechaNacimiento = DatePickerfechanacimiento.DisplayDate;

            return persona;


        }

        private void LlenaCampo(Persona persona)
        {
            TextBoxid.Text = Convert.ToString(persona.PersonaId);
            TextBoxnombre.Text = persona.Nombre;
            TextBoxtelefono.Text = persona.Telefono;
            TextBoxcedula.Text = persona.Cedula;
            TextBoxdireccion.Text = persona.Direccion;
            DatePickerfechanacimiento.SelectedDate = persona.FechaNacimiento;

        }

        private bool ExixteEnLaBaseDeDatos()
        {
            Persona persona = PersonaBLL.Buscar((int)Convert.ToInt32(TextBoxid.Text));
            return (persona != null);
        }


        private bool Validar()
        {
            bool paso = true;

           // if (TextBoxid.Text == "0")
           // {
           //     MessageBox.Show("Para buscar el ID debe ser mayor que 0");
           // }
           // paso = false;

            if (TextBoxnombre.Text == string.Empty)
            {
                MessageBox.Show("Este campo es oligatorio");
            }
            paso = false;

            if (TextBoxtelefono.Text == string.Empty)
            {
                MessageBox.Show("Este campo es oligatorio");
            }
            paso = false;

            if (TextBoxcedula.Text == string.Empty)
            {
                MessageBox.Show("Este campo es oligatorio");
            }
            paso = false;

            if (TextBoxdireccion.Text == string.Empty)
            {
                MessageBox.Show("Este campo es oligatorio");
            }
            paso = false;




            return paso;

        }

        private void Buttonguardar_Click(object sender, RoutedEventArgs e)
        {
            Persona persona =new Persona();
            bool paso = false;

          //   if (!Validar())
            //  return;

           persona = LlenaClase();

            if (Convert.ToInt32(TextBoxid.Text) == 0)
                paso = PersonaBLL.Guardar(persona);
            else
            {
                if (!ExixteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe!! ");
                    return;
                }
                paso = PersonaBLL.Modificar(persona);
            }

            if (paso)
            {
                //Limpiar();
                MessageBox.Show("Se ah Guardado");
                Limpiar();

            }
            else
                MessageBox.Show("No se pudo Guardar!!!");
        }

        private void Buttonbuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Persona persona = new Persona();

            int.TryParse(TextBoxid.Text, out id);

            //Limpiar();

            persona = PersonaBLL.Buscar(id);

            if(persona != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void Buttoneliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(TextBoxid.Text, out id);

            if (PersonaBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MessageBox.Show("No se elimino");
        }

        private void Buttonnuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void TextBoxnombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxnombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void TextBoxid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void TextBoxtelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void TextBoxcedula_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }
    }
}
