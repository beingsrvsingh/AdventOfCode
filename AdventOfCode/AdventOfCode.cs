using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class AdventOfCode
    {
        public static void Main()
        {
            //Day1();
            //Day2();
            //Day2_Part2();
            //Day4();
            Day4_Part2();
            Console.ReadLine();
        }

        private static void Day1()
        {
            using StreamReader reader = new StreamReader("../../../ValidInput.txt");
            int counter = 0;
            string line;
            List<int> input = new List<int>();

            while ((line = reader.ReadLine()) != null)
            {
                input.Add(Convert.ToInt32(line.Replace(",", "")));
                counter++;
            }

            reader.Close();

            foreach (var number in input)
            {
                foreach (var number1 in input)
                {
                    int output = number + number1;

                    if (output == 2020)
                    {
                        Console.WriteLine("Previous value {0} and current value {1}", number, number1);
                    }
                }
            }
        }

        private static void Day2()
        {
            int counter = 0;
            string line;
            using StreamReader reader = new StreamReader("../../../PasswordPolicyInput.txt");
            List<int> outputCount = new List<int>();
            while ((line = reader.ReadLine()) != null)
            {
                var length = line.Split('-');
                var validLowestNumber = Convert.ToInt32(length[0]);
                var validHighestNumber = Convert.ToInt32(length[1].Split(' ')[0]);
                var passwordChar = Convert.ToChar(length[1].Split(' ')[1].Replace(":", ""));
                var password = length[1].Split(' ')[2];

                List<int> passwordContains = new List<int>();
                var pass = password.ToCharArray();

                int increment = 1;
                foreach (char word in pass)
                {
                    if (word == passwordChar)
                    {
                        passwordContains.Add(increment);
                    }
                    increment++;
                }

                if (passwordContains.Count >= validLowestNumber && passwordContains.Count <= validHighestNumber)
                {
                    outputCount.Add(counter);
                }

                counter++;
            }
            Console.WriteLine("Total number of valid password {0}", outputCount.Count);
        }

        private static void Day2_Part2()
        {
            int counter = 0;
            string line;
            using StreamReader reader = new StreamReader("../../../PasswordPolicyInput.txt");
            Dictionary<int, Boolean> keyValues = new Dictionary<int, bool>();
            while ((line = reader.ReadLine()) != null)
            {
                var length = line.Split('-');
                var validLowestNumber = Convert.ToInt32(length[0]);
                var validHighestNumber = Convert.ToInt32(length[1].Split(' ')[0]);
                var passwordChar = Convert.ToChar(length[1].Split(' ')[1].Replace(":", ""));
                var password = length[1].Split(' ')[2];

                var pass = password.ToCharArray();

                int increment = 1;
                foreach (char word in pass)
                {
                    if (validLowestNumber == increment && word == passwordChar)
                    {
                        keyValues.Add(counter, true);
                    }
                    if (validHighestNumber == increment && word == passwordChar)
                    {
                        if (keyValues.ContainsKey(counter))
                        {
                            keyValues[counter] = false;
                        }
                        else
                        {
                            keyValues.Add(counter, true);
                        }
                    }

                    increment++;
                }

                keyValues = keyValues.Where(x => x.Value).ToDictionary(p => p.Key, p => p.Value);

                counter++;
            }
            Console.WriteLine("Total number of valid password {0}", keyValues.Count);
        }

        private static void Day4()
        {
            using StreamReader reader = new StreamReader("../../../PassportInput.txt");
            int counter = 0;
            string line;

            List<Passport> lstPassport = new List<Passport>();            

            while ((line = reader.ReadLine()) != null)
            {
                Passport passport = new Passport();

                if (!string.IsNullOrEmpty(line))
                {
                    Dictionary<string, string> keyValuePairs = line.Split(' ').Select(value => value.Split(':')).ToDictionary(pair => pair[0], pair => pair[1]);

                    if (lstPassport.Any(x => x.Id == counter))
                    {
                        foreach (var item in keyValuePairs)
                        {
                            lstPassport[counter].passport.Add(item.Key, item.Value);
                        }
                    }
                    else
                    {
                        passport.Id = counter;
                        passport.passport = keyValuePairs;
                        lstPassport.Add(passport);
                    }

                    continue;
                }
                counter++;
            }

            int validPassportCount = lstPassport.Count(x => x.passport.ContainsKey("byr") && x.passport.ContainsKey("iyr") && x.passport.ContainsKey("eyr")
            && x.passport.ContainsKey("hgt") && x.passport.ContainsKey("hcl") && x.passport.ContainsKey("ecl") && x.passport.ContainsKey("pid"));

            Console.WriteLine(validPassportCount);

        }

        private static void Day4_Part2()
        {
            using StreamReader reader = new StreamReader("../../../PassportInput.txt");
            int counter = 0;
            string line;

            List<Passport> lstPassport = new List<Passport>();

            while ((line = reader.ReadLine()) != null)
            {
                Passport passport = new Passport();

                if (!string.IsNullOrEmpty(line))
                {
                    Dictionary<string, string> keyValuePairs = line.Split(' ').Select(value => value.Split(':')).ToDictionary(pair => pair[0], pair => pair[1]);

                    if (lstPassport.Any(x => x.Id == counter))
                    {
                        foreach (var item in keyValuePairs)
                        {
                            lstPassport[counter].passport.Add(item.Key, item.Value);
                        }
                    }
                    else
                    {
                        passport.Id = counter;
                        passport.passport = keyValuePairs;
                        lstPassport.Add(passport);
                    }

                    continue;
                }
                counter++;
            }

            int validPassportCount = lstPassport.Count(x => 
                                                        x.passport.Where(x => x.Key == "byr").Any(x => Convert.ToInt32(x.Value) >= 1920 && Convert.ToInt32(x.Value) <= 2002)
                                                        && x.passport.Where(x => x.Key == "iyr").Any(x => Convert.ToInt32(x.Value) >= 2010 && Convert.ToInt32(x.Value) <= 2020)
                                                        && x.passport.Where(x => x.Key == "eyr").Any(x => Convert.ToInt32(x.Value) >= 2020 && Convert.ToInt32(x.Value) <= 2030)
                                                        && x.passport.Any(x => x.Key == "hcl" && x.Value.Contains("#") && Regex.IsMatch(x.Value.Replace("#", ""), @"^[0-9a-z]{6}"))
                                                        && x.passport.Any(x => x.Key == "ecl" && (x.Value == "amb" || x.Value.Contains("blu") || x.Value.Contains("brn") || x.Value.Contains("gry") || x.Value.Contains("grn") || x.Value.Contains("hzl") || x.Value.Contains("oth")))
                                                        && x.passport.Any(x => x.Key == "pid" && x.Value.Length == 9)
                                                        && (x.passport.Where(x => x.Key == "hgt" && x.Value.Contains("cm")).Any(x => (Convert.ToInt32(x.Value.Replace("cm", "")) >= 150 && Convert.ToInt32(x.Value.Replace("cm", "")) <= 193))
                                                        || x.passport.Where(x => x.Key == "hgt" && x.Value.Contains("in")).Any(x => (Convert.ToInt32(x.Value.Replace("in", "")) >= 59 && Convert.ToInt32(x.Value.Replace("in", "")) <= 76)))
                                                        );

            Console.WriteLine(validPassportCount);

        }

    }
}