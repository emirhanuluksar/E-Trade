using Application.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions //Extension metodu yazabilmek için o classın static olması gerekir.
    {
        // IServiceCollection --> Bizim apimizin servis bağımlılıklarını eklediğimiz ya da araya girmesini istediğimiz servisleri eklediğimiz koleksiyondur.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules) // this --> neyi genişletmek istiyorsak onu this ile veririz.
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}