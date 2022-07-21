using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Context;
using SimpleCQRS.Models;

namespace SimpleCQRS.Features.Products.Queries
{
    public class ListQuery : IRequest<IEnumerable<Product>>
    {
        public class ListQueryHandler : IRequestHandler<ListQuery, IEnumerable<Product>>
        {
            private readonly IApplicationContext _context;

            public ListQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> Handle(ListQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }

                return productList.AsReadOnly();
            }
        }


    }
}