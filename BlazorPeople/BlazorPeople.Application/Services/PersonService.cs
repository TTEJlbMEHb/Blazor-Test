using BlazorPeople.Domain.Entity;
using BlazorPeople.Domain.Interfaces.Repository;
using BlazorPeople.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeople.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IBaserepository<Person> _personRepository;

        public PersonService(IBaserepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetPeople()
        {
            try
            {
                var response = await _personRepository.GetAll().ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            try
            {
                var response = await _personRepository.GetAll()
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (response == null)
                {
                    throw new Exception("Person does not exist");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> CreatePerson(Person person)
        {
            try
            {
                var existingPerson = await _personRepository.GetAll()
                    .FirstOrDefaultAsync(p => p.Firstname == person.Firstname &&
                                              p.Lastname == person.Lastname &&
                                              p.Age == person.Age &&
                                              p.Occupation == person.Occupation);

                if (existingPerson != null)
                {
                    throw new Exception("Person already exists");
                }

                var newPerson = new Person()
                {
                    Firstname = person.Firstname,
                    Lastname = person.Lastname,
                    Age = person.Age,
                    Occupation = person.Occupation
                };

                await _personRepository.Create(newPerson);
                return newPerson;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            try
            {
                var response = await _personRepository.GetAll()
                    .FirstOrDefaultAsync(p => p.Id == person.Id);

                if (response == null)
                {
                    throw new Exception("Person does not exist");
                }

                response.Firstname = person.Firstname;
                response.Lastname = person.Lastname;
                response.Age = person.Age;
                response.Occupation = person.Occupation;

                await _personRepository.Update(response);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> DeletePerson(int id)
        {
            try
            {
                var responce = await _personRepository.GetAll()
                    .FirstOrDefaultAsync (p => p.Id == id);

                if (responce == null)
                {
                    throw new Exception("Person does not exist");
                }

                await _personRepository.Delete(responce);
                return responce;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
