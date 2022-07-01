﻿using MediatR;
using RealEstate.Core.Models;

namespace RealEstate.CQRS.Queries
{
    public class GetPropertyByIdQuery : IRequest<PropertyViewModel>
    {
        public int Id { get; set; }
        public GetPropertyByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
