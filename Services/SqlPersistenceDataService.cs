using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Felipe_ML.Domain;
using Felipe_ML.Models;

namespace Felipe_ML.Services
{
    public class SqlPersistenceDataService : IDataPersistence
    {
        private readonly PruebaMLContext _context;
        public SqlPersistenceDataService(PruebaMLContext context)
        {
            _context = context;

        }

        public Dna getDna(string dnaSequence)
        {
            return _context.Dnas.FirstOrDefault(x => x.DnaSequence == dnaSequence);
        }

        public void saveDna(Dna dna)
        {
            try
            {
                bool dnaNotExists = getDna(dna.DnaSequence) == null;
                if (dnaNotExists)
                {
                    _context.Dnas.AddAsync(dna);
                    _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}