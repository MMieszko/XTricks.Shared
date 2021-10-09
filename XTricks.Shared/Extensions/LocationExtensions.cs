using System;
using XTricks.Shared.Contracts;
using XTricks.Shared.Models;

namespace XTricks.Shared.Extensions
{
    public static class LocationExtensions
    {
        public static Distance DistanceTo(this ILocation @this, ILocation second)
        {
            const double earthRadius = 6371;

            var dLat = Deg2Rad(second.Latitude - @this.Latitude);
            var dLon = Deg2Rad(second.Longitude - @this.Longitude);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(Deg2Rad(@this.Latitude)) * Math.Cos(Deg2Rad(second.Longitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            var d = earthRadius * c;

            return Distance.FromKilometers(Math.Round(d, 3));

            double Deg2Rad(double deg) => deg * Math.PI / 180.0;
        }
    }
}
