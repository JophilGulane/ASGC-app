using System.Diagnostics.Metrics;

namespace ASGC_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Student's Name: ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter List of Assignment Scores (Example: 1 2 3 4 5...): ");
            Console.Write("Enter List of Assignment Scores: ");
            string assignments = Console.ReadLine();
            List<double> assignmentsScores = assignments.Split(' ').Select(double.Parse).ToList();

            Console.WriteLine("Enter List of Quizzes Scores (Example: 1 2 3 4 5...): ");
            Console.Write("Enter Quiz Scores: ");
            string quizzes = Console.ReadLine();
            List<double> quizzesScores = quizzes.Split(' ').Select(double.Parse).ToList();

            Console.Write("Enter Final Exam Score: ");
            double finalExamScore = int.Parse(Console.ReadLine());

            DisplayStudentReport(studentName, assignmentsScores, quizzesScores, finalExamScore);
        }

        static double CalculateWeightedAverage(List<double> assignmentScores, List<double> quizzesScores, double finalExamScore)
        {
            double assignmentWeight = 0.30;
            double quizzesWeight = 0.20;
            double finalExamWeight = 0.50;

            double assignmentAverage = assignmentScores.Average();
            double quizzesAverage = quizzesScores.Average();
            double weightedAverageScore = (assignmentWeight * assignmentAverage) + (quizzesWeight * quizzesAverage) + (finalExamWeight * finalExamScore);
            return weightedAverageScore;
        }

        static char AssignLetterGrade(double weightedAverageScore)
        {
            if (weightedAverageScore >= 90 && weightedAverageScore <= 100)
            {
                return 'A';
            }
            else if (weightedAverageScore >= 80)
            {
                return 'B';
            }
            else if (weightedAverageScore >= 70)
            {
                return 'C';
            }
            else if (weightedAverageScore >= 60)
            {
                return 'D';
            }
            else 
            {
                return 'F';
            }
        }

        static void DisplayStudentReport(string studentName, List<double> assignmentScores, List<double> quizzesScores, double finalExamScore)
        {
            double weightedAverageScore = CalculateWeightedAverage(assignmentScores, quizzesScores, finalExamScore);

            char LetterGrade = AssignLetterGrade(weightedAverageScore);
            Console.WriteLine();
            Console.WriteLine($"Student's Name: {studentName}");
            Console.Write($"Assignment Scores:");
            foreach (var i in assignmentScores) Console.Write(i.ToString() + " ");
            Console.WriteLine();
            Console.Write($"Quizzes Scores:");
            foreach (var i in quizzesScores) Console.Write(i.ToString() + " ");
            Console.WriteLine() ;
            Console.WriteLine($"Final Exam Score: {finalExamScore}");
            Console.WriteLine($"Weighted Average: {weightedAverageScore}");
            Console.WriteLine($"Letter Grade: {LetterGrade}");
        }
    }
}
