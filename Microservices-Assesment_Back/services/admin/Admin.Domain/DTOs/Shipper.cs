﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.DTOs;

public record Shipper
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}
