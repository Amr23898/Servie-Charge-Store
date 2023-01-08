using System.Runtime.ConstrainedExecution;
using TaskPionner.Model;

namespace TaskPionner.Repositry
{
    public class ServiceRepository : IRepositoryService
    {
        ServicesDBContext _db;

        public ServiceRepository(ServicesDBContext db)
        {
            _db = db;
        }

        public void Deleteservices(int id)
        {
            var Services = _db.services.FirstOrDefault(x => x.Id == id);
            if(Services != null)
            {
                _db.services.Remove(Services);
                _db.SaveChanges();
            }
        }

        public List<Services> GetallServices()
        {

            return _db.services.ToList();      
        }

        public Services getsSrviceById(int id)
        {
            return _db.services.FirstOrDefault(x => x.Id == id);
        }

        public void insertServices(Services newservices)
        {
          if(newservices != null)
            {
                _db.services.Add(newservices);
                _db.SaveChanges();
            }
        }

        public void Updateservices(int id, Services newservices)
        {
            var oldser = _db.services.FirstOrDefault(x => x.Id == id);
            if (oldser != null)
            {
                oldser.Name = newservices.Name;
                oldser.Description = newservices.Description;
                _db.services.Update(oldser);
                _db.SaveChanges();
                
            }
        }
    }
}
