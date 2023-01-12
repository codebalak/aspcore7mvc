using aspcore7mvc.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspcore7mvc.Repository
{
    public class PersonLocationRepo
    {
        private readonly DatabaseContext _context;
        public PersonLocationRepo(DatabaseContext context)
        {
            
            _context = context;//deppendency injection
        }

        public bool SaveLocation(PersonLocation prloc)
        {
            try
            {

                _context.PersonLocation.Add(prloc);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex) {
                return false;
            }

        }

               public IQueryable GetLocations()
        {



            var personloc  = from g in _context.PersonLocation
                         join m in _context.Person on g.PersonID equals m.Id
                         select new
                         {
                             Id = g.Id,
                             LocationName = g.LocationName,
                             Name = m.Name,
                             LocDate = g.LocDate
                         };
            return personloc;


        }



    }
}
