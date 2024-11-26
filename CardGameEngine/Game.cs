using System;
using System.Collections.Generic;
using System.Linq;
using CardGameEngine;
namespace CardGameEngine;

 public class Game
    {
        private Deck _deck;
        private List<Player> _players;

        public Game(List<Player> players)
        {
            _deck = new Deck();
            _deck.Shuffle();
            _players = players;
        }

        public void DealCards(int cardsPerPlayer)
        {
            _deck.DealCards(_players, cardsPerPlayer);
        }

        public void PlayGame()
        {
            while (_players[0].Hand.Count > 0 && _players[1].Hand.Count > 0)
            {
                Console.WriteLine("\nНовый раунд!");

                // Если у одного из игроков меньше 6 карт, он набирает карты до 6, если колода не пуста
                foreach (var player in _players)
                {
                    while (player.Hand.Count < 6 && _deck.Count > 0)
                    {
                        player.Draw(_deck);
                    }
                }

                // Если оба игрока не могут набрать карты, то игра завершается
                if (_deck.Count == 0 && (_players[0].Hand.Count < 6 || _players[1].Hand.Count < 6))
                {
                    Console.WriteLine("Колода пуста, игра завершена.");
                    break; // Завершаем игру, так как колода пуста и игроки не могут продолжать
                }

                PlayRound();

                if (_players[0].Hand.Count == 0 || _players[1].Hand.Count == 0)
                {
                    break; // Окончание игры, если у одного из игроков закончились карты
                }
            }

            // Определение победителя
            if (_players[0].Hand.Count == 0)
            {
                Console.WriteLine($"{_players[0].Name} победил!");
            }
            else
            {
                Console.WriteLine($"{_players[1].Name} победил!");
            }
        }

        private void PlayRound()
        {
            List<Card> playedCards = new List<Card>();
            Card cardPlayer1 = _players[0].PlayCard();
            playedCards.Add(cardPlayer1);
            Console.WriteLine($"{_players[0].Name} сыграл: {cardPlayer1}");

            // Игрок 2 отбивается, если может
            if (_players[1].CanDefend(cardPlayer1))
            {
                _players[1].Defend(cardPlayer1);
                Console.WriteLine($"{_players[1].Name} отбил карту.");
            }
            else
            {
                // Игрок 2 забирает карту игрока 1
                _players[1].TakeCard(cardPlayer1);
                Console.WriteLine($"{_players[1].Name} забрал карту.");
            }

            // Ход игрока 2
            Card cardPlayer2 = _players[1].PlayCard();
            playedCards.Add(cardPlayer2);
            Console.WriteLine($"{_players[1].Name} сыграл: {cardPlayer2}");

            // Игрок 1 отбивается, если может
            if (_players[0].CanDefend(cardPlayer2))
            {
                _players[0].Defend(cardPlayer2);
                Console.WriteLine($"{_players[0].Name} отбил карту.");
            }
            else
            {
                // Игрок 1 забирает карту игрока 2
                _players[0].TakeCard(cardPlayer2);
                Console.WriteLine($"{_players[0].Name} забрал карту.");
            }
        }
    }