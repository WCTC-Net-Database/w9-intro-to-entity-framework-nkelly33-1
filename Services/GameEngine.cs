using Microsoft.EntityFrameworkCore;
using W9_assignment_template.Data;
using W9_assignment_template.Models;

namespace W9_assignment_template.Services;

public class GameEngine
{
    private readonly GameContext _context;

    public GameEngine(GameContext context)
    {
        _context = context;
    }

    public void DisplayRooms()
    {
        var rooms = _context.Rooms.Include(r => r.Characters).ToList();

        foreach (var room in rooms)
        {
            Console.WriteLine($"Room: {room.Name} - {room.Description}");
            foreach (var character in room.Characters)
            {
                Console.WriteLine($"    Character: {character.Name}, Level: {character.Level}");
            }
        }
    }

    public void DisplayCharacters()
    {
        var characters = _context.Characters.ToList();
        if (characters.Any())
        {
            Console.WriteLine("\nCharacters:");
            foreach (var character in characters)
            {
                Console.WriteLine($"Character ID: {character.Id}, Name: {character.Name}, Level: {character.Level}, Room ID: {character.RoomId}");
            }
        }
        else
        {
            Console.WriteLine("No characters available.");
        }
    }
    public void AddRoom()
    {
        Console.Write("Enter room name: ");
        var name = Console.ReadLine();

        Console.Write("Enter room description: ");
        var description = Console.ReadLine();

        var room = new Room
        {
            Name = name,
            Description = description
        };

        _context.Rooms.Add(room);
        _context.SaveChanges();

        Console.WriteLine($"Room '{name}' added to the game.");
    }
    public void AddCharacter()
    {
        Console.Write("Enter character name: ");
        var name = Console.ReadLine();

        Console.Write("Enter character level: ");
        var level = int.Parse(Console.ReadLine());

        Console.Write("Enter room ID for the character: ");
        var roomId = int.Parse(Console.ReadLine());

        // Find the room by ID
        var room = _context.Rooms.Find(roomId);
        if (room == null)
        {
            Console.WriteLine($"Room with ID {roomId} does not exist.");
            return;
        }

        // Create a new character and add it to the room
        var character = new Character
        {
            Name = name,
            Level = level,
            RoomId = roomId
        };

        _context.Characters.Add(character);
        _context.SaveChanges();

        Console.WriteLine($"Character '{name}' added to room '{room.Name}'.");
    }
    public void FindCharacter()
    {
        Console.Write("Enter character name to search: ");
        var name = Console.ReadLine();

        // TODO Find the character by name
        // Use LINQ to query the database for the character
        // If the character exists, display the character's information
        // Otherwise, display a message indicating the character was not found
        var character = _context.Characters
            .FirstOrDefault(c => c.Name.ToLower() == name.ToLower());

        if (character != null)
        {
            Console.WriteLine($"Character found: ID: {character.Id}, Name: {character.Name}, Level: {character.Level}, Room ID: {character.RoomId}");
        }
        else
        {
            Console.WriteLine($"Character '{name}' not found.");
        }
    }
    public void UpdateCharacterLevel()
    {
        Console.Write("Enter character ID to update: ");
        var id = int.Parse(Console.ReadLine());

        var character = _context.Characters.Find(id);
        if (character == null)
        {
            Console.WriteLine($"Character with ID {id} does not exist.");
            return;
        }
        Console.Write("Enter new level for the character: ");
        var newLevel = int.Parse(Console.ReadLine());

        character.Level = newLevel;
        _context.SaveChanges();
        Console.WriteLine($"Character '{character.Name}' updated to level {newLevel}.");
    }
}