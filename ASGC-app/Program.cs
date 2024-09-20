using System.Diagnostics.Metrics;

namespace ASGC_app
{
    internal class Program
    {
        static string assignments = Console.ReadLine();
        static string quizzes = Console.ReadLine();
        static void Main(string[] args)
        {
            Console.Write("Enter Student's Name: ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter List of Assignment Scores (Example: 25/30 40/40 49/50 5/10 ...): ");
            Console.Write("Enter List of Assignment Scores: ");
            assignments = Console.ReadLine();

            string[] scores = assignments.Split(' ');
            List<double> assignmentsScores = new List<double>();
            foreach (string score in scores)
            {
                string[] nums = score.Trim().Split('/');
                double numScore = double.Parse(nums[0]);
                double numTotal = double.Parse(nums[1]);
                double calculate = (numScore / numTotal) * 100;
                assignmentsScores.Add(calculate);

            }

            Console.WriteLine("Enter List of Quizzes Scores (Example: 25/30 40/40 49/50 5/10 ...): ");
            Console.Write("Enter Quiz Scores: ");
            quizzes = Console.ReadLine();

            string[] scoresQuizzes = quizzes.Split(' ');
            List<double> quizzesScores = new List<double>();
            foreach (string score in scoresQuizzes)
            {
                string[] nums = score.Trim().Split('/');
                double numScore = double.Parse(nums[0]);
                double numTotal = double.Parse(nums[1]);
                double calculate = (numScore / numTotal) * 100;
                quizzesScores.Add(calculate);

            }

            Console.Write("Enter Final Exam Score (Example: 79/80): ");
            string scoreFinalExam = Console.ReadLine();
            string[] finalExamScore = scoreFinalExam.Split('/');
            double finalExamScores = double.Parse(finalExamScore[0]) / double.Parse(finalExamScore[1]) * 100;

            DisplayStudentReport(studentName, assignmentsScores, quizzesScores, finalExamScores);
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
            Console.WriteLine(assignments);
            Console.WriteLine();
            Console.Write($"Quizzes Scores:");
            Console.WriteLine(quizzes);
            Console.WriteLine();
            Console.WriteLine($"Final Exam Score: {finalExamScore}");
            Console.WriteLine($"Weighted Average: {weightedAverageScore}");
            Console.WriteLine($"Letter Grade: {LetterGrade}");
        }
    }
}