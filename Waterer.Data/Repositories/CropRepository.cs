using Microsoft.EntityFrameworkCore;
using Waterer.Data.Context;
using Waterer.Data.Entities;

namespace Waterer.Data.Repositories
{
    public class CropRepository : ICropRepository
    {

        private readonly CropDbContext _cropDbContext;

        public CropRepository(CropDbContext cropDbContext)
        {
            _cropDbContext = cropDbContext;
        }

        public void Delete(CropEntity cropEntity)
        {
            try
            {
                Delete(cropEntity.Id);
                _cropDbContext.SaveChanges();
            } catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public void Delete(string id)
        {
            _cropDbContext.Remove(id);
            _cropDbContext.SaveChanges();
        }

        public List<CropEntity> GetAll()
        {
            return _cropDbContext.Crops.Include(crop => crop.CropStatuses).ToList();
        }

        public CropEntity? GetById(string id)
        {
            return _cropDbContext.Crops.Include(crop => crop.CropStatuses).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(CropEntity obj)
        {
            _cropDbContext.Add(obj);
            _cropDbContext.SaveChanges();
        }

        public void Save()
        {
            _cropDbContext.SaveChanges();
        }

        public void Update(CropEntity cropEntity)
        {
            var cropModelEntity = _cropDbContext.Crops.Attach(cropEntity);
            cropModelEntity.State = EntityState.Modified;
            _cropDbContext.SaveChanges();
        }
    }
}
