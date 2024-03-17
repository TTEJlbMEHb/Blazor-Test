using BlazorPeople.Data.ApplicationDbContext;
using BlazorPeople.Domain.Entity;
using BlazorPeople.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeople.Infrastructure.Repository
{
    public class PersonRepository : IBaserepository<Person>
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository (ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Person entity)
        {
            await _db.People.AddAsync(entity);
            await _db.SaveChangesAsync();
        }       

        public IQueryable<Person> GetAll()
        {
            return _db.People;
        }

        public async Task Update(Person entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Person entity)
        {
            _db.People.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
