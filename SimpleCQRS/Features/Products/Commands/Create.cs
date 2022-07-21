using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleCQRS.Context;
using SimpleCQRS.Models;

namespace SimpleCQRS.Features.Products.Commands
{
    public class CreateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }

        public class CreateCommandHandler : IRequestHandler<CreateCommand, int>
        {
            private readonly IApplicationContext _context;

            public CreateCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.BuyingPrice = command.BuyingPrice;
                product.Rate = command.Rate;
                product.Description = command.Description;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}