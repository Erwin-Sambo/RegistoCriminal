using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistoCriminal.Dtos.Certificado;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.Servicos;

namespace RegistoCriminal.Controllers
{

    [Route("api/certificados")]
    [ApiController]
    public class CertificadoController : ControllerBase
    {

        private readonly IRepositorioDependente<CertificadoRegisto, int> certificadoRepositorio;
        private readonly ILogRepositorio _logRopositorio;
        private readonly ILogger<CertificadoController> _logger;
        private readonly IMapper _mapper;

        public CertificadoController(
            IRepositorioDependente<CertificadoRegisto, int> certifacadoRepositorio,
            ILogger<CertificadoController> logger,
            IMapper mapper,
            ILogRepositorio logRopositorio)
        {
            certificadoRepositorio = certifacadoRepositorio ??
                throw new ArgumentNullException(nameof(certifacadoRepositorio));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _logRopositorio = logRopositorio;
        }

        [HttpGet("all-certificados", Name = "GetCertificados")]
        public async Task<ActionResult> GetCertificados([FromQuery] ParametrosPages parametros)
        {
            var CertificadosFromRepo = await certificadoRepositorio.GetTodosAsync(parametros);
            var Certificados = _mapper.Map<IEnumerable<CertidicadoRegistoViewModelDto>>(CertificadosFromRepo);
            return Ok(Certificados);
        }


        [HttpGet("Certificado", Name = "GetCertificado")]
        public async Task<ActionResult> GetCertificado(int Id)
        {

            //var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            //var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            try
            {
                var CertificadoRepo = await certificadoRepositorio.GetModelByIdAsync(Id);
                if (CertificadoRepo == null)
                    return NotFound($"Certificado não encontrada");

                var Certificados = _mapper.Map<CertificadoRegisto>(CertificadoRepo);

                return Ok(Certificados);
            }
            catch (Exception ex)
            {
                //_logRopositorio.AdicionarLog();
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost(Name = "AdcionarCertificado")]
        public async Task<ActionResult> AdcionarCertificado(CertidicadoRegistoCreationDto CertificadoDto)
        {
            if (CertificadoDto == null) throw new ArgumentNullException();

            var CertificadoEntity = _mapper.Map<CertificadoRegisto>(CertificadoDto);
            certificadoRepositorio.Adicionar(CertificadoEntity, 5);
            await certificadoRepositorio.SaveAsync();


            return NoContent();
        }

        [HttpPut(Name = "UpdateCertificado")]
        public async Task<ActionResult> UpdateCertificado(CertidicadoRegistoUpdateDto Certificado, int Id)
        {
            try
            {
                //if (Certificado == null) throw new ArgumentNullException();
                if (Certificado == null) throw new ArgumentNullException();
                var CertificadoFromRepo = await certificadoRepositorio.GetModelByIdAsync(Id);
                if (CertificadoFromRepo == null) return NotFound();

                var CertificadoEntityViewmodel = _mapper.Map<CertificadoRegisto>(CertificadoFromRepo);

                var certificado = _mapper.Map(Certificado, CertificadoEntityViewmodel);

                certificadoRepositorio.Actualizar(certificado, 0);
                await certificadoRepositorio.SaveAsync();

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


        [HttpDelete(Name = "DeleteCertificado")]
        public async Task<ActionResult> DeleteCertificado(int Id)
        {
            try
            {
                var CertificadoFromRepo = await certificadoRepositorio.GetModelByIdAsync(Id);
                if (CertificadoFromRepo == null) return NotFound();


                var Certificado = _mapper.Map<CertificadoRegisto>(CertificadoFromRepo);

                certificadoRepositorio.Remover(Certificado, 55);

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
