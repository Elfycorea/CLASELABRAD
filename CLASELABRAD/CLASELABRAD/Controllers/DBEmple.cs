using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CLASELABRAD.Controllers
{
    public class DBEmple
    {
        readonly SQLiteAsyncConnection _conexion;

        //Constructor Vacio
        public DBEmple()
        {

        }
        //Constructor con parametros
        public DBEmple(string dbpath)
        {
            //creacndo una conexion a base de datos sqlite a parirti de path de la base de dtos
            _conexion = new SQLiteAsyncConnection(dbpath);

            //Crear las tablas correspondientes en la base de datos de sqlite
            _conexion.CreateTableAsync<Models.Empleados>().Wait();
           
        }

        //CRUD - APLICACIONES
        //CREATE

        public Task<int> StoreEmple(Models.Empleados emple)
        {
            if (emple.Id != 0)
            {
                return _conexion.UpdateAsync(emple);
            }
            else
            {
                return _conexion.InsertAsync(emple);

            }
        }

        //Read

        public Task<List<Models.Empleados>> listaempleados()
        {
            return _conexion.Table<Models.Empleados>().ToListAsync();
        }

        public Task<Models.Empleados> getempleado(int pid)
        {
            return _conexion.Table<Models.Empleados>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        public Task<int> Deleteempleado(Models.Empleados emple)
        {
            return _conexion.DeleteAsync(emple);
        }



    }
}
