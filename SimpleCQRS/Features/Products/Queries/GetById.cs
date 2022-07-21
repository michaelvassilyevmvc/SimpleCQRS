using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleCQRS.Context;
using SimpleCQRS.Models;
using System.Linq;

namespace SimpleCQRS.Features.Products.Queries
{
    public class GetByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Product>
        {
            private readonly IApplicationContext _context;

            public GetByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(GetByIdQuery query, CancellationToken cancellationToken)
            {
                // var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
                // if (product == null) return null;

                // return product;
                return await Task.FromResult(_context.Products.Single(p => p.Id == query.Id));
            }
        }
    }
}