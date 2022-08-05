using System;

namespace Game
{
    public struct MathOperator
    {
        public int FirstNumber;
        public int SecondNumber;
        public int Operator;
    }

    public enum LevelStatus
    {
        InProgress = 1,
        Promoted = 2,
        GameOver = 3,
    }

    class Program
    {

        public static MathOperator GetNextNumber(int levelNumber)
        {
            Random myRandom = new Random();
            MathOperator CurrentNumbers;

            CurrentNumbers.FirstNumber = myRandom.Next(0, 20);
            CurrentNumbers.SecondNumber = myRandom.Next(0, 20);
            CurrentNumbers.Operator = myRandom.Next(1, 2);

            switch (levelNumber)
            {
                case 1:
                    CurrentNumbers.FirstNumber = myRandom.Next(0, 10);
                    CurrentNumbers.SecondNumber = myRandom.Next(0, 10);
                    CurrentNumbers.Operator = 1;
                    break;
                case 2:
                    CurrentNumbers.FirstNumber = myRandom.Next(0, 20);
                    CurrentNumbers.SecondNumber = myRandom.Next(0, 20);
                    CurrentNumbers.Operator = myRandom.Next(1, 2);
                    break;
                case 3:
                    CurrentNumbers.FirstNumber = myRandom.Next(0, 20);
                    CurrentNumbers.SecondNumber = myRandom.Next(0, 20);
                    CurrentNumbers.Operator = myRandom.Next(1, 3);
                    break;
                case 4:
                    CurrentNumbers.FirstNumber = myRandom.Next(0, 30);
                    CurrentNumbers.SecondNumber = myRandom.Next(0, 30);
                    CurrentNumbers.Operator = myRandom.Next(1, 3);
                    break;
                case 5:
                    CurrentNumbers.FirstNumber = myRandom.Next(0, 50);
                    CurrentNumbers.SecondNumber = myRandom.Next(0, 50);
                    CurrentNumbers.Operator = myRandom.Next(1, 3);
                    break;
            }

            
            return CurrentNumbers;
        }

        public static bool CheckResult(MathOperator CurrentNumbers , int Result)
        {
            bool IsRightAnswer = false;
            switch (CurrentNumbers.Operator)
            {
                case 1:
                    IsRightAnswer = (Result == CurrentNumbers.FirstNumber + CurrentNumbers.SecondNumber);
                    break;
                case 2:
                    IsRightAnswer = (Result == CurrentNumbers.FirstNumber - CurrentNumbers.SecondNumber);
                    break;
                case 3:
                    IsRightAnswer = (Result == CurrentNumbers.FirstNumber * CurrentNumbers.SecondNumber);
                    break;
            }
            return IsRightAnswer;
        }

        public static void CheckAnswerCount (int rightCount , int WrongCount , out LevelStatus status)
        {
            status = LevelStatus.InProgress;
            if (rightCount == 5)
            {
                Console.WriteLine("Level Promoted");
                status = LevelStatus.Promoted;
            }

            if (WrongCount == 3)
            {
                Console.WriteLine("Game Over");
                status = LevelStatus.GameOver;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Math Operator Test");

            char exit = 'a';
       
            int RightAnswer = 0;
            int WrongAnswer = 0;
            int LevelNumber = 1;

            while (exit != 'e')
            {
                MathOperator CurrentNumbers = GetNextNumber(LevelNumber);
                bool IsRightAnswer = false;

                Console.WriteLine($"First Number: {CurrentNumbers.FirstNumber}, Second Number: {CurrentNumbers.SecondNumber}, Operator Is {CurrentNumbers.Operator}, Level Is {LevelNumber}");

                Console.WriteLine("**********************************");
                Console.WriteLine("Please Enter Result");


                int Result = Convert.ToInt32(Console.ReadLine());

                IsRightAnswer = CheckResult(CurrentNumbers, Result);

                if (IsRightAnswer)
                {
                    RightAnswer++;
                    Console.WriteLine("Right Answer ");
                }
                    
                else
                {
                    WrongAnswer--;
                    Console.WriteLine("Wrong Answer");
                }

                LevelStatus status;
                CheckAnswerCount(RightAnswer, WrongAnswer, out status);

                if (status == LevelStatus.GameOver)
                    break;
                else if (status == LevelStatus.Promoted)
                {
                    LevelNumber++;
                    RightAnswer = 0;
                }
                    

                Console.WriteLine("Please Enter 'e' For Exit or Press Any Key To Continue");
                exit = Convert.ToChar( Console.ReadLine() );
            }
        }
    }
}
