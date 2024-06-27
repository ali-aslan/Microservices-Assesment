using Sale.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sale.Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Sale.Application.Features.Customers.Constants;

namespace Sale.Application.Features.Customers.Rules;

public class CustomersBusinessRules 
{
    private readonly ICustomerRepository _customerRepository;

    public CustomersBusinessRules(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task CustomerNameCannotBeDuplicatedWhenInsterted(string name)
    {
        Customer? result = await _customerRepository.GetAsync(predicate: b => b.Name.ToLower() == name.ToLower());

        if (result != null)
        {
            throw new BusinessException(CustomersMessages.CustomersNameExist);
        }

    }
}
