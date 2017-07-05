public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public Person(string firstName, string lastName, int age, double salary)
        : this(firstName, lastName, age)
    {
        this.salary = salary;
    }

    public string FirstName => this.firstName;
    public string LastName => this.lastName;
    public int Age => this.age;
    public double Salary => this.salary;

    public void IncreaseSalary(double percent)
    {
        if (this.age > 30)
        {
            this.salary += this.salary * percent / 100;
        }
        else
        {
            this.salary += this.salary * percent / 100 / 2;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.salary:f2} leva";
    }
}