using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }
    public int PlayerId { get; set; }
    public int PlayerAge { get; set; }
}

public interface ITeam
{
    void Add(Player player);
    void Remove(int playerId);
    Player GetPlayerById(int playerId);
    Player GetPlayerByName(string playerName);
    List<Player> GetAllPlayers();
}

public class OneDayTeam : ITeam
{
    public static List<Player> oneDayTeam = new List<Player>();

    public OneDayTeam()
    {
        // Set the capacity property to 11
        oneDayTeam.Capacity = 11;
    }

    public void Add(Player player)
    {

        if (oneDayTeam.Count < 11)
        {
            oneDayTeam.Add(player);
            Console.WriteLine("Player is added successfully");
        }
        else
        {
            Console.WriteLine("Cannot add more than 11 players to the team");
        }
    }

    public void Remove(int playerId)
    {

        Player playerToRemove = oneDayTeam.Find(p => p.PlayerId == playerId);
        if (playerToRemove != null)
        {
            oneDayTeam.Remove(playerToRemove);
            Console.WriteLine("Player removed successfully");
        }
        else
        {
            Console.WriteLine("Player not found");
        }
    }

    public Player GetPlayerById(int playerId)
    {
        // Implement functionality to get player by passing Player Id as a parameter
        return oneDayTeam.Find(p => p.PlayerId == playerId);
    }

    public Player GetPlayerByName(string playerName)
    {

        return oneDayTeam.Find(p => p.Name == playerName);
    }

    public List<Player> GetAllPlayers()
    {

        return oneDayTeam;
    }
}

class Program
{
    static void Main()
    {
        OneDayTeam team = new OneDayTeam();


        string choice;
        do
        {
            Console.WriteLine("Enter 1: To Add Player 2: To Remove Player by Id 3: Get Player By Id 4: Get Player by Name 5: Get All Players");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:

                    Console.WriteLine("Enter Player Id:");
                    int playerId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Player Name:");
                    string playerName = Console.ReadLine();
                    Console.WriteLine("Enter Player Age:");
                    int playerAge = Convert.ToInt32(Console.ReadLine());
                    Player newPlayer = new Player { PlayerId = playerId, Name = playerName, PlayerAge = playerAge };
                    team.Add(newPlayer);
                    break;

                case 2:

                    Console.WriteLine("Enter Player Id to remove:");
                    int removePlayerId = Convert.ToInt32(Console.ReadLine());
                    team.Remove(removePlayerId);
                    break;

                case 3:

                    Console.WriteLine("Enter Player Id:");
                    int getPlayerById = Convert.ToInt32(Console.ReadLine());
                    Player playerById = team.GetPlayerById(getPlayerById);
                    Console.WriteLine($"Player: {playerById.Name}, Age: {playerById.PlayerAge}");
                    break;

                case 4:

                    Console.WriteLine("Enter Player Name:");
                    string getPlayerByName = Console.ReadLine();
                    Player playerByName = team.GetPlayerByName(getPlayerByName);
                    Console.WriteLine($"Player: {playerByName.Name}, Age: {playerByName.PlayerAge}");
                    break;

                case 5:

                    List<Player> allPlayers = team.GetAllPlayers();
                    foreach (var player in allPlayers)
                    {
                        Console.WriteLine($"Player: {player.Name}, Age: {player.PlayerAge}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            Console.WriteLine("Do you want to continue (yes/no)?:");
            choice = Console.ReadLine();

        } while (choice.ToLower() == "yes");
    }
}