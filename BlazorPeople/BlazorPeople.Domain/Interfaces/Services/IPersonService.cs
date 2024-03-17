using BlazorPeople.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeople.Domain.Interfaces.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPerson(int id);
        Task<Person> CreatePerson(Person person);
        Task<Person> UpdatePerson(Person person);
        Task<Person> DeletePerson(int id);
    }
}
