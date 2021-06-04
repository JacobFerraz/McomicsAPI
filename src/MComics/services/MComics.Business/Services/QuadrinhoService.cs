using MComics.Business.Adapter.Interfaces;
using MComics.Business.Models;
using MComics.Business.ResponseModels;
using MComics.Business.Services.Interfaces;
using MComics.Core.Integration;
using MComics.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Services
{
    public class QuadrinhoService : IQuadrinhoService
    {
        private readonly IIntegrationModel _integrationModel;
        private readonly HttpClient _httpClient;
        private readonly IQuadrinhoAdapter _quadrinhoAdapter;
        private readonly IIntegrationKey _integrationKey;
        private readonly string currentDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        public QuadrinhoService(IIntegrationModel integrationModel, HttpClient httpClient, IQuadrinhoAdapter quadrinhoAdapter,
            IIntegrationKey integrationKey)
        {
            _integrationModel = integrationModel;
            _httpClient = httpClient;
            _quadrinhoAdapter = quadrinhoAdapter;
            _integrationKey = integrationKey;
        }

        public async Task<Quadrinho> BuscarEntidade(FilterBase parameter)
        {
            StringBuilder requestUrl = new();
            requestUrl.Append($"{_integrationModel.RequestUrl}/comics/{parameter.Id}?&");
            requestUrl.Append($"&ts={currentDate}&apikey={_integrationKey.PublicKey}");
            requestUrl.Append($"&hash={IntegrationService.GerarHashCode(currentDate, _integrationKey.PrivateKey, _integrationKey.PublicKey)}");

            var response = await _httpClient.GetFromJsonAsync<RootResponseQuadrinho>(requestUrl.ToString());
            return _quadrinhoAdapter.CreateEntity(response.data.results.First());
        }

        public async Task<IEnumerable<Quadrinho>> BuscarLista(FilterBase parameter)
        {
            StringBuilder requestUrl = new();
            requestUrl.Append($"{_integrationModel.RequestUrl}/comics?");

            if (!string.IsNullOrEmpty(parameter.Nome)) requestUrl.Append($"titleStartsWith={parameter.Nome}&");

            requestUrl.Append($"orderBy=-modified&limit={parameter.QuantidadePorPagina}&offset={parameter.Pagina}&ts={currentDate}&apikey={_integrationKey.PublicKey}");
            requestUrl.Append($"&hash={IntegrationService.GerarHashCode(currentDate, _integrationKey.PrivateKey, _integrationKey.PublicKey)}");

            var response = await _httpClient.GetFromJsonAsync<RootResponseQuadrinho>
                (requestUrl.ToString());

            var result = new List<Quadrinho>();
            foreach (var quadrinho in response.data.results)
            {
               result.Add(_quadrinhoAdapter.CreateEntity(quadrinho));
            }

            return result;
        }

        public void Dispose()
        {
            this._httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
