using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Manufacturers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ManufacturersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<ManufacturerDto>>> List()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}