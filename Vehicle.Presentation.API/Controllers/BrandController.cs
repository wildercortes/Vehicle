using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Core.Brand.Add;
using Vehicle.Core.Brand.Delete;
using Vehicle.Core.Brand.Get.GetById;
using Vehicle.Core.Brand.Get.GetIndex;
using Vehicle.Core.Brand.Get.GetIndex.Models;
using Vehicle.Core.Brand.Put;

namespace Vehicle.Presentation.API.Controllers
{
    [Route("v{version:apiVersion}/Brand")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BrandController : BaseController
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [AllowAnonymous]
        [HttpGet("getBrandIndex")]
        public async Task<IList<GetBrandIndexModel>> GetBrandIndex([FromQuery] GetBrandIndexRequest request)
        {
            return await mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpGet("getBrandById")]
        public async Task<GetBrandIndexModel> GetBrandById([FromQuery] GetBrandByIdRequest request)
        {
            return await mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("addBrand")]
        public async Task<ActionResult> AddBrand([FromBody] AddBrandRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [AllowAnonymous]
        [HttpPut("updateBrand")]
        public async Task<ActionResult> UpdateBrand([FromBody] UpdateBrandRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [AllowAnonymous]
        [HttpDelete("deleteBrand")]
        public async Task<ActionResult> DeleteBrand([FromBody] DeleteBrandRequest request)
        {
            return Ok(await mediator.Send(request));
        }

    }
}
