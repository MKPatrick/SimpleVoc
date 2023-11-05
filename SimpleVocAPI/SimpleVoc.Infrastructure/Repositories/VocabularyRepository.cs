using SimpleVoc.Domain.Entities;
using SimpleVoc.Domain.Shared.Kernel;
using SimpleVoc.Infrastructure.Data;

namespace SimpleVoc.Infrastructure.Repositories
{
    public class VocabularyRepository : BaseRepository<Vocabulary>, IVocabularyRepository
    {
        public VocabularyRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
