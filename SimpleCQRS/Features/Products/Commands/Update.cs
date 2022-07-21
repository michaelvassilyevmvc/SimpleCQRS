using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleCQRS.Context;

namespace SimpleCQRS.Features.Products.Commands
{
    public class UpdateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }

        public class UpdateCommandHandler : IRequestHandler<UpdateCommand, int>
        {
            private readonly IApplicationContext _context;

            public UpdateCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();

                if (product == null) { return default; }
                else
                {
                    product.Barcode = command.Barcode;
                    product.Name = command.Name;
                    product.BuyingPrice = command.BuyingPrice;
                    product.Rate = command.Rate;
                    product.Description = command.Description;
                    await _context.SaveChangesAsync();
                    return product.Id;
                }

            }
        }
    }
}