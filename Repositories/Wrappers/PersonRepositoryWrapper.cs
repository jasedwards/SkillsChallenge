using InterviewTest.Models;
using InterviewTest.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterviewTest.Repositories.Wrappers
{
    public interface IPersonRepositoryWrapper : IReadOnlyRepositoryWrapper<long, Person>, IWriteOnlyRepositoryWrapper<long, Person>
    {
    }
    public class PersonRepositoryWrapper : RepositoryWrapperBase<PersonContext>, IPersonRepositoryWrapper
    {
        private readonly IPersonRepository _personRepository;

        public PersonRepositoryWrapper(IPersonRepository personRepository) : base(personRepository.DbContext)
        {
            _personRepository = personRepository;
        }

        public async Task<Person?> GetAsync(long id)
        {
            return await _personRepository.GetById(id);
        }

        public async Task<Person?> FindAsync(Expression<Func<Person,bool>> expression)
        {
            return await _personRepository.Get(expression);
        }

        public async Task<ICollection<Person>> SearchAsync(Expression<Func<Person,bool>> expression)
        {
            var result = await _personRepository.GetMany(expression);
            return await Task.FromResult(result.ToList());
        }

        public async Task<ICollection<Person>> GetAllAsync()
        {
            var result = await _personRepository.GetAll();
            return await Task.FromResult(result.ToList());
        }

        public async Task<int> CreateAsync(Person entity)
        {
            try
            {

                await _personRepository.Add(entity);
                await Commit();
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occored while adding entity", ex);
            }
        }
        public async Task<int> UpdateAsync(Person entity)
        {
            try
            {

                var dbEnity = await _personRepository.GetById(entity.Id);
                if(dbEnity == null)
                {
                    throw new Exception("Record not found");
                }
                else
                {
                    return await Task.Run(async () =>
                    {
                        dbEnity.FirstName= entity.FirstName;
                        dbEnity.LastName= entity.LastName;
                        dbEnity.Birthday= entity.Birthday;
                        dbEnity.Hobbies= entity.Hobbies;
                        _personRepository.Update(dbEnity);
                        return await Commit();
                    });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                HandleConcurrency(ex);
                throw new NotSupportedException(
                       "Exception message about concurrency conflict");
            }
            catch (Exception ex)
            {
                throw new Exception("Error occored while adding entity", ex);
            }
        }

        private static void HandleConcurrency(DbUpdateConcurrencyException ex)
        {
            foreach (var entry in ex.Entries)
            {
                if (entry.Entity is Person)
                {
                    var proposedValues = entry.CurrentValues;
                    var databaseValues = entry.GetDatabaseValues();

                    foreach (var property in proposedValues.Properties)
                    {
                        var proposedValue = proposedValues[property];
                        var databaseValue = databaseValues[property];
                    }
                    entry.OriginalValues.SetValues(databaseValues);
                }
            }
        }

        public async Task<int> RemoveAsync(long id)
        {
            try
            {

                var dbEnity = await _personRepository.GetById(id);
                if (dbEnity == null)
                {
                    throw new Exception("Record not found");
                }
                else
                {
                    return await Task.Run(async () =>
                    {
                        _personRepository.Delete(dbEnity);
                        return await Commit();
                    });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                HandleConcurrency(ex);
                throw new NotSupportedException(
                       "Exception message about concurrency conflict");
            }
            catch (Exception ex)
            {
                throw new Exception("Error occored while adding entity", ex);
            }
        }
    }
}
