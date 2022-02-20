using Microsoft.AspNetCore.Mvc;
using Waterer.API.Abstractions;
using Waterer.API.Models;

namespace Waterer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CropController : Controller
    {
        private readonly ICropService _cropService;
        
        public CropController(ICropService cropService)
        {
            _cropService = cropService;
        }

        [HttpPost]
        [Route("/Status")]
        public ActionResult CreateCropStatus([FromBody] AddCropStatusRequestModel addCropStatusRequestModel)
        {
            try
            {
                _cropService.AddCropStatus(addCropStatusRequestModel);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Create")]
        public ActionResult CreateCrop([FromBody] AddCropRequestModel addCropRequestModel)
        {
            try
            {
                _cropService.AddCrop(addCropRequestModel);
                return new OkResult();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Get")]
        public ActionResult Get()
        {
            try
            {
                var crops = _cropService.GetAll();
                return new OkObjectResult(crops);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                var crop = _cropService.GetById(id);
                return new OkObjectResult(crop);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
