using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Customers.Queries.GetList;

public class GetListCustomerQuery :IRequest<GetListResponse<GetListCustomerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

}

public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery,GetListResponse<GetListCustomerListItemDto>>
{

    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetListCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListCustomerListItemDto>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
    {
        Paginate<Customer> customer = await _customerRepository.GetListAsync(
       index: request.PageRequest.PageIndex,
       size: request.PageRequest.PageSize,
       cancellationToken: cancellationToken
       );

        GetListResponse<GetListCustomerListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerListItemDto>>(customer);
        return response;
    }
}
