using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Errors;
using ArrearsActionAPI.V1.Usecases;
using ArrearsActionAPI.V1.Validators;
using ArrearsActionAPI.V1.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArrearsActionAPI.V1.Controllers
{
    [Route("api/v1/ArrearsActions")]
    [ApiController]
    public class ArrearsActionsController : ControllerBase
    {
        private readonly IArrearsActionUsecase _arrearsActionUsecase;
        private readonly IFValidator<GetAractionsByPropRefRequest> _getByPropRefValidator;

        public ArrearsActionsController(IArrearsActionUsecase arrearsActionUsecase, IFValidator<GetAractionsByPropRefRequest> getByPropRefValidator)
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
            try
            {
                var validation_result = _getByPropRefValidator.Validate(request);

                if (validation_result.IsValid)
                {
                    var usecase_result = _arrearsActionUsecase.GetByPropRef(request);

                    return Ok(usecase_result);
                }

                return BadRequest(
                        new ErrorResponse(validation_result.Errors)
                        );
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex) when (ex.InnerException != null)
            {
                return StatusCode(500, new ErrorResponse(ex.Message, ex.InnerException.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse(ex.Message));
            }
        }
    }
}