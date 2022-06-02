using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Felipe_ML.Models;

namespace Felipe_ML.Domain
{
    public interface IStats
    {
        StatsDna GetStatsDna();
    }
}