using Bogus;
using AppApp.Domain;

namespace fs_user_accounts.Data
{
    public static class CarMockData
    {
        public static List<Vehicle> Vehicles()
        {
            var faker = new Faker<Vehicle>()
                .RuleFor(v => v.Manufacturer, f => f.PickRandom(new[] {
                    "Ferrari", "Lamborghini", "Toyota", "BMW", "Porsche", "Audi", "Nissan", "Chevrolet", "Ford", "Subaru"
                }))
                .RuleFor(v => v.Model, (f, v) => v.Manufacturer switch
                {
                    "Ferrari" => f.PickRandom("488 GTB", "812 Superfast", "SF90 Stradale"),
                    "Lamborghini" => f.PickRandom("Huracán", "Aventador", "Gallardo"),
                    "Toyota" => f.PickRandom("GR Supra", "Corolla", "Yaris GR"),
                    "BMW" => f.PickRandom("M2", "M4", "M5"),
                    "Porsche" => f.PickRandom("911 Carrera", "911 GT3", "Cayman GT4 RS"),
                    "Audi" => f.PickRandom("R8 V10", "RS3", "RS7"),
                    "Nissan" => f.PickRandom("GT-R", "Z"),
                    "Chevrolet" => f.PickRandom("Corvette C8", "Camaro ZL1"),
                    "Ford" => f.PickRandom("Mustang GT", "Focus RS"),
                    "Subaru" => f.PickRandom("WRX STI", "BRZ tS"),
                    _ => f.Vehicle.Model()
                })
                .RuleFor(v => v.Year, f => f.Random.Int(2015, 2025))
                .RuleFor(v => v.Engine, f => f.PickRandom(new[]
                {
                    "2.0L I4 Turbo", "3.0L I6 Twin Turbo", "4.0L V8", "5.2L V10", "6.5L V12"
                }))
                .RuleFor(v => v.Transmission, f => f.PickRandom("Manual", "Automatic", "Dual-Clutch"))
                .RuleFor(v => v.Price, f => f.Finance.Amount(50000, 400000));

            return faker.Generate(30);
        }
    }
}
