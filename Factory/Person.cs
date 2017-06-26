namespace Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static class PersonFactory
        {
            public static int ContPerson = 0;

            public static Person CreatePerson(string name)
            {
                Person person = new Person(name);
                ContPerson++;

                return person;
            }
        }

        private Person (string name)
        {
            this.Name = name;
            this.Id = PersonFactory.ContPerson;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
