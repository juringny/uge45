namespace ValidateTheNameModelBinding.Models
{
    public class Person
    {
        private Firstname firstName; // Ændret fra string
        private Lastname lastName;   // Ændret fra string

        // Konstruktor modtager domæneprimitiver
        public Person(Firstname firstName, Lastname lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return $"{firstName.Value} {lastName.Value}";
        }
    }
}
