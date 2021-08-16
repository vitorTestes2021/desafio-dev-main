using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Repository;
using System.Threading.Tasks;
using System;
using System.Net;
using api.Readers;
using api.Validators;
using System.Collections.Generic;
using api.Model;
using Microsoft.Extensions.Configuration;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CNABController : ControllerBase
    {
        #region Properties

        private readonly ILogger<CNABController> _logger;
        private readonly ICNABRepository _cnabRepository;
        private readonly CNABReader _cnabReader;
        private readonly FormValidator _formValidator;

        #endregion

        #region Constructor

        public CNABController(
            IConfiguration configuration,
            ILogger<CNABController> logger,
            ICNABRepository CNABRepository)
        {
            _logger = logger;
            _cnabRepository = CNABRepository;
            _cnabReader = new CNABReader(configuration.GetValue<int>("Config:CnabLength"));
            _formValidator = new FormValidator();
        }

        #endregion

        #region Endpoints

        [HttpGet]
        [Produces(typeof(List<CNABModel>))]
        public IActionResult Get()
        {
            var cnabs = _cnabRepository.GetAll();
            return Ok(cnabs);
        }

        [HttpPost]
        [Produces(typeof(void))]
        public async Task<IActionResult> Post()
        {
            try
            {
                var section = await _formValidator.Validate(Request);
                var cnabList = await _cnabReader.ConvertFileToCNABList(section.Body);
                await _cnabRepository.SaveAll(cnabList);
                return Ok();
            } catch(Exception ex) {
                _logger.LogError($"Exception: {ex}");
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
    }
}
