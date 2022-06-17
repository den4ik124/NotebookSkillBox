using Microsoft.Extensions.Configuration;
using System;

namespace Notebook.Data
{
    public interface ISeeder
    {
        void Seed(IServiceProvider serviceProvider, IConfiguration configuration);
    }
}