using BlazorSimpleVoc.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BlazorSimpleVoc.Services
{
	public class VocabularyService : IVocabularyService
	{
		private readonly HttpClient httpClient;
		private const string SUBBASEADDRESS = "Vocabulary";
		public VocabularyService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<Vocabulary> GetVocabularyByID(int id)
		{
			return await httpClient.GetFromJsonAsync<Vocabulary>($"{SUBBASEADDRESS}/{id}");
		}

		public async Task<List<Vocabulary>> GetVocabularies()
		{
			return await httpClient.GetFromJsonAsync<List<Vocabulary>>($"{SUBBASEADDRESS}");
		}

		public async Task<Vocabulary> AddVocabulary(Vocabulary vocabulary)
		{
			var result = await httpClient.PostAsJsonAsync<Vocabulary>($"{SUBBASEADDRESS}", vocabulary);
			if (result.IsSuccessStatusCode)
			{
				return JsonConvert.DeserializeObject<Vocabulary>(await result.Content.ReadAsStringAsync());
			}
			else
			{
				throw new Exception($"Error by Adding Vocabulary!  {await result.Content.ReadAsStringAsync()}");
			}
		}

		public async Task UpdateVocabulary(Vocabulary vocabulary)
		{
			var result = await httpClient.PutAsJsonAsync<Vocabulary>($"{SUBBASEADDRESS}/{vocabulary.ID}", vocabulary);
			if (!result.IsSuccessStatusCode)
			{
				var exception = await result.Content.ReadAsStringAsync();
				throw new Exception($"{result.StatusCode} Error by Updating Vocabulary!  {exception}");

			}
		}

		public async Task DeleteVocabularyByID(int id)
		{
			var result = await httpClient.DeleteAsync($"{SUBBASEADDRESS}/{id}");
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception($"Error by Deleting Vocabulary!  {await result.Content.ReadAsStringAsync()}");
			}

		}
	}
}
