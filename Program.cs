namespace BecomeADeveloperTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;

            do
            {
                Console.WriteLine("enter path to .txt file");
                path = Console.ReadLine();

            } while (!(!string.IsNullOrEmpty(path) && File.Exists(path) && CheckFileType(path)));

            var strin = File.ReadAllLines(path);
            int[] result = null;

            if (!Ext.IsNullOrEmpty(strin))
            {
                result = ConvertToIntArray(strin);
            }

            if (!result.Equals(null) && result.Length > 0)
            {
                Console.WriteLine("Max number:");
                Console.WriteLine(MaxNum(result));
                Console.WriteLine();
                Console.WriteLine("Min number:");
                Console.WriteLine(MinNum(result));
                Console.WriteLine();
                Console.WriteLine("Average number:");
                Console.WriteLine(Average(result));
                Console.WriteLine();
                Console.WriteLine("Mediana");
                Console.WriteLine(Mediana(result));
                Console.WriteLine();
                Console.WriteLine("Max Seq");
                var rest = MaxSeq(result);

                foreach (var i in rest)
                    Console.WriteLine(i);

                Console.WriteLine();
                Console.WriteLine("Min Seq");
                var resti = MinSeq(result);

                foreach (int i in resti)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static int[] ConvertToIntArray(string[] str)
        {
            var nums = new List<int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i], out int number))
                {
                    nums.Add(number);
                }
            }
            return nums.ToArray();
        }



        public static bool CheckFileType(string path)
        {
            string ext = Path.GetExtension(path);
            switch (ext)
            {
                case ".txt":
                    return true;
                default:
                    return false;
            }
        }

        public static int MaxNum(int[] nums)
        {
            var maxNum = nums[0];

            foreach (int num in nums)
            {
                if (num > maxNum)
                {
                    maxNum = num;
                }
            }
            return maxNum;
        }

        public static int MinNum(int[] nums)
        {
            var minNum = nums[0];

            foreach (int num in nums)
            {
                if (num < minNum)
                {
                    minNum = num;
                }
            }
            return minNum;
        }

        public static double Average(int[] nums)
        {
            long sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }

            return (double)sum / nums.Length;
        }

        public static double Mediana(int[] nums)
        {
            if (nums.Length % 2 == 0)
            {
                return (double)(nums[nums.Length / 2 - 1] + nums[nums.Length / 2]) / 2;
            }
            else
            {
                return (double)nums[nums.Length / 2];
            }
        }

        public static int[] MaxSeq(int[] nums)
        {
            var maxLength = 1;
            var maxStart = 0;
            var curStart = 0;
            var curLength = 1;
            var seq = false;

            for (int i = 1; i < nums.Length; i++)
            {

                if (nums[i] > nums[i - 1] && !seq)
                {
                    curStart = i-1;
                    curLength++;
                    seq = true;
                }
                else if (nums[i] > nums[i - 1] && seq)
                {
                    curLength++;
                }
                else
                {
                    if (maxLength < curLength)
                    {
                        maxLength = curLength;
                        maxStart = curStart;
                    }
                    curLength = 1;
                    curStart = 0;
                    seq = false;
                }
            }

            if(maxLength < curLength )
            {
                maxLength = curLength;
                maxStart = curStart;
            }
            
            var result = nums[maxStart..(maxStart + maxLength)];

            return result;
        }

        public static int[] MinSeq(int[] nums)
        {
            var minLength = 1;
            var minStart = 0;
            var curStart = 0;
            var curLength = 1;
            var seq = false;

            for (int i = 1; i < nums.Length; i++)
            {

                if (nums[i] < nums[i - 1] && !seq)
                {
                    curStart = i - 1;
                    curLength++;
                    seq = true;
                }
                else if (nums[i] < nums[i - 1] && seq)
                {
                    curLength++;
                }
                else
                {
                    if (minLength < curLength)
                    {
                        minLength = curLength;
                        minStart = curStart;
                    }
                    curLength = 1;
                    curStart = 0;
                    seq = false;
                }
            }

            if (minLength < curLength)
            {
                minLength = curLength;
                minStart = curStart;
            }

            var result = nums[minStart..(minStart + minLength)];

            return result;
        }
    }
}
