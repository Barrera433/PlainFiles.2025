using CVSWithlibrary;

var List = new List<Person>
{
    new Person { Id = 1, Name = "Maria", Age = 28 },
    new Person { Id = 2, Name = "juan", Age = 34 },
};

var helper = new CsvHelperExample();
helper.WriteCsv("people.csv", List);

var readPeople = helper.Read("people.csv");
foreach (var person in readPeople)
{
    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}");
}