using MediatR;
using SalesTaxes.Application.Common.Interfaces;
using SalesTaxes.Domain.Entities;

namespace SalesTaxes.Application.Sales.Commands
{
    public record CreateSalesCommand : IRequest<ReceiptDto>
    {
        public List<ItemInfo> Items { get; set; } = new List<ItemInfo>();
    }

    public class CreateSalesCommandHandler : IRequestHandler<CreateSalesCommand, ReceiptDto>
    {
        private readonly IApplicationDbContext _context;

        public CreateSalesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReceiptDto> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
        {
           
            var receipt = new Receipt();
            receipt.Total = request.Items.Sum(x => x.GetTotal());
            receipt.SalesTaxes = request.Items.Sum(x => x.GetSalesTaxes());
            _context.Receipts.Add(receipt);

            var itemReceipts = request.Items.Select(s => new ItemReceipt()
                {
                    IdItem = s.Id,
                    Quantity = s.Quantity,
                    IsImported = s.IsImported,
                    FinalPrice = s.GetTotal(),
                    IdReceiptNavigation = receipt
                }).ToList();

            _context.ItemReceipts.AddRange(itemReceipts);

            await _context.SaveChangesAsync(cancellationToken);

            var items = itemReceipts.Select(s =>
                new ItemDto()
                {
                    IdItem = s.IdItem,
                    Quantity = s.Quantity,
                    IsImported = s.IsImported,
                    FinalPrice = s.FinalPrice,
                    IdReceipt = s.IdReceipt
                }
            ).ToList();

            var response = new ReceiptDto() { Total = receipt.Total, SalesTaxes = receipt.SalesTaxes, Items = items };
            return response;
        }
    }
}
