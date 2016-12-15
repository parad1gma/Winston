using Autofac;
using Winston.BL.Interfaces;
using Winston.BL.Managers;
using Winston.DAL;
using Winston.DAL.Interfaces;
using Winston.DAL.Repository;
using Winston.DAL.UoW;

namespace Winston.Infrastructure.Ioc
{
    public static class IoCFactory
    {
        public static ContainerBuilder GetContainer()
        {
            var builder = new ContainerBuilder();


            //BL.Managers
            builder.RegisterType<OfferManager>().As<IOfferManager>().InstancePerRequest();
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerRequest();
            builder.RegisterType<VoucherManager>().As<IVoucherManager>().InstancePerRequest();
            builder.RegisterType<KeyAccountManager>().As<IKeyAccountManager>().InstancePerRequest();
            builder.RegisterType<VoucherTransactionManager>().As<IVoucherTransactionManager>().InstancePerRequest();
            builder.RegisterType<UserSegmentManager>().As<IUserSegmentManager>().InstancePerRequest();
            //DAL.Repositories
            builder.RegisterType<OfferRepository>().As<IOfferRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<VoucherRepository>().As<IVoucherRepository>().InstancePerRequest();
            builder.RegisterType<UserVoucherRepository>().As<IUserVoucherRepository>().InstancePerRequest();
            builder.RegisterType<KeyAccountRepository>().As<IKeyAccountRepository>().InstancePerRequest();
            builder.RegisterType<VoucherTransactionRepository>().As<IVoucherTransactionRepository>().InstancePerRequest();
            builder.RegisterType<UserSegmentRepository>().As<IUserSegmentRepository>().InstancePerRequest();

            builder.RegisterType<UoW>().As<IUoW>().InstancePerRequest();
            builder.RegisterType<WinstonEntities>().As<IWinstonEntities>().InstancePerRequest();

            return builder;
        }
    }
}
