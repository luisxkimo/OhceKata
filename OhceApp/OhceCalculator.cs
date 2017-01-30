using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhceApp
{
    public class OhceCalculator
    {
        public IEnumerable<string> CalculateResult(string input, DateTime dateTime)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(Name))
            {
                if (string.IsNullOrEmpty(input))
                {
                    result.Add(RunCommandErrorMessage);
                    return result;
                }

                if (!input.Contains(RunCommand))
                {
                    result.Add(RunCommandErrorMessage);
                    return result;
                }
                else
                {
                    var realInput = input.Split(null);
                    if (realInput.Count() < 2)
                    {
                        result.Add(RunCommandErrorMessage);
                        return result;
                    }
                    else
                    {
                        name = realInput[1];
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            result.Add(RunCommandErrorMessage);
                            return result;
                        }
                        result.Add(CalculateGreetMessage(dateTime));
                        return result;
                    }
                }
            }

            if (input.Equals(StopCommand))
            {
                result.Add(Bye + name);
                return result;
            }

            var reverseWord = String.Join("", input.Reverse());
            if (reverseWord.Equals(input))
            {
                result.Add(reverseWord);
                result.Add(AmazingWord);
            }
            else
            {
                result.Add(reverseWord);
            }

            return result;
        }

        private string CalculateGreetMessage(DateTime dateTime)
        {
            var morningDate1 = new TimeSpan(6, 0, 1);
            var morningDate2 = new TimeSpan(12, 0, 0);
            var afternoonDate1 = new TimeSpan(12, 0, 1);
            var afternoonDate2 = new TimeSpan(20, 0, 0);
            var nightDate1 = new TimeSpan(20, 0, 1);
            var nightDate2 = new TimeSpan(6, 0, 0);

            var hour = dateTime.TimeOfDay;
            if (hour >= morningDate1 && hour < morningDate2)
            {
                return MorningGreeting + name;
            }
            if (hour >= afternoonDate1 && hour < afternoonDate2)
            {
                return AfternoonGreeting + name;
            }

            return NightGreeting + name;
        }

        private string name = string.Empty;

        public string Name
        {
            get { return name; }
        }
        public string RunCommand = "ohce";
        public string RunCommandErrorMessage = "Youy should write 'ohce <YourName> for run the program.'";
        public string Bye { get; } = "Adios ";
        public string MorningGreeting { get; } = "!Buenos días ";
        public string NightGreeting { get; } = "!Buenos noches ";
        public string AfternoonGreeting { get; } = "!Buenos tardes ";

        public static string StopCommand { get; } = "Stop!";
        public string AmazingWord { get; } = "Bonita Palabra!";
    }
}
