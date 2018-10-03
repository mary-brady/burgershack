using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repository
{
    public class SaladsRepository
    {
        private IDbConnection _db;
        public SaladsRepository(IDbConnection db)
        {
            _db = db;
        }

        //CRUD via SQL

        //GET ALL Salads
        public IEnumerable<Salad> GetAll()
        {
            return _db.Query<Salad>("SELECT * FROM salads;");
        }
        //GET Salad BY ID

        public Salad GetById(int id)
        {
            return _db.Query<Salad>("SELECT * FROM salads WHERE id = @id", new { id }).FirstOrDefault();
        }
        //CREATE Salad
        public Salad Create(Salad salad)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO salads (name, description, price)
            VALUES (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();", salad
            );
            salad.Id = id;
            return salad;
        }
        //UPDATE Salad
        public Salad Update(Salad salad)
        {
            _db.Execute(@"
            UPDATE salads SET (name, description, price) 
            VALUES (@Name, @Description, @Price)
            WHERE id = @Id
            ", salad);
            return salad;
        }
        //DELETE Salad
        public Salad Delete(Salad salad)
        {
            _db.Execute("DELETE FROM salads WHERE id = @Id", salad);
            return salad;
        }
        public int Delete(int id)
        {
            return _db.Execute("DELETE FROM salads WHERE id = @id", new { id });
        }
    }
}