using System;
using System.Collections.Generic;
using CardGameEngine;

public class Program
{
    public static void Main()
    {
        // Создаем игроков
        Player player1 = new Player("Игрок 1");
        Player player2 = new Player("Игрок 2");
        List<Player> players = new List<Player> { player1, player2 };

        // Создаем игру
        Game game = new Game(players);
        game.DealCards(6); // Раздаем по 6 карт каждому игроку

        // Играем до тех пор, пока у одного из игроков не закончится карта
        game.PlayGame();
    }
}