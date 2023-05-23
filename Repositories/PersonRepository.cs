using InterviewTest.Models;
using InterviewTest.Repositories.Abstractions;

namespace InterviewTest.Repositories
{
    public interface IPersonRepository: IRepository<Person,PersonContext>
    {

    }
    public class PersonRepository : RepositoryBase<Person, PersonContext>, IPersonRepository
    {
        public PersonRepository(PersonContext personDbContext) : base(personDbContext)
        {
        }
    }
}
