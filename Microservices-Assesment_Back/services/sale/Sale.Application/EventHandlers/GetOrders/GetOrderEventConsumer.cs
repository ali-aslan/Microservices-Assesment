using AutoMapper;
using Contracts.Request;
using Contracts.Responses;
using Core.Persistence.Dynamic;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.EventHandlers.GetOrders;

public class GetOrderEventConsumer : IConsumer<OrderRequest>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderEventConsumer(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<OrderRequest> context)
    {
        var dynamicQuery = new DynamicQuery();
        var orders = await _orderRepository.GetListByDynamicAsync(
             dynamicQuery,
             include: q => q.Include(o => o.Product).Include(o => o.Customer),
             size: 10,
             cancellationToken: default
         );

        var mappedOrder = _mapper.Map<OrderResponse>(orders.Items.First()); /// mappingde hata veriyor o yüzden tekil aldım to do düzelt
        await context.RespondAsync<OrderResponse>(mappedOrder);
    }
}   
