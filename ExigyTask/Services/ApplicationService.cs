using ExigyTask.Enums;
using ExigyTask.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExigyTask.Services
{
    public class ApplicationService
    {
        public void PlayGame()
        {
            // Read input and create card decks
            while (true)
            {
                try
                {
                    Dictionary<int, List<Card>> cardDecks = new();

                    while (true)
                    {
                        var input = Console.ReadLine();

                        if (input == "#") break;

                        var cards = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < cards.Length; i++)
                        {
                            var strength = cards[i].Substring(0, 1);
                            var suite = cards[i].Substring(1, 1);
                            var card = new Card { Strength = Enum.Parse<Strength>(strength), Suite = Enum.Parse<Suite>(suite) };

                            if (!cardDecks.ContainsKey(i + 1))
                            {
                                var deck = new List<Card>();
                                cardDecks.Add(i + 1, deck);
                            }

                            cardDecks[i + 1].Add(card);
                        }
                    }

                    var currentCard = cardDecks[cardDecks.Count][cardDecks[cardDecks.Count].Count - 1];
                    var currentDeck = cardDecks[cardDecks.Count];
                    currentDeck.Remove(currentCard);
                    var count = 0;

                    // Start dealing cards
                    while (true)
                    {
                        count++;
                        var searchedDeck = cardDecks.Where(x => x.Key == (int)currentCard.Strength).First().Value;
                        var nextCard = searchedDeck[searchedDeck.Count - 1];
                        searchedDeck.Remove(nextCard);

                        if (searchedDeck.Count == 0)
                        {
                            var cardsTurned = count > 9 ? "" + count : "0" + count;

                            string output = (int)currentCard.Strength >= 2 && (int)currentCard.Strength <= 9 ?
                            cardsTurned + "," + (int)currentCard.Strength + "" + currentCard.Suite :
                            cardsTurned + "," + currentCard.Strength + "" + currentCard.Suite;

                            Console.WriteLine(output);
                            break;
                        }

                        currentCard = nextCard;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                   ;
                }
            }
        }
    }
}
