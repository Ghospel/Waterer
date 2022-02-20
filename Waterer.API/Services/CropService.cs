using Waterer.API.Abstractions;
using Waterer.API.Models;
using Waterer.Data.Entities;
using Waterer.Data.Repositories;

namespace Waterer.API.Services
{
    public class CropService : ICropService
    {
        private readonly ICropRepository _cropRepository;
        public CropService(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }
        public void AddCropStatus(AddCropStatusRequestModel addCropStatusRequestModel)
        {
            try
            {
                CropEntity cropEntity = _cropRepository.GetById(addCropStatusRequestModel.CropId);
                if (cropEntity.CropStatuses == null)
                {
                    cropEntity.CropStatuses = new List<CropStatusEntity>();
                }
                var cropStatusEntiy = new CropStatusEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    CropEntity = cropEntity,
                    Lux = addCropStatusRequestModel.Lux,
                    RelativeHumidity = addCropStatusRequestModel.RelativeHumidity,
                    SoilMoisture = addCropStatusRequestModel.SoilMoisture,
                    Temperature = addCropStatusRequestModel.Temperature,
                };

                cropEntity.CropStatuses.Add(cropStatusEntiy);
                _cropRepository.Update(cropEntity);
                _cropRepository.Save();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void AddCrop(AddCropRequestModel cropModel)
        { 
            _cropRepository.Insert(new CropEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                Name = cropModel.Name,
            });

            _cropRepository.Save();
        }

        public List<CropResponseModel> GetAll()
        {
            var crops = _cropRepository.GetAll();
            List<CropResponseModel> response = new();
            if (crops.Any())
            {
                foreach (var crop in crops)
                {
                    List<CropStatusResponseModel> cropStatuses = MapCropStatuses(crop);

                    response.Add(new CropResponseModel
                    {
                        CreatedDate = crop.CreatedDate,
                        Id = crop.Id,
                        Name = crop.Name,
                        CropStatuses = cropStatuses,
                    });
                }
            }
            
            return response;
        }

        public CropResponseModel GetById(string id)
        {
            var response = _cropRepository.GetById(id);
            List<CropStatusResponseModel> cropStatuses = MapCropStatuses(response);

            return new CropResponseModel
            {
                Id = response.Id,
                CreatedDate = response.CreatedDate, 
                Name = response.Name,
                CropStatuses = cropStatuses,
            };
        }

        private static List<CropStatusResponseModel> MapCropStatuses(CropEntity crop)
        {
            List<CropStatusResponseModel> cropStatuses = new();
            if (crop.CropStatuses == null) return cropStatuses;
            if (crop.CropStatuses.Any())
            {
                foreach (var cropStatus in crop.CropStatuses)
                {
                    cropStatuses.Add(new CropStatusResponseModel
                    {
                        CreatedDate = cropStatus.CreatedDate,
                        Lux = cropStatus.Lux,
                        RelativeHumidity = cropStatus.RelativeHumidity,
                        SoilMoisture = cropStatus.SoilMoisture,
                        Temperature = cropStatus.Temperature,
                    });
                }
            }

            return cropStatuses;
        }
    }
}
