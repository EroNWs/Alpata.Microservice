﻿using Microsoft.AspNetCore.Http;

namespace Alpata.IdentityServer.Dtos { 

public class SingupDto
{
    public string UserName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }

    }
}