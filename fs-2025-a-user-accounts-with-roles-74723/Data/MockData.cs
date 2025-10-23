
using AppApp.Domain;
using Bogus;

namespace fs_user_accounts.Data;

public static class MockData
{
    public static List<Patient> Patients(int setNumberOfPatients = 50)
    {
        List<Patient> patients = new List<Patient>();

        var faker = new Faker<Patient>()
            .RuleFor(p => p.Id, f => Guid.NewGuid().ToString())
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName));

        for (int i = 0; i < setNumberOfPatients; i++)
        {

            patients.Add(faker.Generate());
        }

        return patients;
       

    }
}

