using Bybit.Business.Abstract;
using Bybit.Entity.Dtos.Market;

namespace Bybit.Test
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBybitService _bybitService;

        public Worker(ILogger<Worker> logger, IBybitService bybitService)
        {
            _logger = logger;
            _bybitService = bybitService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var model = new TickerDto
                {
                    Category = Models.Enums.CategoryEnum.SPOT,
                    Symbol = "AVAXUSDT"
                };
                var result = await _bybitService.Market.GetTickersAsync(model, ct: stoppingToken);
            }
            catch (Exception ex)
            {

            }

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}