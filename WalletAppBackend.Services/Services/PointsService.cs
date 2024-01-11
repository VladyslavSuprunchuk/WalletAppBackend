using Microsoft.EntityFrameworkCore;
using WalletAppBackend.DatabaseProvider;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Services.Services
{
    public class PointsService : IPointsService
    {
        private readonly DataContext _dataContext;

        public PointsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CalculatePointsAsync(int userId)
        {
            var currentDate = DateTime.UtcNow;
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user!.DateOfPointsSum is not null && user!.DateOfPointsSum.Value.Date == currentDate.Date)
            {
                return user.Points;
            }

            var currentMonth = currentDate.Month;

            double points = 0;

            if (IsFirstDayOfSeason(currentDate))
            {
                points = 2;
            }
            else if (IsSecondDayOfSeason(currentDate))
            {
                points = 3;
            }
            else
            {
                var dateOfPointsSum = user.DateOfPointsSum!.HasValue ? user.DateOfPointsSum.Value : currentDate.AddDays(-1);
                var previousDayPoints = CalculatePoints(currentDate, dateOfPointsSum);
                var currentPoints = previousDayPoints + (previousDayPoints * 0.6);
                points = currentPoints;
            }

            user.Points += Convert.ToInt32(points);
            user.DateOfPointsSum = currentDate;

            await _dataContext.SaveChangesAsync();

            return user.Points;
        }

        private double CalculatePoints(DateTime currentDate, DateTime lastPointsDate)
        {
            var daysPassed = (currentDate - lastPointsDate).Days;

            if (daysPassed == 1)
            {
                return 2;
            }
            else if (daysPassed == 2)
            {
                return 3;
            }
            else
            {
                var previousDayPoints = CalculatePoints(currentDate.AddDays(-1), lastPointsDate);
                var currentPoints = previousDayPoints + (previousDayPoints * 0.6);
                return currentPoints;
            }
        }

        private static bool IsFirstDayOfSeason(DateTime currentDate)
        {
            return currentDate.Month % 3 == 1 && currentDate.Day == 1;
        }

        private static bool IsSecondDayOfSeason(DateTime currentDate)
        {
            return currentDate.Month % 3 == 1 && currentDate.Day == 2;
        }
    }
}
