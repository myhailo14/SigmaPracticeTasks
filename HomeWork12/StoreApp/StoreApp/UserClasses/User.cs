using StoreApp.Interfaces;

namespace StoreApp.UserClasses;

class User : IUserHandler
{
    protected long _id;
    protected string _name;
    protected string _surname;
    protected string _phoneNumber;
    protected DateOnly _birthDate;
    public string Email;
    protected string _login;
    protected string _password;

    public User(string email)
    {
        _id = 0;
        _name = "Test";
        _surname = "Test";
        _phoneNumber = "+380999222222";
        Email = "mykhailo.vovkanych@gmail.com";
        _birthDate = new DateOnly(2000,1,1);
        _login = "TestUser1";
        _password = "1111";
    }

    public User(long id, string name, string surname, string phoneNumber, DateOnly birthDate, string login, string password, string email)
    {
        _id = id;
        _name = name;
        _surname = surname;
        _phoneNumber = phoneNumber;
        _birthDate = birthDate;
        _login = login;
        _password = password;
        Email = email;
    }

    public bool ChangePassword(string oldPassword, string newPassword)
    {
        if (String.CompareOrdinal(oldPassword, _password) == 0)
        {
            _password = newPassword;
            return true;
        }

        return false;
    }

    public bool ChangePhoneNumber(string newNumber)
    {
        _phoneNumber = newNumber;
        return true;
    }

    public bool ChangeName(string name, string surname)
    {
        if (string.IsNullOrWhiteSpace(name) == false)
        {
            _name = name;
        }

        if (string.IsNullOrWhiteSpace(surname) == false)
        {
            _surname = surname;
        }

        return true;
    }
}