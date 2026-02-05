using CarRentalDAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalDAL.BackgroundJobs
{
    public class RentalStatusUpdater : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RentalStatusUpdater(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // حساب الوقت المتبقي لليوم التالي الساعة 12 منتصف الليل
                var now = DateTime.Now;
                var nextRun = now.Date.AddDays(1).AddHours(0); // الساعة 12:00 منتصف الليل
                var delay = nextRun - now;
                if (delay < TimeSpan.Zero)
                    delay = TimeSpan.Zero;

                await Task.Delay(delay, stoppingToken);

                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDBContext>();

                // rentals المتأخرة
                await context.Database.ExecuteSqlRawAsync(@"
                    UPDATE Rentals
                    SET Status = 'Late'
                    WHERE ActualDate IS NULL
                    AND ReturnDate <= GETDATE()
                    AND Status <> 'Late';
               ");

                // العربيات التي رجعت
                await context.Database.ExecuteSqlRawAsync(@"
                    UPDATE c
                    SET c.Status = 'Available'
                    FROM Cars c
                    INNER JOIN Rentals r ON c.Id = r.CarId
                    WHERE r.ActualDate IS NOT NULL
                    AND c.Status <> 'Available';
               ");

                // العربيات التي تم استئجارها الآن
                await context.Database.ExecuteSqlRawAsync(@"
                    UPDATE c
                    SET c.Status = 'Rented'
                    FROM Cars c
                    INNER JOIN Rentals r ON c.Id = r.CarId
                    WHERE r.ActualDate IS NULL
                    AND r.Status = 'Active'
                    AND c.Status <> 'Rented';
               ");
            }
        }
    }
}
