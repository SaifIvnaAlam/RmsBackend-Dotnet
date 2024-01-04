using DAL.Domain.Models;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();  
        }
        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo();
        }
        public static IAuth<bool> Authdata()
        {
            return new UserRepo();
        }
        public static IRepo <Token, String, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
