using AutoMapper;
using SimpleVoc.Domain.Entities;
using SimpleVocAPI.DTO.Vocabulary;

namespace SimpleVocAPI.Mapping
{
    public class VocabularyMapping : Profile
    {
        public VocabularyMapping()
        {
            CreateMap<Vocabulary, AddVocabularyResponse>();
            CreateMap<AddVocabularyRequest, Vocabulary>();

            CreateMap<Vocabulary, GetVocabularyResponse>();
        }
    }
}
