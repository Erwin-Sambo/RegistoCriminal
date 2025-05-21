using Microsoft.AspNetCore.Mvc;

namespace RegistoCriminal.Controllers
{
    [Route("api/cidadaos/{cidadaoId}/solicitacoesregistos/{solicitacaoId:int}/pagamentos")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
    }
}
