using System.Web.Http;
using Billing.Interfaces.ChargeLevels;
using Billing.Models;
using Billing.Services.ChargeLevels;

namespace Billing.Controllers.ApiController
{
    [RoutePrefix("api/v1/chargelevels")]

    public class ChargeLevelsController : System.Web.Http.ApiController
    {
        private readonly ICreateService createService;

        private readonly IDeleteService deleteService;

        private readonly IReadService readService;

        private readonly IUpdateService updateService;


        public ChargeLevelsController()
        {
            readService = new ReadService();
            updateService = new UpdateService();
            createService = new CreateService();
            deleteService = new DeleteService();
        }


        [Route("")]
        public IHttpActionResult Get([FromUri] string sort)
        {

            var chargeLevelsList = readService.ReadAllFromDatabase(sort);

            return Json(chargeLevelsList);
        }

        [Route("{level}")]
        public IHttpActionResult Get([FromUri] int level)
        {

            return Json(readService.ReadFromDatabase(level));
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] ChargeLevel chargeLevel)
        {
            createService.CreateInDatabase(chargeLevel);

            return Ok();
        }

        [Route("{level}")]
        public IHttpActionResult Put([FromUri] int level, [FromBody] ChargeLevel chargeLevel)
        {
            updateService.UpdateInDatabase(level, chargeLevel);

            return Ok();
        }

        [Route("{level}")]
        public IHttpActionResult Delete([FromUri] int level)
        {
            deleteService.DeleteFromDatabase(level);
            return Ok();
        }
    }
}