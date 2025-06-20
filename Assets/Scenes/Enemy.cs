using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Enemy : AbstractPlayer
{
    //The value that will offset the seconds it takes for an enemy to play a card
    public int costAdjust {get; private set;}

    //2 arg constuctor that set name to "Enemy"
    public Enemy(List<AbstractCard> deck, int maxHealth, int costAdjust) : base(deck, maxHealth){
        this.costAdjust = costAdjust;
        name = "Enemy";
    }

    int num = 0;
    int cost = 0;
    //Randomly selects a card in the enemy deck, plays it, and returns the amount of seconds until the next enemy turn
    //If the deck runs low on cards, the discardpile is shuffled back into the deck
    public int trySomething(){
        if(deck.Count <= 1){
            deck.AddRange(discardPile);
            discardPile = new List<AbstractCard>();
        }
        num = rand.Next(0, deck.Count);
        cost = deck[num].COST;
        deck[num].use(this);
        discardPile.Add(deck[num]);
        deck.RemoveAt(num);
        return cost;
    }
}
