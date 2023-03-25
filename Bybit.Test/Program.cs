using Bybit.Business.Abstract;
using Bybit.Business.Concrete;
using Bybit.Test;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IBybitService, BybitManager>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
