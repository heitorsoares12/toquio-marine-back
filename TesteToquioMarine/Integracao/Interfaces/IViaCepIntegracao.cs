using TesteToquioMarine.Integracao.Response;

namespace TesteToquioMarine.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
