

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string tomGender = "Male";
        public Tomcat(string name, int age) : base(name, age, tomGender)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
