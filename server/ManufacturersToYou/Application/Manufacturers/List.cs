using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Manufacturers
{
    public class List
    {
        public class Query : IRequest<List<ManufacturerDto>> { }

        public class Handler : IRequestHandler<Query, List<ManufacturerDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<ManufacturerDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // var manufacturers = await _context.Manufacturers.Select(m => m.Products.SelectMany(x => x.Products.Take(10).ToList())).ToListAsync();

                var manufacturers = await _context.Manufacturers.ToListAsync();

                foreach(var m in manufacturers)
                {
                    m.Products = m.Products.Take(10).ToList();
                }

                return _mapper.Map<List<Manufacturer>, List<ManufacturerDto>>(manufacturers);
            }
        }
    }
}