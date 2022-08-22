using MediatR;
using SalesTaxes.Application.Common.Interfaces;
using SalesTaxes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Application.Sales.Commands
{
    public record CreateSalesCommand : IRequest<int>
    {
        public List<ItemInfo> Items;
    }

    public class CreateSalesCommandHandler : IRequestHandler<CreateSalesCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateSalesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
