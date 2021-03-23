using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Utilities.IoC
{
    public interface IGlobalModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
