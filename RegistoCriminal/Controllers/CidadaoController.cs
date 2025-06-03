using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistoCriminal.Dtos.Cidadaos;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.Servicos;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Controllers
{

    [Authorize]
    [Route("api/cidadaos")]
    [ApiController]
    public class CidadaoController : ControllerBase
    {
        private readonly IRepositorioDependente<Cidadao, string> _cidadaoRepositorio;
        private readonly ILogRepositorio _logRopositorio;
        private readonly ILogger<CidadaoController> _logger;
        private readonly IMapper _mapper;

        public CidadaoController(IRepositorioDependente<Cidadao, string> cidadaoRepositorio, ILogger<CidadaoController> logger, IMapper mapper)
        {
            _cidadaoRepositorio = cidadaoRepositorio ??
                throw new ArgumentNullException(nameof(cidadaoRepositorio));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetCidadaos")]
        public async Task<ActionResult> GetCidadaos([FromQuery] ParametrosPages resourceParametersPages)
        {

            var cidadaoRepo = await _cidadaoRepositorio.GetTodosAsync(resourceParametersPages);

            var cidadaosDto = _mapper.Map<IEnumerable<CidadoViewModelDto>>(cidadaoRepo);

            return Ok(cidadaosDto);
        }

        [HttpGet(("{CidadaoId:int}"), Name = "GetCidadao")]
        public async Task<ActionResult> GetCidadao(int CidadaoId)
        {

            //var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            //var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            try
            {
                var cidadaoRepo = await _cidadaoRepositorio.GetModelByIdAsync(CidadaoId);
                if (cidadaoRepo == null)
                    return NotFound($"Cidadao não encontrada");

                return Ok(cidadaoRepo);
            }
            catch (Exception ex)
            {
                //_logRopositorio.AdicionarLog();
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AdcionarCidadao")]
        public async Task<IActionResult> AdcionarCidadao(CidadaoCreationDto cidadaoDto)
        {
            if (cidadaoDto == null) throw new ArgumentNullException();

            var cidadaoEntity = _mapper.Map<Cidadao>(cidadaoDto);
            _cidadaoRepositorio.Adicionar(cidadaoEntity, cidadaoDto.IdUtilizador);
            await _cidadaoRepositorio.SaveAsync();

            var cidadaoToReturn = _mapper.Map<CidadaoDto>(cidadaoEntity);


            return CreatedAtRoute("GetCidadao", cidadaoEntity.Id);
        }

        [HttpPut(Name = "UpdateCidadao")]
        public async Task<IActionResult> UpdateCidadao(UpdateCidadoDto cidadao, int Id)
        {
            try
            {
                var cidadaoFromRepo = await _cidadaoRepositorio.GetModelByIdAsync(Id);
                if (cidadaoFromRepo == null) return NotFound();

                var cidadaoEntityViewmodel = _mapper.Map<Cidadao>(cidadaoFromRepo);

                var Cidadao = _mapper.Map(cidadao, cidadaoEntityViewmodel);


                _cidadaoRepositorio.Actualizar(Cidadao, "");
                await _cidadaoRepositorio.SaveAsync();

                return NoContent();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!await _cidadaoRepositorio.ModelExistsAsync(idadaoEntity.IdUtilizador))
            //        return NotFound();
            //    else return Conflict();
            //}
        }
    }
}
