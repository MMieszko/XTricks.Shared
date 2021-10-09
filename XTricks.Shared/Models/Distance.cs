namespace XTricks.Shared.Models
{
    public struct Distance
    {
        public double Meters { get; }

        public double Miles => Meters * 1609.344;
        public double Kilometers => Meters * 1000;

        public static Distance FromMeters(double value) => new Distance(value);
        public static Distance FromMiles(double value) => new Distance(value * 1609.344);
        public static Distance FromKilometers(double value) => new Distance(value * 1000);

        public Distance(double meters)
        {
            Meters = meters;
        }

        public static bool operator >(Distance first, Distance second)
        {
            return first.Meters > second.Meters;
        }

        public static bool operator <(Distance first, Distance second)
        {
            return first.Meters < second.Meters;
        }

        public static bool operator >=(Distance first, Distance second)
        {
            return first.Meters >= second.Meters;
        }

        public static bool operator <=(Distance first, Distance second)
        {
            return first.Meters > second.Meters;
        }

        public static Distance operator +(Distance first, Distance second)
        {
            return FromMeters(first.Meters + second.Meters);
        }

        public static Distance operator -(Distance first, Distance second)
        {
            return FromMeters(first.Meters + second.Meters);
        }
    }
}
