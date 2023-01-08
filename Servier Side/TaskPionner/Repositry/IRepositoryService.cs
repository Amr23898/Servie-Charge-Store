using TaskPionner.Model;

namespace TaskPionner.Repositry
{
    public interface IRepositoryService
    {
        public List<Services> GetallServices();
        public Services getsSrviceById(int id);
        public void insertServices(Services newservices);
        public void Updateservices(int id,Services newservices);
        public void Deleteservices(int id);

    }
}
