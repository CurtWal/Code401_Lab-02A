using System;

namespace labA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Welcome the user to the game
                Console.WriteLine("Welcome to my game! Let's do some math!");
                // Call the `StartSequence()` method from `Main`
                StartSequence();
            }
            catch (Exception e)
            {
                // let the user know if any errors occured
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Game Over! Program Complete!");
            }
        }
        public static void StartSequence()
        {
            try
            {

                // ask the user to enter a number that is grater then 0
                Console.WriteLine("Enter a number greater then zero!");
                // let what ever the user input (number) be the size of the array
                int userNum = Convert.ToInt32(Console.ReadLine());
                int[] userNumbers = new int[userNum];
                // using the number the user sets populate the array with the numbers they enter
                userNumbers = Populate(userNum, userNumbers);

                //  get the sum of the numbers the user inputs
                int sum = GetSum(userNumbers);
                //  get the product of the numbers the user inputs
                int[] product = GetProduct(userNumbers, sum);
                decimal[] quotient = GetQuotient(product[0]);
                Console.WriteLine($@"Your array size is: {userNumbers.Length}
 					The numbers in the array are: {String.Join(",", userNumbers)}
  					The sum of the array is {sum}
    				{sum} * {userNumbers[product[1] - 1]} = {product[0]}
     				{product[0]} / {quotient[1]} = {quotient[0]}");

            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            static int[] Populate(int userNum, int[] userNumbers)
            {
                // loop through the array size the user set
                for (int i = 0; i < userNum; i++)
                {
                    // Tell the user to enter their numbers
                    //  start the user count at 1 out of the array size 
                    Console.WriteLine($"Please enter a number: {i + 1}/{userNum}");
                    int newNum = Convert.ToInt32(Console.ReadLine());
                    userNumbers[i] = newNum;
                }
                return userNumbers;
            }
        }
        static int GetSum(int[] userNumbers)
        {
            int sum = 0;

            foreach (int num in userNumbers)
            {
                sum += num;
            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low.");
            }
            return sum;
        }
        static int[] GetProduct(int[] userNumbers, int sum)
        {
            try
            {
                // Ask the user to select a number between 1 and the the size of the array they set
                Console.WriteLine($"Select a random number between 1 and {userNumbers.Length}");
                int randomNum = Convert.ToInt32(Console.ReadLine());

                int product = (sum * userNumbers[randomNum - 1]);
                int[] productAndRand = { product, randomNum };
                return productAndRand;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }
        static decimal[] GetQuotient(int product)
        {
            //Ask the user to enter a number to divide with
            Console.WriteLine($"Please enter a number to divide your product {product} by: ");
            int divideBy = Convert.ToInt32(Console.ReadLine());
            while (divideBy == 0)
            {
                Console.WriteLine($"Please enter a number to divide your product {product} by: ");
            }

            decimal quotient = Decimal.Divide((decimal)product, (decimal)divideBy);
            decimal[] quotientAndDivideBy = { quotient, divideBy };
            return quotientAndDivideBy;
        }
    }
}