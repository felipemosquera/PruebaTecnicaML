using Felipe_ML.Models;

namespace Felipe_ML.Domain
{
    public interface IDataPersistence
    {
        void saveDna(Dna dna);

        Dna getDna(string dnaSequence);
    }
}