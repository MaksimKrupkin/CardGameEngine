using System;
using System.Collections.Generic;
namespace CardGameEngine;

    
public class Player
{
    public string Name { get; }
    public List<Card> Hand { get; }

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }

    public void Draw(Deck deck)
    {
        Card card = deck.DrawCard();
        Hand.Add(card);
    }

    public string ShowHand()
    {
        return string.Join(" | ", Hand);
    }

    public Card PlayCard()
    {
        if (Hand.Count > 0)
        {
            Card card = Hand[0]; // Берем первую карту
            Hand.RemoveAt(0); // Удаляем её из руки
            return card;
        }
        throw new InvalidOperationException($"{Name} не может сыграть, так как у него нет карт.");
    }

    public bool CanDefend(Card card)
    {
        // Проверяем, есть ли у игрока карта той же масти с более высоким рангом
        foreach (var handCard in Hand)
        {
            if (handCard.Suit == card.Suit && (int)handCard.Rank > (int)card.Rank) // Приведение Rank к int
            {
                return true;
            }
        }
        return false;
    }

    public void Defend(Card card)
    {
        // Игрок отбивает карту, удаляя её из руки
        for (int i = 0; i < Hand.Count; i++)
        {
            if (Hand[i].Suit == card.Suit && (int)Hand[i].Rank > (int)card.Rank) // Приведение Rank к int
            {
                Hand.RemoveAt(i);
                break;
            }
        }
    }

    public void TakeCard(Card card)
    {
        Hand.Add(card);
    }
}