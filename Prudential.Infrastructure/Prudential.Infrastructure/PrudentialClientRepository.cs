using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prudential.Core.Domain;
using Prudential.Core.RepositoryInterfaces;
using AutoMapper;

namespace Prudential.Infrastructure
{
    public class PrudentialClientRepository : IPrudentialClientRepository
    {
        public PrudentialClient GetClient(int clientID)
        {
            // SOAP Service call
            var service = new PrudentialClientService.ClientService30Client();
            var request = new PrudentialClientService.getClientRequest();
            var requestType = new PrudentialClientService.GetClientRequestType();

            var callerDetails = new PrudentialClientService.CallerDetails();
            callerDetails.username = "demo";
            callerDetails.country = "AU";
            callerDetails.databaseIdentifier = "SonataDatasource";

            var clientType = new PrudentialClientService.ClientIdentifierType();
            clientType.id = clientID;
            clientType.idSpecified = true;

            request.getClientRequest1 = requestType;
            request.getClientRequest1.CallerDetails = callerDetails;
            request.getClientRequest1.client = clientType;

            var x = service.getClientAsync(request.getClientRequest1);
            x.Wait();

            // Mapping
            PrudentialClient client = new PrudentialClient();
            client.forename = x.Result.getClientResponse1.client.clientForename;
            client.surname = x.Result.getClientResponse1.client.clientSurname;

            return client; 

        }

        public void CompleteTask(Task<PrudentialClientService.getClientResponse> task)
        {
            int blah = 0;

        }
    }
}
