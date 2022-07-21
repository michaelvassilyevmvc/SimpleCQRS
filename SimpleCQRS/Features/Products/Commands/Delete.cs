using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleCQRS.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SimpleCQRS.Features.Products.Commands
{
    public class DeleteCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, int>
        {
            private readonly IApplicationContext _context;

            public DeleteCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (product == null) return default;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}