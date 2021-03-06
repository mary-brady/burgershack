using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repository
{
    public class BurgersRepository
    {
        private IDbConnection _db;
        public BurgersRepository(IDbConnection db)
        {
            _db = db;
        }

        //CRUD via SQL

        //GET ALL BURGERS
        public IEnumerable<Burger> GetAll()
        {
            return _db.Query<Burger>("SELECT * FROM burgers;");
        }
        //GET BURGER BY ID

        public Burger GetById(int id)
        {
            return _db.Query<Burger>("SELECT * FROM burgers WHERE id = @id", new { id }).FirstOrDefault();
        }
        //CREATE BURG
        public Burger Create(Burger burger)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO burgers (name, description, price)
            VALUES (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();", burger
            );
            burger.Id = id;
            return burger;
        }
        //UPDATE BURG
        public Burger Update(Burger burger)
        {
            _db.Execute(@"
            UPDATE burgers 
            SET name = @Name, description = @Description, price = @Price
            WHERE id = @Id
            ", burger);
            return burger;
        }
        //DELETE BURG
        public Burger Delete(Burger burger)
        {
            _db.Execute("DELETE FROM burgers WHERE id = @Id", burger);
            return burger;
        }
        public int Delete(int id)
        {
            return _db.Execute("DELETE FROM burgers WHERE id = @Id", new { id });
        }
    }
}