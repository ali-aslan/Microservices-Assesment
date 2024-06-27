using AutoMapper;
using MediatR;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Customers.Queries.GetById;

public class GetByIdCustomerQuery : IRequest<GetByIdCustomerResponse>
{
    public Guid Id { get; set; }
}

public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetByIdCustomerResponse>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public GetByIdCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<GetByIdCustomerResponse> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
    {
        Customer? customer = await _customerRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
  
        GetByIdCustomerResponse response = _mapper.Map<GetByIdCustomerResponse>(customer);
        return response;
    }
}
