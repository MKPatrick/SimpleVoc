using AutoMapper;
using SimpleVoc.Domain.Entities;
using SimpleVoc.Domain.Shared.Kernel;
using SimpleVocAPI.DTO.Vocabulary;

namespace SimpleVocAPI.Services
{
    public class VocabularyService : IVocabularyService
    {
        private readonly IVocabularyRepository vocabularyRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VocabularyService(IVocabularyRepository vocabularyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.vocabularyRepository = vocabularyRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AddVocabularyResponse> Add(AddVocabularyRequest addVocabularyRequest)
        {
            var vocEntity = mapper.Map<Vocabulary>(addVocabularyRequest);
            var vocEntityAdded = await vocabularyRepository.AddAsync(vocEntity);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<AddVocabularyResponse>(vocEntityAdded);
        }

        public async Task<IEnumerable<GetVocabularyResponse>> GetAll()
        {
            var allVocEntities = await vocabularyRepository.GetAllAsync();
            return allVocEntities.Select(x => mapper.Map<GetVocabularyResponse>(x)).ToList();
        }

        public async Task<GetVocabularyResponse> GetByID(int ID)
        {
            var vocEntity = await vocabularyRepository.GetByIdAsync(ID);
            return mapper.Map<GetVocabularyResponse>(vocEntity);
        }

        public async Task UpdateVocabulary(UpdateVocabularyRequest updateVocabularyRequest, int VocabularyID)
        {
            var vocEntity = await vocabularyRepository.GetByIdAsync(VocabularyID);
            vocEntity.Translation = updateVocabularyRequest.Translation;
            vocEntity.Original = updateVocabularyRequest.Original;
            await vocabularyRepository.UpdateAsync(vocEntity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int VocabularyID)
        {
            await vocabularyRepository.DeleteAsync(VocabularyID);
            await unitOfWork.SaveChangesAsync();
        }

    }
}
