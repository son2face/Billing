using System;
using System.Web.Http;
using Billing.Entities.Contacts;
using Billing.Interfaces.Contacts;
using Billing.Services.Contacts;

namespace Billing.Controllers
{
    [RoutePrefix("api/v1/contacts")]
    public class ContactsController : System.Web.Http.ApiController
    {
        private ICreateService createService = new CreateService();
        private IDeleteService deleteService = new DeleteService();
        private IUpdateService updateService = new UpdateService();
        private IReadService readService = new ReadService();
      

        [Route("")]
        public IHttpActionResult Get()
        {
            return Json(readService.ReadAllFromDatabase());
        }


        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] ContactEntity contactEntity)
        {
            updateService.UpdateInDatabase(id, contactEntity);
            return Ok();
        }


        [Route("")]
        public IHttpActionResult Post([FromBody] ContactEntity contactEntity)
        {
            createService.CreateInDatabase(contactEntity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            deleteService.DeleteInDatabase(id);
            return Ok();
        }
    }
}