using AutoMapper;

using Dealer.Application.Services.Repositories;
using Dealer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Suppliers.Commands.Create;


public class CreateSupplierCommand : IRequest<CreatedSupplierResponse>
{
    public string Name { get; set; }
    public string ContactName { get; set; }
    public string Phone { get; set; }
}

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreatedSupplierResponse>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<CreatedSupplierResponse>? Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        Supplier Supplier = _mapper.Map<Supplier>(request);
        Supplier.Id = new Guid();

        await _supplierRepository.AddAsync(Supplier);

        CreatedSupplierResponse createdSupplierResponse = _mapper.Map<CreatedSupplierResponse>(Supplier);
        return createdSupplierResponse;

    }

}