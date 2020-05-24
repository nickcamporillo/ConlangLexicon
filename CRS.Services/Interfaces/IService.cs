using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;
using IT.IRepository;

using CRS.Models;

namespace CRS.Services
{
    public interface IService
    {
        int AccessCode { get; }
    }
}
