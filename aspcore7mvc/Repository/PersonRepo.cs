using aspcore7mvc.Models;
using aspcore7mvc.Models.Domain;

namespace aspcore7mvc.Repository
{
    public class PersonRepo
    {
        private readonly DatabaseContext _context;
        public PersonRepo(DatabaseContext context) 
        {
            ;//we can also paas it in constructor but now no need
            _context = context;//depp
        } 


            public List<Person> GetPersons()
        {
            return _context.Person.ToList();
        }

    }
}
