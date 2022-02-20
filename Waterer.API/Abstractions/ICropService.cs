using Waterer.API.Models;

namespace Waterer.API.Abstractions
{
    public interface ICropService 
    {
        public void AddCropStatus(AddCropStatusRequestModel addCropStatusRequestModel);
        public void AddCrop(AddCropRequestModel cropModel);
        public CropResponseModel GetById(string id);
        public List<CropResponseModel> GetAll();
    }
}
