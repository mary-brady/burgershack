using System;
using System.Data;
using BCrypt.Net;
using burgershack.Models;

namespace burgershack.Repository
{
    public class UserRepository
    {

        IDbConnection _db;
        //REGISTER - create
        SaltRevision SALT = SaltRevision.Revision2X;
        public User Register(UserRegsistration creds)
        {
            //generate userId
            //hash the pass
            string hash = BCrypt.Net.BCrypt.HashPassword(creds.Password, SALT);
            var id = Guid.NewGuid();
        }

        //LOGIN - read
        //UPDATE - update
        //CHANGE PASSWORD - update (special u)
        //DELETE - Delete


        public UserRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}