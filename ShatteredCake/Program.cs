using System;

namespace ShatteredCake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = EnterInteger("width");

            int piecesCounts = EnterInteger("counts");

            Object[] myInputs = GetTwoArrays(piecesCounts);
            int[] smallLengthes = (int[])myInputs[0];
            int[] smallWidthes = (int[])myInputs[1];


            double bigLen =
                    CalculateMissingSide(smallLengthes, smallWidthes, cakeWidth);

            Console.WriteLine((int)bigLen);
        }
        private static Object[] GetTwoArrays(int counter)
        {
            Object[] results = new Object[2];

            int[] smallLengthes = new int[counter];
            int[] smallWidthes = new int[counter];
            int[] temp = new int[2];

            for (int i = 0; i < counter; i++)
            {
                temp = EnterTwoInt();
                smallWidthes[i] = temp[0];
                smallLengthes[i] = temp[1];
            }

            results[0] = smallLengthes;
            results[1] = smallWidthes;
            return results;
        }

        private static double CalculateMissingSide(int[] lens, int[] weds, int side)
        {
            int theWholeArea = SumOfAllSmallAreas(lens, weds);
            return CalculateSideLen(theWholeArea, side);
        }

        private static double CalculateSideLen(int area, int anotherSide)
        {
            return (double)area / anotherSide;
        }

        private static int SumOfAllSmallAreas(int[] lengthes, int[] widthes)
        {
            int sum = 0;
            int tempRes = 0;
            for (int i = 0; i < lengthes.Length; i++)
            {
                tempRes = AreaCalculate(lengthes[i], widthes[i]);
                sum = sum + tempRes;
            }
            return sum;
        }

        private static int AreaCalculate(int length, int width)
        {
            return length * width;
        }

        private static int[] EnterTwoInt()
        {
            int[] res = new int[2];
            res[0] = 0;
            res[1] = 0;
            String str;
            String[] ans = new String[2];
            ans[0] = " ";
            ans[1] = " ";

            try
            {
                str = Console.ReadLine();
                ans = str.Split(" ", 2);
                res[0] = int.Parse(ans[0]);
                res[1] = int.Parse(ans[1]);
                if (!CheckDimension(res[0]) || !CheckDimension(res[1]))
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return EnterTwoInt();
            }
            return res;
        }


        private static int EnterInteger(String str)
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (str.ToLower().Equals("counts"))
                {
                    if (a <= 0 || a > 5000000)
                        throw new ArgumentException();
                }
                else
                    if (!str.ToLower().Equals("counts"))
                {
                    if (!CheckDimension(a))
                        throw new ArgumentException();
                }
                return a;
            }
            catch (Exception ex)
            {
                return EnterInteger(str);
            }
        }
        private static bool CheckDimension(int number)
        {
            if (number <= 0 || number > 1000)
                return false;
            else return true;
        }
    }
}
