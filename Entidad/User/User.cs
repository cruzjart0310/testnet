using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.User
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string name, string lastName, string email, string password)
        {
            this.id_ = id;
            this.name_ = name;
            this.lastName_ = lastName;
            this.email_ = email;
            this.password_ = password;
        }

        private int id_;

        public int Id_
        {
            get { return id_; }
            set { id_ = value; }
        }
        private string name_;

        public string Name_
        {
            get { return name_; }
            set { name_ = value; }
        }
        private string lastName_;

        public string LastName_
        {
            get { return lastName_; }
            set { lastName_ = value; }
        }
        private string email_;

        public string Email_
        {
            get { return email_; }
            set { email_ = value; }
        }
        private string password_;

        public string Password_
        {
            get { return password_; }
            set { password_ = value; }
        }
    }
}
