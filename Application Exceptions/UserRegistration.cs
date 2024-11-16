using System;
using System.Text.RegularExpressions;

namespace Application_Exceptions
{
    class InvalidUserNameException : ApplicationException
    {
        public InvalidUserNameException(string message) : base(message)
        { }
    }
    class InvalidPhnoException : ApplicationException {
        public InvalidPhnoException(string message) : base(message) { }
    }
    internal class UserRegistration
    {
        private string _userName;
        private string _phno;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Phno
        {
            get => _phno;
            set { _phno = value; }
        }
        UserRegistration(string username,string phno) { 
            UserName= username;
            Phno = phno;
        }
        void Register()
        {
            string pattern1 = @"^(?=.{1,6})[A-Za-z]+[\-@_#$%][A-Za-z]";
            string pattern2 = @"\d{10}";
            bool ismatchusername=Regex.IsMatch(UserName, pattern1);
            bool ismatchphno = Regex.IsMatch(Phno, pattern2);
            if (ismatchusername && ismatchphno)
            {
                Console.WriteLine("Registration successful");
            }
            if(!ismatchusername)
            {
                throw new InvalidUserNameException("Invalid username");
            }
            
            if (!ismatchphno)
            {
                throw new InvalidPhnoException("Invalid phno");
            }

        }
        static void Main(string[] args)
        {
                UserRegistration u=new UserRegistration("shr@e","9591099202");
                try
                {
                    u.Register();
                }
                catch (InvalidUserNameException e)
                {
                    Console.WriteLine(e.Message);
                }
            catch(InvalidPhnoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        }
    }

