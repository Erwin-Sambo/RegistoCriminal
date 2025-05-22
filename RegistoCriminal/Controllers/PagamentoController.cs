using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistoCriminal.Dtos.Pagamentos;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.Servicos;

namespace RegistoCriminal.Controllers
{
    [Route("api/cidadaos/{cidadaoId}/solicitacoesregistos/{solicitacaoId:int}/pagamentos")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IRepositorioDependente<Pagamento,int> _PagamentoRepositorio;
        private readonly ILogRepositorio _logRopositorio;
        private readonly ILogger<PagamentoController> _logger;
        private readonly IMapper _mapper;

        public PagamentoController(
            IRepositorioDependente<Pagamento, int> PagamentoRepositorio,
            ILogger<PagamentoController> logger,
            IMapper mapper,
            ILogRepositorio logRopositorio)
        {
            _PagamentoRepositorio = PagamentoRepositorio ??
                throw new ArgumentNullException(nameof(PagamentoRepositorio));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _logRopositorio = logRopositorio;
        }

        [HttpGet("all-Pagamentos", Name = "GetPagamentosJudicial")]
        public async Task<ActionResult> GetPagamentosJudicial([FromQuery] ParametrosPages parametros)
        {
            var PagamentosFromRepo = await _PagamentoRepositorio.GetTodosNormalAsync(parametros);
            //var Pagamentos = _mapper.Map<IEnumerable<PagamentoViewModelDto>>(PagamentosFromRepo);
            return Ok(PagamentosFromRepo);
        }


        [HttpGet("funcionrio", Name = "GetPagamento")]
        public async Task<ActionResult> GetPagamento(int Id)
        {

            //var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            //var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            try
            {
                var PagamentoRepo = await _PagamentoRepositorio.GetModelByIdAsync(Id);
                if (PagamentoRepo == null)
                    return NotFound($"Pagamento não encontrada");

                return Ok(PagamentoRepo);
            }
            catch (Exception ex)
            {
                //_logRopositorio.AdicionarLog();
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("AdcionarPagamento")]
        public async Task<ActionResult> AdcionarPagamento(PagamentoCreationDto PagamentoDto)
        {
            if (PagamentoDto == null) throw new ArgumentNullException();

            var PagamentoEntity = _mapper.Map<Pagamento>(PagamentoDto);
            _PagamentoRepositorio.Adicionar(PagamentoEntity, 99);
            await _PagamentoRepositorio.SaveAsync();


            return NoContent();
        }




        [HttpPut(Name = "UpdatePagamento")]
        public async Task<ActionResult> UpdatePagamento(PagamentoUpdateDto Pagamentos, int Id)
        {
            try
            {

                if (Pagamentos == null) throw new ArgumentNullException();
                var PagamentoFromRepo = await _PagamentoRepositorio.GetModelByIdAsync(Id);
                if (PagamentoFromRepo == null) return NotFound();

                var PagamentoEntityViewmodel = _mapper.Map<Pagamento>(PagamentoFromRepo);

                var Pagamento = _mapper.Map(Pagamentos, PagamentoEntityViewmodel);


                _PagamentoRepositorio.Actualizar(Pagamento, 99);
                await _PagamentoRepositorio.SaveAsync();

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
