using AutoMapper;
using Dealer.Application.Features.Suppliers.Queries.GetById;
using Dealer.Application.Services.Repositories;
using Dealer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Shippers.Queries.GetById;

public class GetByIdSupplierQuery : IRequest<GetByIdSupplierResponse>
{
    public Guid Id { get; set; }
}

public class GetByIdSupplierQueryHandler : IRequestHandler<GetByIdSupplierQuery, GetByIdSupplierResponse>
{
    private readonly IMapper _mapper;
    private readonly ISupplierRepository _supplierRepository;

    public GetByIdSupplierQueryHandler(IMapper mapper, ISupplierRepository supplierRepository)
    {
        _mapper = mapper;
        _supplierRepository = supplierRepository;
    }

    public async Task<GetByIdSupplierResponse> Handle(GetByIdSupplierQuery request, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

        GetByIdSupplierResponse response = _mapper.Map<GetByIdSupplierResponse>(supplier);
        return response;
    }
}
