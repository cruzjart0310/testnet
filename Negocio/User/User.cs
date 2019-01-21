using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidad;
using Datos;
namespace Negocio.User
{
    public class User
    {
        public User()
        {

        }

        public Boolean authentication(Entidad.User.User user)
        {
            Boolean retorno = false;
            try
            {
                Datos.User.User instance = new Datos.User.User();
                retorno = instance.authentication(user);
            }
            catch (Exception)
            {

                throw;
            }

            return retorno;
        }

        public List<Entidad.User.User> index()
        {
            try
            {
                List<Entidad.User.User> list = new List<Entidad.User.User>();
                Datos.User.User instance = new Datos.User.User();
                list = instance.index();

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int store(Entidad.User.User user)
        {
            int retorno = 0;
            try
            {
                Datos.User.User instance = new Datos.User.User();
                retorno = instance.store(user);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
