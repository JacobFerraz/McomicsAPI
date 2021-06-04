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
    public class PersonagemService : IPersonagemService
    {
        private readonly IIntegrationModel _integrationModel;
        private readonly HttpClient _httpClient;
        private readonly IPersonagemAdapter _personagemAdapter;
        private readonly IIntegrationKey _integrationKey;
        private readonly string currentDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        private const string defautUrl = "image_not_available";
        public PersonagemService(IIntegrationModel integrationModel, HttpClient httpClient, IPersonagemAdapter personagemAdapter,
            IIntegrationKey integrationKey)
        {
            _integrationModel = integrationModel;
            _httpClient = httpClient;
            _personagemAdapter = personagemAdapter;
            _integrationKey = integrationKey;
        }

        public async Task<Personagem> BuscarEntidade(FilterBase parameter)
        {
            StringBuilder requestUrl = new();
            requestUrl.Append($"{_integrationModel.RequestUrl}/characters/{parameter.Id}?&");
            requestUrl.Append($"&ts={currentDate}&apikey={_integrationKey.PublicKey}");
            requestUrl.Append($"&hash={IntegrationService.GerarHashCode(currentDate, _integrationKey.PrivateKey, _integrationKey.PublicKey)}");

            var response = await _httpClient.GetFromJsonAsync<RootResponsePersonagem>(requestUrl.ToString());
            return _personagemAdapter.CreateEntity(response.data.results.First());
        }

        public async Task<IEnumerable<Personagem>> BuscarLista(FilterBase parameter)
        {
            StringBuilder requestUrl = new();
            requestUrl.Append($"{_integrationModel.RequestUrl}/characters?");

            if(!string.IsNullOrEmpty(parameter.Nome)) requestUrl.Append($"nameStartsWith={parameter.Nome}&");

            requestUrl.Append($"orderBy=-modified&limit={parameter.QuantidadePorPagina}&offset={parameter.Pagina}&ts={currentDate}&apikey={_integrationKey.PublicKey}");
            requestUrl.Append($"&hash={IntegrationService.GerarHashCode(currentDate, _integrationKey.PrivateKey, _integrationKey.PublicKey)}");

            var response = await _httpClient.GetFromJsonAsync<RootResponsePersonagem>
                (requestUrl.ToString());

            var result = new List<Personagem>();

            foreach (var personagem in response.data.results.Where(x => !x.thumbnail.path.Contains(defautUrl)))
            {
                result.Add(_personagemAdapter.CreateEntity(personagem));
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
