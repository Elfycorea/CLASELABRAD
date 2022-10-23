using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace CLASELABRAD
{
    public partial class App : Application
    {
        //CREAR ESTANCIA ESTATICA
        static Controllers.DBEmple dBEmple;

        public static Controllers.DBEmple dbemple
        {
            get
            {
                if(dBEmple == null)
                {
                    string DBName = "emple.db3";
                    string PathDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBName);
                    dBEmple = new Controllers.DBEmple(PathDB);

                }
                return dBEmple;

            }
        }
        public App()
        {
            InitializeComponent();
            //es para activar la navegacion jerarquica para segunda pagina
            MainPage = new NavigationPage(new Views.PagePrincipal()); 

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
