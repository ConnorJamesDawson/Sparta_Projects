namespace ClassesApp
{
    public class Person 
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private Address _address;
        public Person() { }
        public Person(string firstName, string lastName, Address address = null)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
        }

        public int Age
        {
            get { return _age; }
            set { if (value >= 0) _age = value; }
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }

        public string GetAddress()
        {
            return $"{_address}";
        }

        public string Move()
        {
            return "Walking along";
        }

        public string Move(int times)
        {
            return $"Walking along {times} times";
        }

        public override string ToString()
        {
            return $"{base.ToString()} Name: {GetFullName()} Age: {Age}. {GetAddress()}";
        }
    }
}
