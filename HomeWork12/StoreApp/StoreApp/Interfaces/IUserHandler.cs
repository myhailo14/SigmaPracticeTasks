namespace StoreApp.Interfaces;

interface IUserHandler
{
    bool ChangePassword(string oldPassword, string newPassword);
    bool ChangePhoneNumber(string newNumber);
    bool ChangeName(string name, string surname);
}