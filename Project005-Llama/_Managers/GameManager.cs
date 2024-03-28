/* RULES SUMMARY
https://boardgamegeek.com/boardgame/266083/llm

Deck of cards - values 1 to 6 and Llama (worth 10 points) - eight copies of each.
Each player is dealt 6 cards.
Players take turns:
 - play a card, same value or one higher
 - draw a card
 - quit, take no further actions in the round
The aim is to get rid of all cards from hand.
The round ends when one player empties their hand or all players have quit.
When round ends, each player gets penalty points based on cards in hand.
The game ends at the end of the round where at least one player has forty or more total points.
Whoever has the fewest points wins!
*/

/* ANALYSIS
 - card - value
 - deck - cards, shuffle, dealing cards
 - player
   - hand of cards
   * penalty points counter
 - AI for the other players
   - number of cards in player's hands
 * UI to show scores
 - Input
   - mouse input, clicking
   - button to draw from the deck
   * button to quit a round
   - selecting a card to play
 - Game states
   - player's turn
   - AI's turn
*/

namespace Project005;

public class GameManager
{
    private readonly Deck _deck;
    private readonly Player _player;
    private readonly AIPlayer _ai;
    private bool _playersTurn;
    private bool _playerWon;
    private bool _aiWon;

    public GameManager()
    {
        FontWriter.Initialize();

        _deck = new();
        _player = new();
        _ai = new();

        Reset();

        _deck.OnClick += DeckClickHandler;
        _player.OnPlayCard += HandCardClickHandler;
    }

    public void Reset()
    {
        Random r = new();
        _playersTurn = r.Next(0, 2) == 1;
        _playerWon = false;
        _aiWon = false;

        _deck.Reset();
        _deck.DiscardCard(_deck.DrawCard().Value);

        _player.Reset();
        _ai.Reset();

        for (int i = 0; i < 6; i++)
        {
            _player.AddCard(_deck.DrawCard());
            _ai.AddCard(_deck.DrawCard());
        }
    }

    public void HandCardClickHandler(object sender, HandCard card)
    {
        var playedValue = (int)card.Value;
        var currentValue = (int)_deck.DiscardValue;

        if (playedValue == currentValue || playedValue == currentValue + 1 || (playedValue == 1 && currentValue == 7))
        {
            _deck.DiscardCard(card.Value);
            card.Count--;
            _playersTurn = false;

            if (_player.CardsInHand() < 1)
            {
                _playerWon = true;
            }
        }
    }

    public void DeckClickHandler(object sender, EventArgs e)
    {
        if (_deck.AnyCardsLeft())
        {
            _player.AddCard(_deck.DrawCard());
            _playersTurn = false;
        }
    }

    public void Update()
    {
        if (_playerWon || _aiWon)
        {
            if (InputManager.LeftClicked) Reset();
            return;
        }

        if (_playersTurn)
        {
            _deck.CheckClick();
            _player.CheckHandClick();
        }
        else
        {
            (var played, var value) = _ai.PlayCard(_deck.DiscardValue);

            if (played)
            {
                _deck.DiscardCard(value);
                if (_ai.Hand.Count < 1)
                {
                    _aiWon = true;
                }
            }
            else
            {
                _ai.AddCard(_deck.DrawCard());
            }

            _playersTurn = true;
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();

        _deck.Draw();
        _player.DrawHand();
        _ai.Draw();

        if (_playerWon)
        {
            FontWriter.DrawText("Congrats! You won!", new(50, 20), Color.Black);
        }

        if (_aiWon)
        {
            FontWriter.DrawText("Sorry! You lost!", new(50, 20), Color.Black);
        }

        Globals.SpriteBatch.End();
    }
}
