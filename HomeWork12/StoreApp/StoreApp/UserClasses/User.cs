using StoreApp.Interfaces;

namespace StoreApp.UserClasses;

class User : IUserHandler
{
    protected long _id;
    protected string _name;
    protected string _surname;
    protected string _phoneNumber;
    protected DateOnly _brithDate;
    protected string _login;
    protected string _password;


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