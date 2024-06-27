using AutoMapper;
using MediatR;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Orders.Commands.Delete;

public class DeleteOrderCommand : IRequest<DeletedOrderResponse>
{
    public Guid Id { get; set; }
}

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeletedOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<DeletedOrderResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);

        await _orderRepository.DeleteAsync(order);

        DeletedOrderResponse response = _mapper.Map<DeletedOrderResponse>(order);
        return response;
    }
}

