using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int id);
        void Add(Color brand);
        void Update(Color brand);
        void Delete(Color brand);
    }
}