using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class AdventOfCode
    {
        public static void Main()
        {
            //Day1();
            //GetValidPasswordCount_Day2();
            //GetValidPasswordCount_Day2_Part2();
            Console.ReadLine();
        }

        private static void Day1()
        {
            int[] input = {1686,
                                1337,
                                1780,
                                1305,
                                1341,
                                1120,
                                1197,
                                1786,
                                1819,
                                1414,
                                1714,
                                1232,
                                1672,
                                1617,
                                817 ,
                                1665,
                                1603,
                                1063,
                                2007,
                                1609,
                                2008,
                                1878,
                                1660,
                                1834,
                                1901,
                                323 ,
                                1321,
                                1380,
                                1598,
                                1938,
                                1575,
                                502 ,
                                2010,
                                1470,
                                1902,
                                1779,
                                1081,
                                1535,
                                2002,
                                1168,
                                1702,
                                1973,
                                1866,
                                1115,
                                1774,
                                1274,
                                1845,
                                1584,
                                1574,
                                1772,
                                1735,
                                1631,
                                1628,
                                1907,
                                1466,
                                756 ,
                                1252,
                                1627,
                                1999,
                                1826,
                                1802,
                                1921,
                                1536,
                                1549,
                                1602,
                                1421,
                                1451,
                                1709,
                                1722,
                                1951,
                                1689,
                                1106,
                                1454,
                                1384,
                                1553,
                                1604,
                                1595,
                                468 ,
                                1082,
                                1576,
                                1958,
                                1913,
                                1075,
                                1708,
                                1775,
                                701 ,
                                1764,
                                1439,
                                1600,
                                1922,
                                1815,
                                1839,
                                1396,
                                1974,
                                1946,
                                1965,
                                1544,
                                2003,
                                1693,
                                1594,
                                1547,
                                1054,
                                1796,
                                1945,
                                1773,
                                1483,
                                1563,
                                1721,
                                1789,
                                1427,
                                1915,
                                1069,
                                1161,
                                1551,
                                1677,
                                1692,
                                2005,
                                1770,
                                1940,
                                1346,
                                1068,
                                1588,
                                1618,
                                1468,
                                1621,
                                1749,
                                1275,
                                1315,
                                1382,
                                1847,
                                1843,
                                1751,
                                1876,
                                1667,
                                1835,
                                1848,
                                1623,
                                1810,
                                1877,
                                1438,
                                968 ,
                                1867,
                                1763,
                                1390,
                                1967,
                                1785,
                                1530,
                                1343,
                                1423,
                                415 ,
                                1606,
                                1928,
                                1985,
                                1781,
                                1952,
                                1459,
                                1339,
                                1644,
                                1860,
                                1646,
                                1087,
                                1880,
                                1577,
                                1759,
                                1863,
                                1766,
                                1840,
                                1613,
                                1733,
                                1808,
                                1657,
                                1169,
                                1934,
                                1729,
                                1688,
                                1138,
                                1937,
                                1112,
                                1865,
                                1853,
                                1793,
                                1292,
                                1698,
                                1624,
                                1335,
                                1264,
                                1827,
                                1874,
                                1725,
                                1378,
                                1083,
                                1173,
                                1923,
                                1842,
                                1207,
                                1614,
                                1425,
                                1794,
                                1404,
                                1862};

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

        private static void GetValidPasswordCount_Day2()
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
                var passwordChar = Convert.ToChar(length[1].Split(' ')[1].Replace(":",""));
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

        private static void GetValidPasswordCount_Day2_Part2()
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
                    if(validLowestNumber == increment && word == passwordChar)
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

                keyValues = keyValues.Where(x => x.Value).ToDictionary(p=>p.Key, p=>p.Value);

                counter++;
            }
            Console.WriteLine("Total number of valid password {0}", keyValues.Count);
        }        

    }
}