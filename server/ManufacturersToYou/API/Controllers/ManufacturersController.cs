using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Manufacturers;
using Microsoft.AspNetCore.Mvc;
using static Application.Manufacturers.List;

namespace API.Controllers
{
    public class ManufacturersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ManufacturersEnvelope>> List(int? limit, int? offset)
        {
            return await Mediator.Send(new List.Query(limit, offset));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerDto>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
    }
}