using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nlove_inclass08
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            Console.WriteLine();
            p.GreetFriend();
            Console.WriteLine();
            Person p1 = new Person("Natasha", 18);
            p1.GreetFriend();
            Console.WriteLine();
            Person p2 = new Person(30);
            p2.GreetFriend();
            Console.WriteLine();
            Console.WriteLine("You've created {0} persons.", Person.numOfPersons); //only PUBLIC fields/methods can be called like that with the ClASS.
            Console.WriteLine();

            //array of persons
            Person[] persons = new Person[2] { new Person ("Kim", 18), new Person ( "John", 20 )};

            persons[0].GreetFriend();
            persons[1].GreetFriend();

            Console.WriteLine();
            //operator+ is used so just can add persons [0] + persons [1] istead of .Age .. 
            Console.WriteLine("The combined ages of {0} and {1} is {2}", persons[0].Name, persons[1].Name, persons[0] + persons[1]);
            Console.WriteLine();
            Person[] p3 = new Person[1];
            p3[0] = new Person();

            p3[0].Name = "Masha";
            p3[0].Age = -4;
            p3[0].GreetFriend();
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class Person {

        private string _name;
        private int _age;
        private readonly int _personID; // readonly - makes variable CONSTANT - nothing can change it!
        private bool _isAdult;

        public static int numOfPersons = 0;// better be private - so no one could change it manually

        //constructor the same as = 
        /*
!!!!!!  public Person() : this("n/a", 1){}     !!!!!!!
        */
        //- takes parameters from the other custom constructor (below) according to the type - or in order if the same type
        //so - in case object is created without some args - it will fill them in by default
        //BUT~ it takes all other body too - methods or print etc!!!
        public Person() {

            //adds count of all created Person objects by al constructors
           ++ numOfPersons;
            this._personID = numOfPersons + 100000;// gives each person object a unique ID- which can't be changed
            _name = "n/a";
            _age = 1;
            Console.WriteLine("You created a person without a name or age");
        }

        public Person(int age): this("n/a", age)
        {
            Console.WriteLine("You created a person only with age");
        }

        public Person(string name, int age) {
            //adds count of all created Person objects by al constructors
            ++numOfPersons;
            //personID constant can be modified in constructor!
            this._personID = numOfPersons + 100000;// gives each person object a unique ID- which can't be changed
            Age = age;
            Name = name;
            Console.WriteLine("You created a person with all necessary data.");
        }

        //to see the erase message in the end - start the program without debugging - or hotkeys:ctrl+fn+F5
        ~Person() {
            Console.WriteLine("You erased person {0}.", _name);
        }

        //variable with body- only used for getters and setters!!!!
        public string Name {
            
            //get and set DON'T need "()"!
            //string is already declared in the main var NAME
            get {
                return _name;
            }

            set {
                _name = value;// a built-in variable- will remember the name value

            }

        }

       /* THE SAME as above- but EASY way to make GETTERS and SETTERS!!!
         * 
         * public string Name {get; set; }
         * 
         */

        public int Age
        {

            get
            {
                return _age;
            }

            set
            {
                //_age = value; // VALUE is always used in this case!

                _age = (value >= 0) ? value : 0;// if value>=0, _age=value; else - _age=0 

                if (_age >= 18)
                {
                    _isAdult = true;
                }
                else
                {
                    _isAdult = false;

                }

            }

        }

            public int PersonID {

                get {
                    return _personID;
                }
            }
            

           public void GreetFriend() {
            Console.WriteLine("Hi, my name is {0}, I'm {1} years old, and my ID is: {2}.", _name, _age, _personID);
        }

        //operator+,-,*,/
        public static int operator+(Person p1, Person p2) {
            return p1.Age + p2.Age;
        }


    }

}
