using System;
using System.Collections.Generic;

namespace CardGameEngine;

public class Deck
{
    private List<Card> _cards;

    public Deck()
    {
        _cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }

    // Добавление свойства Count, чтобы можно было получить количество оставшихся карт
    public int Count => _cards.Count;

    public void Shuffle()
    {
        Random rand = new Random();
        int n = _cards.Count;
        while (n > 1)
        {
            int k = rand.Next(n--);
            Card temp = _cards[n];
            _cards[n] = _cards[k];
            _cards[k] = temp;
        }
    }

    public Card DrawCard()
    {
        if (_cards.Count > 0)
        {
            Card card = _cards[_cards.Count - 1];
            _cards.RemoveAt(_cards.Count - 1);
            return card;
        }
        throw new InvalidOperationException("Колода пуста.");
    }

    public void DealCards(List<Player> players, int cardsPerPlayer)
    {
        for (int i = 0; i < cardsPerPlayer; i++)
        {
            foreach (var player in players)
            {
                if (_cards.Count > 0)
                {
                    player.Draw(this);
                }
                else
                {
                    throw new InvalidOperationException("Недостаточно карт в колоде для раздачи.");
                }
            }
        }
    }
}