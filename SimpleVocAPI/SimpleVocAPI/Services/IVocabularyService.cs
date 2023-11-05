using SimpleVocAPI.DTO.Vocabulary;

namespace SimpleVocAPI.Services
{
    public interface IVocabularyService
    {
        Task<AddVocabularyResponse> Add(AddVocabularyRequest addVocabularyRequest);
        Task Delete(int VocabularyID);
        Task<IEnumerable<GetVocabularyResponse>> GetAll();
        Task<GetVocabularyResponse> GetByID(int ID);
        Task UpdateVocabulary(UpdateVocabularyRequest updateVocabularyRequest, int VocabularyID);
    }
}