namespace WebApplicationDemo.Services
{
    public class StringManipulations
    {
        public bool CheckIfStringIsMail(string input)
        {
            if(input == null) throw new ArgumentNullException(nameof(input));
            if(String.IsNullOrWhiteSpace(input)) throw new ArgumentException(nameof(input));

            return input.Contains('@');
        }
    }
}
