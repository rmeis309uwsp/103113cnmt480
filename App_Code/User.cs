using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }

    public User(int id, string name, string password, string email, string type)
    {
        Id = id;
        Login = name;
        Password = password;
        Email = email;
        Type = type;
    }

    public User(string name, string password, string email, string type)
    {
        Login = name;
        Password = password;
        Email = email;
        Type = type;
    }
}