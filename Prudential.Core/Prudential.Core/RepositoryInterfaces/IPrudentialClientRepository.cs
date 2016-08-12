using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prudential.Core.Domain;

namespace Prudential.Core.RepositoryInterfaces
{
    public interface IPrudentialClientRepository
    {
        PrudentialClient GetClient(int clientID);
        
    }
}
