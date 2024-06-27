using AutoMapper;
using MediatR;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Customers.Commands.Delete;

public class DeleteCustomerCommand :IRequest<DeletedCustomerResponse>
{
    public Guid Id { get; set; }
}

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeletedCustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<DeletedCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await _customerRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

        await _customerRepository.DeleteAsync(customer);

        DeletedCustomerResponse response = _mapper.Map<DeletedCustomerResponse>(customer);
        return response;

    }
}
