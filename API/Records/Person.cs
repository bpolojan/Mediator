using Microsoft.AspNetCore.Mvc.Formatters;

namespace API.Records
{
    public record Person(string FullName, DateOnly DateOfBirth);

    public class PersonAsExplicitRecord
    {
        public string FullName { get; init; } = default!;
        public DateOnly DateOfBirth { get; init; } = default!;
    }

    public class PersonAsClass
    { 
        public string FullName { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; } = default!;
    }

    public class Run
    {
        public void Init()
        {
            var polo = new Person("Polo", new DateOnly(1986, 12, 12));

            var poloAsClass = new PersonAsClass() { FullName = "Polo", DateOfBirth = new DateOnly(1986, 12, 12) };
        }
    }
    
}
