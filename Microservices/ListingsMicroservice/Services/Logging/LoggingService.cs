﻿using Nest;
using System.Reflection.Metadata;

<<<<<<< Updated upstream
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Logging/LoggingService.cs
namespace RealEstate.Microservices.Logging
=======
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Utils/Logging/LoggingService.cs
namespace RealEstate.Microservices.Utils.Logging
>>>>>>> Stashed changes
=======
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Logging/LoggingService.cs
namespace RealEstate.Microservices.Logging
=======
namespace UtilitiesMicroservice.Services.Logging
>>>>>>> Stashed changes:Microservices/UtilitiesMicroservice/Services/Logging/LoggingService.cs
<<<<<<< Updated upstream
>>>>>>> Stashed changes:Microservices/UtilitiesMicroservice/Services/Logging/LoggingService.cs
=======
>>>>>>> Stashed changes:Microservices/ListingsMicroservice/Services/Logging/LoggingService.cs
>>>>>>> Stashed changes
{
    public class LoggingService
    {
        private ElasticClient client = new ElasticClient(new Uri("http://localhost:9200"));

        /*
        public void CreateIndexAttempt()
        {
            // Create an index
            client.CreateIndex("myindex", c => c
                .Mappings(m => m
                    .Map<Document>(mm => mm
                        .AutoMap()
                    )
                )
            );

            // Add a document to the index
            client.Index(new Document { Id = 1, Name = "John Smith" }, i => i.Index("myindex"));

            // Search the index
            var result = client.Search<Document>(s => s
                .Index("myindex")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Name)
                        .Query("John")
                    )
                )
            );

        }*/
    }
}
