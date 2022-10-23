using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CLASELABRAD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Aviso", txtnombres.Text + " " + txtapellidos.Text, "OK");
        }

        private  async void btnsegunda_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleados
            {
                nombres = txtnombres.Text,
                apellidos = txtapellidos.Text,
                telefono = Convert.ToInt32(txtelefono.Text),
                correo = txtcorreo.Text,
            };

            var page = new Views.Pagetwo();
            page.BindingContext = emple;
            await Navigation.PushAsync(page);


          // await  Navigation.PushAsync(new Views.Pagetwo());
        }
    }
}
