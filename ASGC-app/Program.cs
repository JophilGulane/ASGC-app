using System.Diagnostics.Metrics;

namespace ASGC_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Student's Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter List of Assignment Scores: ");
            Console.WriteLine("Example: 1 2 3 4 5...");
            Console.Write("Enter List of Assignment Scores: ");
            string assignments = Console.ReadLine();
            List<double> assignmentsScores = assignments.Split(' ').Select(double.Parse).ToList();

            Console.Write("Enter Quiz Scores: ");
            Console.WriteLine("Example: 1 2 3 4 5...");
            Console.Write("Enter Quiz Scores: ");
            string quizzes = Console.ReadLine();
            List<double> quizzesScores = quizzes.Split(' ').Select(double.Parse).ToList();

            Console.Write("Enter Final Exam Score: ");
            int finalExamScore = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateWeightedAverage(assignmentsScores, quizzesScores, finalExamScore));
        }

        static double CalculateWeightedAverage(List<double> assignmentScores, List<double> quizzesScores, double finalExamScore)
        {
            double assignmentWeight = 0.30;
            double quizzesWeight = 0.20;
            double finalExamWeight = 0.50;

            double assignmentAverage = assignmentScores.Average();
            double quizzesAverage = quizzesScores.Average();
            double weightedAverageScore = (assignmentWeight * assignmentAverage) + (quizzesWeight * quizzesAverage) + (finalExamWeight * finalExamScore);
            Console.WriteLine($"Assignment Average: {assignmentAverage}, Quizzes Average: {quizzesAverage}, Final Exam Score: {finalExamScore}");
            return weightedAverageScore;
        }

        static char AssignLetterGrade()
        {
            return 'a';
        }

        static void DisplayStudentReport()
        {

        }
    }


}
