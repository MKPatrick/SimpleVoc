using BlazorSimpleVoc.Models;

namespace BlazorSimpleVoc.Services
{
	public interface IVocabularyService
	{
		Task<Vocabulary> AddVocabulary(Vocabulary vocabulary);
		Task DeleteVocabularyByID(int id);
		Task<List<Vocabulary>> GetVocabularies();
		Task<Vocabulary> GetVocabularyByID(int id);
		Task UpdateVocabulary(Vocabulary vocabulary);
	}
}