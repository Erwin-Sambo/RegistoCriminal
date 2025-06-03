using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistoCriminal.Dtos.RegistoCriminal;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.Servicos;

namespace RegistoCriminal.Controllers
{
    [Authorize]
    [Route("api/cidadaos/{cidadaoId:int}/registosCriminais")]
    [ApiController]
    public class RegistoCriminalController : ControllerBase
    {

        private readonly IRepositorioDependente<RegistosCriminal, int> _registosCriminalRepositorio;
        private readonly ILogRepositorio _logRopositorio;
        private readonly ILogger<RegistoCriminalController> _logger;
        private readonly IMapper _mapper;

        public RegistoCriminalController(
            IRepositorioDependente<RegistosCriminal, int> registosCriminalRepositorio,
            ILogger<RegistoCriminalController> logger,
            IMapper mapper,
            ILogRepositorio logRopositorio)
        {
            _registosCriminalRepositorio = registosCriminalRepositorio ??
                throw new ArgumentNullException(nameof(registosCriminalRepositorio));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _logRopositorio = logRopositorio;
        }

        [HttpGet(Name = "GetregistoCriminalsJudicial")]
        public async Task<ActionResult> GetregistoCriminalsJudicial([FromQuery] ParametrosPages parametros)
        {
            var registoCriminalsFromRepo = await _registosCriminalRepositorio.GetTodosAsync(parametros);
            var registoCriminals = _mapper.Map<IEnumerable<RegistoCriminalViewModelDto>>(registoCriminalsFromRepo);
            return Ok(registoCriminals);
        }


        [HttpGet("{registoCriminalID:int}", Name = "GetregistosCriminal")]
        public async Task<ActionResult> GetregistosCriminal(int registoCriminalID)
        {

            //var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            //var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            try
            {
                var registoCriminalRepo = await _registosCriminalRepositorio.GetModelByIdAsync(registoCriminalID);
                if (registoCriminalRepo == null)
                    return NotFound($"registoCriminal não encontrada");

                var registoCriminals = _mapper.Map<RegistoCriminalViewModelDto>(registoCriminalRepo);

                return Ok(registoCriminals);
            }
            catch (Exception ex)
            {
                //_logRopositorio.AdicionarLog();
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost(Name = "AdcionarregistoCriminal")]
        public async Task<IActionResult> AdcionarregistoCriminal(RegistoCriminalCreationDto registoCriminalDto)
        {
            if (registoCriminalDto == null) throw new ArgumentNullException();

            var registoCriminalEntity = _mapper.Map<RegistosCriminal>(registoCriminalDto);
            _registosCriminalRepositorio.Adicionar(registoCriminalEntity, 5);
            await _registosCriminalRepositorio.SaveAsync();


            return NoContent();
        }

        [HttpPut(Name = "UpdateregistoCriminal")]
        public async Task<IActionResult> UpdateregistoCriminal(RegistoCriminalUpdateDto RegistoCriminal, int Id)
        {
            try
            {
                //if (registoCriminal == null) throw new ArgumentNullException();
                if(RegistoCriminal == null) throw new ArgumentNullException();
                var registoCriminalFromRepo = await _registosCriminalRepositorio.GetModelByIdAsync(Id);
                if (registoCriminalFromRepo == null) return NotFound();

                var registoCriminalEntityViewmodel = _mapper.Map<RegistosCriminal>(registoCriminalFromRepo);

                var registoCriminal = _mapper.Map(RegistoCriminal, registoCriminalEntityViewmodel);

                _registosCriminalRepositorio.Actualizar(registoCriminal, 0);
                await _registosCriminalRepositorio.SaveAsync();

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


        [HttpDelete(Name = "DeleteRegistoCriminal")]
        public async Task<IActionResult> DeleteRegistoCriminal(int Id)
        {
            try
            {
                var registoCriminalFromRepo = await _registosCriminalRepositorio.GetModelByIdAsync(Id);
                if (registoCriminalFromRepo == null) return NotFound();


                var registoCriminal = _mapper.Map<RegistosCriminal>(registoCriminalFromRepo);

                _registosCriminalRepositorio.Remover(registoCriminal, 55);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
