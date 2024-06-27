using AutoMapper;
using MediatR;
using Sale.Application.Features.Customers.Rules;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Customers.Commands.Create;

public class CreateCustomerCommand:IRequest<CreatedCustomerResponse>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreatedCustomerResponse>
{
    public readonly ICustomerRepository _customerRepository;
    public readonly IMapper _mapper;
    //public readonly CustomersBusinessRules _customerBusinessRules;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper/* ,CustomersBusinessRules customerBusinessRules*/)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        //_customerBusinessRules = customerBusinessRules;
    }

    public async Task<CreatedCustomerResponse>? Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        //await _customerBusinessRules.CustomerNameCannotBeDuplicatedWhenInsterted(request.Name);

        Customer customer = _mapper.Map<Customer>(request);
        customer.Id = new Guid();

        await _customerRepository.AddAsync(customer);

        CreatedCustomerResponse createdCustomerResponse = _mapper.Map<CreatedCustomerResponse>(customer);
        return createdCustomerResponse;

    }
}


