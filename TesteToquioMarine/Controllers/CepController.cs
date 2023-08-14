using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteToquioMarine.Integracao.Interfaces;
using TesteToquioMarine.Integracao.Response;

namespace TesteToquioMarine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }
        [HttpGet]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
            var respondeData = await _viaCepIntegracao.ObterDadosViaCep(cep);

            if (respondeData == null)
            {
                return BadRequest("CEP inválido!");
            }

            if (respondeData.Logradouro == null)
            {
                return Ok("CEP não encontrado!");
            }

            
            return Ok(respondeData);
        }
    }
}
