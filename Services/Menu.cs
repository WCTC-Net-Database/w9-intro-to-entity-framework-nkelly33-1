﻿namespace W9_assignment_template.Services;

public class Menu
{
    private readonly GameEngine _gameEngine;

    public Menu(GameEngine gameEngine)
    {
        _gameEngine = gameEngine;
    }

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("1. Display Rooms");
            Console.WriteLine("2. Display Characters");
            Console.WriteLine("3. Exit");
            Console.WriteLine("4. Add Room");
            Console.WriteLine("5. Add Character");
            Console.WriteLine("6. Find Character");
            Console.WriteLine("7. Update Character Level");

            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _gameEngine.DisplayRooms();
                    break;
                case "2":
                    _gameEngine.DisplayCharacters();
                    break;
                case "3":
                    return;
                case "4":
                    _gameEngine.AddRoom();
                    break;
                case "5":
                    _gameEngine.AddCharacter();
                    break;
                case "6":
                    _gameEngine.FindCharacter();
                    break;
                case "7":
                    _gameEngine.UpdateCharacterLevel();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

}