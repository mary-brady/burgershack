using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using burgershack.Models;
using Dapper;

namespace burgershack.Repository
{
    public class UserRepository
    {

        IDbConnection _db;
        //REGISTER - create;
        public User Register(UserRegsistration creds)
        {
            //generate userId
            //hash the pass
            string hash = BCrypt.Net.BCrypt.HashPassword(creds.Password);
            string id = Guid.NewGuid().ToString();

            int success = _db.Execute(@"
            INSERT INTO users (id, username, email, hash)
            VALUES (@id, @username, @email, @hash);
            ", new
            {
                id,
                username = creds.Username,
                email = creds.Email,
                hash,
            });

            if (success != 1) { return null; }

            return new User()
            {
                Username = creds.Username,
                Email = creds.Email,
                Hash = null,
                Id = id
            };
        }

        //LOGIN - read
        public User Login(UserLogin creds)
        {
            User user = _db.Query<User>(@"
           SELECT * from users WHERE email = @Email
           ", creds).FirstOrDefault();
            if (user == null) { return null; }

            bool validPass = BCrypt.Net.BCrypt.Verify(creds.Password, user.Hash);

            if (!validPass) { return null; }
            user.Hash = null;
            return user;
        }
        public UserRepository(IDbConnection db)
        {
            _db = db;
        }
    }

    //UPDATE - update
    //CHANGE PASSWORD - update (special u)
    //DELETE - Delete
}
