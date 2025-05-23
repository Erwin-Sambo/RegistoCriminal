using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistoCriminal.Dtos.Solicitacoes;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.Servicos;

namespace RegistoCriminal.Controllers
{
    [Authorize]
    [Route("api/cidadaos/{cidadaoId:int}/solicitacoesregistos")]
    [ApiController]
    public class SolicitacaoRegistoController : ControllerBase
    {
        private readonly IRepositorioDependente<Solicitacaoregisto, int> _solicitacaoRegistoRepositorio;
        private readonly ILogRepositorio _logRopositorio;
        private readonly ILogger<SolicitacaoRegistoController> _logger;
        private readonly IMapper _mapper;

        public SolicitacaoRegistoController(
            IRepositorioDependente<Solicitacaoregisto, int> registosCriminalRepositorio,
            ILogger<SolicitacaoRegistoController> logger,
            IMapper mapper,
            ILogRepositorio logRopositorio)
        {
            _solicitacaoRegistoRepositorio = registosCriminalRepositorio ??
                throw new ArgumentNullException(nameof(registosCriminalRepositorio));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _logRopositorio = logRopositorio;
        }

        [HttpGet("all-solicitacaoRegistos", Name = "GetsolicitacaoRegistosJudicial")]
        public async Task<ActionResult> GetsolicitacaoRegistosJudicial([FromQuery] ParametrosPages parametros)
        {
            var solicitacoesRegistosFromRepo = await _solicitacaoRegistoRepositorio.GetTodosNormalAsync(parametros);
            //var solicitacoesRegistosFromRepo = await _solicitacaoRegistoRepositorio.GetTodosAsync(parametros);
            //var solicitacoesRegistos = _mapper.Map<IEnumerable<SolicitacaoregistoViewModelDto>>(solicitacoesRegistosFromRepo);
            //return Ok(solicitacoesRegistos);

            return Ok(solicitacoesRegistosFromRepo);
        }


        [HttpGet("solicitacaoRegisto", Name = "GesolicitacaoRegistosJudicial")]
        public async Task<ActionResult> GetsolicitacaoRegistosJudicial(int Id)
        {
            try
            {
                var solicitacaoRegistoRepo = await _solicitacaoRegistoRepositorio.GetModelByIdAsync(Id);
                if (solicitacaoRegistoRepo == null)
                    return NotFound($"solicitacaoRegisto não encontrada");

                var solicitacaoRegisto = _mapper.Map<SolicitacaoregistoViewModelDto>(solicitacaoRegistoRepo);

                return Ok(solicitacaoRegisto);
            }
            catch (Exception ex)
            {
                //_logRopositorio.AdicionarLog();
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AdicionarSolicitacao")]
        public async Task<ActionResult> AdicionarSolicitacao(SolicitacaoRegistoCreationDto solicitacaoCreationDto)
        {
            if(solicitacaoCreationDto == null)throw new ArgumentNullException();

            var solicitacao = _mapper.Map<Solicitacaoregisto>(solicitacaoCreationDto);
            _solicitacaoRegistoRepositorio.Adicionar(solicitacao, 5);
            await _solicitacaoRegistoRepositorio.SaveAsync();

            return NoContent();
        }

        [HttpPut(Name = "UpdatesolicitacaoRegisto")]
        public async Task<ActionResult> UpdatesolicitacaoRegisto(SolicitacaoRegistoUpdateDto SolicitacaoRegisto, int Id)
        {
            try
            {
                if (SolicitacaoRegisto == null) throw new ArgumentNullException();
                var solicitacaoRegistoFromRepo = await _solicitacaoRegistoRepositorio.GetModelByIdAsync(Id);
                if (solicitacaoRegistoFromRepo == null) return NotFound();

                var solicitacaoRegistoEntityViewmodel = _mapper.Map<Solicitacaoregisto>(solicitacaoRegistoFromRepo);

                var solicitacaoRegisto = _mapper.Map(SolicitacaoRegisto, solicitacaoRegistoEntityViewmodel);

                _solicitacaoRegistoRepositorio.Actualizar(solicitacaoRegisto, 0);
                await _solicitacaoRegistoRepositorio.SaveAsync();

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


        [HttpDelete(Name = "DeleteSolicitacao")]
        public async Task<ActionResult> DeleteSolicitacao(int Id)
        {
            try
            {
                var solicitacaoFromRepo = await _solicitacaoRegistoRepositorio.GetModelByIdAsync(Id);
                if (solicitacaoFromRepo == null) return NotFound();


                var solicitacaoRegisto = _mapper.Map<Solicitacaoregisto>(solicitacaoFromRepo);

                _solicitacaoRegistoRepositorio.Remover(solicitacaoRegisto, 55);

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
