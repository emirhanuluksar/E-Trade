using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities.Interceptors;
using Application.Utilities.Security.JWT;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Infrastructure.Abstract;
using Infrastructure.Concrete;
using Persistence.Abstract;
using Persistence.Concrete.EntityFramework;
// using Infrastructure.Abstract;
// using Infrastructure.Concrete;
// using Persistence.Abstract;
// using Persistence.Concrete;

namespace Infrastructure.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<StoreManager>().As<IStoreService>().SingleInstance();
            builder.RegisterType<EfStoreDal>().As<IStoreDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //builder.RegisterType<CartManager>().As<ICartService>();
            //builder.RegisterType<EfCartDal>().As<ICartDal>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}