using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using net_perfService.DataObjects;
using net_perfService.Models;

namespace net_perfService.Controllers
{
    public class CRUDController : TableController<CRUD>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            net_perfContext context = new net_perfContext();
            DomainManager = new EntityDomainManager<CRUD>(context, Request);
        }

        // GET tables/CRUD
        public IQueryable<CRUD> GetAllCRUDs()
        {
            return Query();
        }

        // GET tables/CRUD/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CRUD> GetCRUD(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CRUD/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CRUD> PatchCRUD(string id, Delta<CRUD> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/CRUD
        public async Task<IHttpActionResult> PostCRUD(CRUD item)
        {
            CRUD current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CRUD/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCRUD(string id)
        {
            return DeleteAsync(id);
        }
    }
}