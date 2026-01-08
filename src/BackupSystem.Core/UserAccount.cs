using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.Core;

public class UserAccount
{
    private readonly string _login;
    private readonly string _password;

    public bool IsLocked { get; private set; }
    public int FailedLoginAttempts { get; private set; }

    public const int MaxLoginAttempts = 3;

    public UserAccount(string login, string password)
    {
        _login = login;
        _password = password;
    }

    public void Login(string login, string password)
    {
        if (IsLocked)
            throw new InvalidOperationException("Account is locked.");

        if (login != _login || password != _password)
        {
            FailedLoginAttempts++;

            if (FailedLoginAttempts >= MaxLoginAttempts) 
                IsLocked = true;

            return;
        }

        FailedLoginAttempts = 0;
    }
}
