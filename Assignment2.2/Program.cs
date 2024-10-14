using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Assignment2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            List<Worker> members = new List<Worker>();
            List<Team> teams = new List<Team>();

            bool run = true;

            while (run)
            {
                if (teams.Count > 0)
                    Console.WriteLine();

                Console.Write("Чи бажаєте створити нову команду (так/ні): ");
                string yesOrNo = GetValidAnswerString(["так", "ні"]);
                if (yesOrNo == "ні")
                {
                    run = false;
                    break;
                }
                else
                {
                    Console.Write("Дайте назву новій команді: ");
                    string teamName = GetValidAnswerString();
                    Console.WriteLine();
                    members = CreateNewMembers(teamName);
                    teams.Add(new Team(teamName, members));
                    Console.WriteLine();
                    teams[teams.Count - 1].TeamInfo();
                    Console.WriteLine();
                }
            }

            if (teams.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Бувайте!");
            }
            else
            {
                foreach (Team team in teams)
                {
                    if (team.Members.Count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"У команді {team.TeamName} робота кипить таким чином: ");
                        foreach (Worker member in team.Members)
                        {
                            member.FillWorkDay();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"У команді {team.TeamName} робота не кипить, бо ви поки не додали туди учасників.");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Бувайте!");
            }
        }

        private static List<Worker> CreateNewMembers(string teamName)
        {
            List<Worker> createdMembers = new List<Worker>();
            Console.Write($"Чи бажаєте додати нового члена для команди \"{teamName}\" (так/ні): ");
            string yesOrNo = GetValidAnswerString(["так", "ні"]);

            if (yesOrNo == "ні")
                return createdMembers;
            else
            {
                while (yesOrNo == "так")
                {
                    Console.Write("Введіть тип працівника (розробник/менеджер): ");
                    string workerType = GetValidAnswerString(["розробник", "розробниця", "менеджер", "менеджерка"]);

                    Console.Write("Введіть ім'я працівника: ");
                    string workerName = Console.ReadLine();

                    Console.Write("Введіть кількість робочих годин працівника: ");
                    double workDay = GetValidAnswerDouble();

                    if (workerType == "розробник" || workerType == "розробниця")
                        createdMembers.Add(new Developer(workerName, workDay));
                    else
                        createdMembers.Add(new Manager(workerName, workDay));

                    Console.WriteLine();
                    Console.Write($"Чи бажаєте додати нового члена для команди \"{teamName}\" (так/ні): ");
                    yesOrNo = GetValidAnswerString(["так", "ні"]);
                }
            }

            return createdMembers;
        }

        private static string GetValidAnswerString()
        {
            bool isValid = true;
            string result = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(result))
                return result;
            else
            {
                while (string.IsNullOrWhiteSpace(result))
                {
                    Console.Write("Попередня відповідь некоректна! Спробуйте ще раз: ");
                    result = Console.ReadLine();
                }
            }

            return result;
        }
        private static string GetValidAnswerString(string[] awaitingAnswers)
        {
            string result = Console.ReadLine().ToLower();
            bool isValid = awaitingAnswers.Any(potentialAnswer => potentialAnswer == result);

            if (isValid)
                return result;
            else
            {
                while (!isValid)
                {
                    Console.Write("Попередня відповідь некоректна! Спробуйте ще раз: ");
                    result = Console.ReadLine().ToLower();
                    isValid = awaitingAnswers.Any(potentialAnswer => potentialAnswer == result);
                }
            }

            return result;
        }
        private static double GetValidAnswerDouble()
        {
            double result = 0;
            bool isValid = true;
            string answer = Console.ReadLine();

            if (double.TryParse(answer, out result))
            {
                isValid = double.TryParse(answer, out result);
                return result;
            }
            else
            {
                while (!isValid)
                {
                    Console.Write("Попередня відповідь некоректна! Спробуйте ще раз: ");
                    answer = Console.ReadLine();
                    isValid = double.TryParse(answer, out result);
                }
            }

            return result;
        }
    }
}
    
