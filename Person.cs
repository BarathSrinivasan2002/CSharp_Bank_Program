using System;
namespace Accounts
{
    public class Person
    {
        private string password;
        public event EventHandler? OnLogin;

        public string SIN { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        public Person(string name, string sin)
        {
            SIN = sin;
            Name = name;
            password = sin.Substring(0, 3);

        }

        public void Login(string password)
        {
            if (!this.password.Equals(password))
            {
                IsAuthenticated = false;
                LoginEventArgs e = new LoginEventArgs(this.Name, IsAuthenticated);
                OnLogin?.Invoke(this, e);
                AccountException WrongPass = new AccountException(ExceptionType.PASSWORD_INCORRECT);
                throw (WrongPass);
            }
            else
            {
                IsAuthenticated = true;
                LoginEventArgs e = new LoginEventArgs(this.Name, IsAuthenticated);
                OnLogin?.Invoke(this, e);
            }
        }
        public void Logout()
        {
            IsAuthenticated = false;
        }

        public override string ToString()
        {
            return this.Name+(this.IsAuthenticated? " Logged In":" Not Logged in");
        }
    }

}

