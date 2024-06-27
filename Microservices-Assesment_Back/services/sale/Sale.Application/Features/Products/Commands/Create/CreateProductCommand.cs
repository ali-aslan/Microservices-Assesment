using AutoMapper;
using MediatR;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreatedProductResponse>
{
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public Decimal Price { get; set; }
    public int StockQuantity { get; set; }
}

public class CreatedProductResponseHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreatedProductResponseHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreatedProductResponse>? Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = _mapper.Map<Product>(request);
        product.Id = new Guid();

        await _productRepository.AddAsync(product);

        CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(product);
        return createdProductResponse;
    }
}
