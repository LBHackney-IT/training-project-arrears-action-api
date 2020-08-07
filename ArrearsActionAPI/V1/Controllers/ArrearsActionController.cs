using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Usecases;
using ArrearsActionAPI.V1.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArrearsActionAPI.V1.Controllers
{
    [Route("api/v1/ArrearsActions")]
    [ApiController]
    public class ArrearsActionsController : ControllerBase
    {
        private readonly IArrearsActionUsecase _arrearsActionUsecase;
        private readonly IGetAractionsByPropRefRequestValidator _getByPropRefValidator;

        public ArrearsActionsController(IArrearsActionUsecase arrearsActionUsecase, IGetAractionsByPropRefRequestValidator getByPropRefValidator)
        {
            _arrearsActionUsecase = arrearsActionUsecase;
            _getByPropRefValidator = getByPropRefValidator;
        }

        [HttpGet]
        [Route("Hello/Name/{name}")]
        public IActionResult HelloSomeone([FromRoute] string name)
        {
            return Ok($"It's working?! Uhm... Hello, {name}!");
        }

        [HttpGet]
        [Route("property-ref/{PropertyRef}")]
        public IActionResult GetAractionsByPropRef([FromRoute] GetAractionsByPropRefRequest request)
        {
            _getByPropRefValidator.Validate(request);

            var usecase_result = _arrearsActionUsecase.GetByPropRef(request);

            return Ok(usecase_result);
        }
    }
}