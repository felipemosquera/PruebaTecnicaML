using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Felipe_ML.Domain;
using Felipe_ML.Models;

namespace Felipe_ML.Services
{
    public class StatsService : IStats
    {
        private readonly PruebaMLContext _context;

        public StatsService(PruebaMLContext context)
        {
            _context = context;
        }
        public StatsDna GetStatsDna()
        {
            double ratio;
            int dnasAreMutant = _context.Dnas.Where(d => d.IsMutant == true).Count();
            int dnasAreHuman = _context.Dnas.Where(d => d.IsHuman == true).Count();
            if (dnasAreHuman == 0)
            {
                ratio = 0;
            }
            else
            {
                ratio = (double)dnasAreMutant / dnasAreHuman;
            }
            return new StatsDna
            {
                CountMutantDna = dnasAreMutant,
                CountHumanDna = dnasAreHuman,
                Ratio = ratio
            };
        }
    }
}