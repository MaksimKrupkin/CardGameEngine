using System;
using System.Collections.Generic;

namespace CardGameEngine;
public enum Suit
{
    Diamonds,
    Hearts,
    Spades,
    Clubs
};
public enum Rank
{
    Ace = 14,
    King = 13,
    Queen = 12,
    Jack = 11,
    Ten = 10,
    Nine = 9,
    Eight = 8,
    Seven = 7,
    Six = 6
};

public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
