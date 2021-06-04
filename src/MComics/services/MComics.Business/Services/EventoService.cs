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
    public class EventoService : IEventoService
    {
        private readonly IIntegrationModel _integrationModel;
        private readonly HttpClient _httpClient;
        private readonly IEventoAdapter _eventoAdapter;
        private readonly IIntegrationKey _integrationKey;
        private readonly string currentDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

        public EventoService(IIntegrationModel integrationModel, HttpClient httpClient, IEventoAdapter eventoAdapter,
            IIntegrationKey integrationKey)
        {
            _integrationModel = integrationModel;
            _httpClient = httpClient;
            _eventoAdapter = eventoAdapter;
            _integrationKey = integrationKey;
        }

        public async Task<Evento> BuscarEntidade(FilterBase parameter)
        {
            StringBuilder requestUrl = new();
            requestUrl.Append($"{_integrationModel.RequestUrl}/events/{parameter.Id}?&");
            requestUrl.Append($"&ts={currentDate}&apikey={_integrationKey.PublicKey}");
            requestUrl.Append($"&hash={IntegrationService.GerarHashCode(currentDate, _integrationKey.PrivateKey, _integrationKey.PublicKey)}");

            var response = await _httpClient.GetFromJsonAsync<RootResponseEvento>(requestUrl.ToString());
            return _eventoAdapter.CreateEntity(response.data.results.First());
        }

        public async Task<IEnumerable<Evento>> BuscarLista(FilterBase parameter)
        {
            StringBuilder requestUrl = new();
            requestUrl.Append($"{_integrationModel.RequestUrl}/events?");

            if (!string.IsNullOrEmpty(parameter.Nome)) requestUrl.Append($"nameStartsWith={parameter.Nome}&");

            requestUrl.Append($"orderBy=-modified&limit={parameter.QuantidadePorPagina}&offset={parameter.Pagina}&ts={currentDate}&apikey={_integrationKey.PublicKey}");
            requestUrl.Append($"&hash={IntegrationService.GerarHashCode(currentDate, _integrationKey.PrivateKey, _integrationKey.PublicKey)}");

            var response = await _httpClient.GetFromJsonAsync<RootResponseEvento>(requestUrl.ToString());

            var result = new List<Evento>();
            foreach (var evento in response.data.results)
            {
                result.Add(_eventoAdapter.CreateEntity(evento));
            }

            return result;
        }

        public void Dispose()
        {
            this._httpClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
