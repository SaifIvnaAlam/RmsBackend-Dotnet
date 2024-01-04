using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string UserEmail, string Password)
        {
            var res = DataAccessFactory.Authdata().Authenticate(UserEmail, Password);
            if (res)
            {
        /*        var token = new Token();
                token.UserEmail = UserEmail;
                token.CreatedAt = DateTime.Now;
                token.TokenKey = Guid.NewGuid().ToString();*/
                var ret = DataAccessFactory.TokenData().Create(new Token
                {
                    TokenKey = Guid.NewGuid().ToString(),
                    
                    CreatedAt = DateTime.Now,
                     UserEmail = UserEmail,
                });
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }

            }
            return null;


        }
    }
}
 