using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Security.Infraestructure
{
    public interface ITokenCore
    {
        string RunTokenGeneration(List<KeyValuePair<string, string>> tokenInfo, Guid userID);
    }
}
