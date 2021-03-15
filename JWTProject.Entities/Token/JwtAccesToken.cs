using JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWTProject.Entities.Token
{
    public class JwtAccesToken:IToken
    {
        public string Token { get; set; }
    }
}
