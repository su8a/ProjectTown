using System;
using System.Collections.Generic;

class Program
{
    // Словарь для хранения координат городов
    private static Dictionary<string, (double latitude, double longitude)> cities = new Dictionary<string, (double, double)>
    {
        { "Москва", (55.7558, 37.6173) },
        { "Санкт-Петербург", (59.9343, 30.3351) },
        { "Новосибирск", (55.0084, 82.0155) },
        { "Екатеринбург", (56.8389, 60.6057) },
        { "Нижний Новгород", (56.3287, 44.0020) },
        { "Казань", (55.8304, 49.0661) },
        { "Челябинск", (55.1644, 61.4368) },
        { "Самара", (53.2001, 50.15) },
        { "Омск", (54.9885, 73.3242) },
        { "Ростов-на-Дону", (47.2225, 39.7189) }
    };

    static void Main(string[] args)
    {
        Console.Write("Введите первый город: ");
        string city1 = Console.ReadLine();

        Console.Write("Введите второй город: ");
        string city2 = Console.ReadLine();

        if (cities.TryGetValue(city1, out var coordinates1) && cities.TryGetValue(city2, out var coordinates2))
        {
            double distance = CalculateDistance(coordinates1.latitude, coordinates1.longitude, coordinates2.latitude, coordinates2.longitude);
            Console.WriteLine($"Расстояние между '{city1}' и '{city2}' составляет {distance:F2} км.");
        }
        else
        {
            Console.WriteLine("Одного из городов нет в базе данных.");
        }
    }

    private static double CalculateDistance(double lat1, double lng1, double lat2, double lng2)
    {
        const double R = 6371.0; // Радиус Земли в километрах

        double dLat = ToRadians(lat2 - lat1);
        double dLng = ToRadians(lng2 - lng1);

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                   Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return R * c; // Расстояние в километрах
    }

    private static double ToRadians(double angle)
    {
        return angle * Math.PI / 180.0;
    }
}
