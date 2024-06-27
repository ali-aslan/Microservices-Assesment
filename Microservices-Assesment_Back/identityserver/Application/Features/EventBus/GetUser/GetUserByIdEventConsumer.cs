using Application.Services.Repositories;
using AutoMapper;
using Contracts.Request;
using Contracts.Responses;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EventBus.GetUser;

public class GetUserByIdEventConsumer : IConsumer<SellerRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdEventConsumer(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<SellerRequest> context)
    {
        var user = await _userRepository.GetAsync(self => self.Id == context.Message.Id);
        var mappedUser = _mapper.Map<SellerResponse>(user);
        await context.RespondAsync<SellerResponse>(mappedUser);
    }
}
