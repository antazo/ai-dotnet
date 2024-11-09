using Microsoft.AspNetCore.Mvc;

namespace azure.Controllers
{
    public class GameController : Controller
    {
        public static Dictionary<string, int> switcher = new Dictionary<string, int>
        {
            { "rock", 0 },
            { "paper", 1 },
            { "scissors", 2 },
            { "lizard", 3 },
            { "spock", 4 }
        };

        public static int[,] rules = new int[,]
        {
            { 0, -1, 1, 1, -1 },
            { 1, 0, -1, -1, 1 },
            { -1, 1, 0, 1, -1 },
            { -1, 1, -1, 0, 1 },
            { 1, -1, 1, -1, 0 }
        };

        public static int toNumericalChoice(string choice)
        {
            return switcher[choice];
        }

        public static string play(string choicePlayer, string choiceEnemy)
        {
            int player_num = toNumericalChoice(choicePlayer);
            int enemy_num = toNumericalChoice(choiceEnemy);

            if (rules[player_num, enemy_num] == 1)
            {
                return "You WIN!";
            }
            else if (rules[player_num, enemy_num] == -1)
            {
                return "You lose!";
            }
            else
            {
                return "It's a tie!";
            }
        }
        public IActionResult Rockpaperscissors(string name = "visitor")
        {
            
            var choices = switcher.Keys.ToList();

            string choicePlayer = Request.Query.ContainsKey("choice") ? Request.Query["choice"].ToString().ToLower() : "";
            string choiceEnemy = choices[new Random().Next(choices.Count)];
            
            string result = "";
            if (choicePlayer != "")
            {
                result = play(choicePlayer, choiceEnemy);
            }
            ViewData["choices"] = choices;
            ViewData["choicePlayer"] = choicePlayer;
            ViewData["choiceEnemy"] = choiceEnemy;
            ViewData["result"] = result;
            ViewData["Name"] = name;
            return View();
        }
    }
}