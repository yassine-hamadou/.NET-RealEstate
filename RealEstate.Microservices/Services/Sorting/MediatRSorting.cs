﻿using MediatR;
using RealEstate.Data.Context;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.Microservices.Services.Sorting
{
    internal class MediatRSortService
    {
        private readonly IMediator _mediator;

        public MediatRSortService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<Estate>> SortRealEstate(SortOptions options)
        {
            var query = new SortQuery
            {
                Options = options
            };

            var result = await _mediator.Send(query);

            return result.estatesList;
        }
    }

    public class SortQuery : IRequest<SortResult>
    {
        public SortOptions Options { get; set; }
    }

    public class SortResult
    {
        public List<Estate> estatesList { get; set; }
    }

    public class SortOptions
    {
        public SortDirection Direction { get; set; }
        public SortProperty Property { get; set; }
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public enum SortProperty
    {
        Price,
        Area,
        Type
    }

    public class SortHandler : IRequestHandler<SortQuery, SortResult>
    {
        private readonly EstatesDBContext _context;

        public SortHandler(EstatesDBContext context)
        {
            _context = context;
        }

        public async Task<SortResult> Handle(SortQuery request, CancellationToken cancellationToken)
        {
            // Perform sorting using the provided options.
            var resultList = _context.Estates
                .OrderBy(x => x.GetType().GetProperty(request.Options.Property.ToString()).GetValue(x))
                .ToList();

            if (request.Options.Direction == SortDirection.Descending)
            {
                resultList.Reverse();
            }

            return new SortResult
            {
                estatesList = resultList,
            };
        }
    }
}
