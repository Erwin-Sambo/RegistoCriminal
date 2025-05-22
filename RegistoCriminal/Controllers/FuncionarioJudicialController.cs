using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistoCriminal.Dtos.Cidadaos;
using RegistoCriminal.Dtos.Funcionarios;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.Servicos;

namespace RegistoCriminal.Controllers
{
    [Route("api/funcionariosjudiciais")]
    [ApiController]
    public class FuncionarioJudicialController : ControllerBase
    {
        private readonly IRepositorioDependente<FuncionarioJudicial, string> _funcionarioJudicialRepositorio;
        private readonly ILogRepositorio _logRopositorio;
        private readonly ILogger<FuncionarioJudicialController> _logger;
        private readonly IMapper _mapper;

        public FuncionarioJudicialController(
            IRepositorioDependente<FuncionarioJudicial, string> funcionarioJudicialRepositorio, 
            ILogger<FuncionarioJudicialController> logger, 
            IMapper mapper, 
            ILogRepositorio logRopositorio)
        {
            _funcionarioJudicialRepositorio = funcionarioJudicialRepositorio ??
                throw new ArgumentNullException(nameof(funcionarioJudicialRepositorio));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _logRopositorio = logRopositorio;
        }

        [HttpGet("all-funcionarios", Name = "GetFuncionariosJudicial")]
        public async Task<ActionResult> GetFuncionariosJudicial([FromQuery]ParametrosPages parametros) 
        {
            var funcionariosFromRepo = await _funcionarioJudicialRepositorio.GetTodosAsync(parametros);
            var funcionarios = _mapper.Map<IEnumerable<FuncionarioJudicialViewModelDto>>(funcionariosFromRepo);
            return Ok(funcionarios);
        }


        [HttpGet("funcionrio", Name = "GetFuncionarioJudicial")]
        public async Task<ActionResult> GetFuncionarioJudicial(int Id)
        {

            //var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            //var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            try
            {
                var funcionarioRepo = await _funcionarioJudicialRepositorio.GetModelByIdAsync(Id);
                if (funcionarioRepo == null)
                    return NotFound($"Funcionario não encontrada");

                return Ok(funcionarioRepo);
            }
            catch (Exception ex)
            {
                //_logRopositorio.AdicionarLog();
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("AdcionarFuncionario")]
        public async Task<ActionResult> AdcionarFuncionario(FuncionarioCreationDto funcionarioDto)
        {
            if (funcionarioDto == null) throw new ArgumentNullException();

            var funcionarioEntity = _mapper.Map<FuncionarioJudicial>(funcionarioDto);
            _funcionarioJudicialRepositorio.Adicionar(funcionarioEntity, funcionarioDto.IdUtilizador);
            await _funcionarioJudicialRepositorio.SaveAsync();


            return NoContent();
        }




        [HttpPut(Name = "UpdateFuncionario")]
        public async Task<ActionResult> UpdateFuncionario(FuncionarioUpdateDto funcionario, int Id)
        {
            try
            {
                if (funcionario == null) throw new ArgumentNullException();
                var funcionarioFromRepo = await _funcionarioJudicialRepositorio.GetModelByIdAsync(Id);
                if (funcionarioFromRepo == null) return NotFound();

                var funcionarioEntityViewmodel = _mapper.Map<FuncionarioJudicial>(funcionarioFromRepo);

                var Funcionario = _mapper.Map(funcionario, funcionarioEntityViewmodel);


                _funcionarioJudicialRepositorio.Actualizar(Funcionario, "");
                await _funcionarioJudicialRepositorio.SaveAsync();

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
