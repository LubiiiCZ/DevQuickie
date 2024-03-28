namespace Project004;

//RULES
/*
Bag of 13 dice
6 x Green - Brain, Brain, Brain, Blast, Feet, Feet
4 x Yellow - Brain, Brain, Blast, Blast, Feet, Feet
3 x Red - Brain, Blast, Blast, Blast, Feet, Feet

3 icons
Brain - 1 point
Shotgun blast - if you roll 3, your turn is over and you score 0 points
Feet - You must re-roll this die
*/

public class GameManager
{
    private readonly Bag _bag;
    private readonly List<Die> _hand = [];
    private int _blasts = 0;
    private int _brainsTotal = 0;
    private int _brains = 0;
    private int _turns = 4;

    private readonly Texture2D _blast;
    private readonly Texture2D _brain;
    private readonly Texture2D _feet;

    public GameManager()
    {
        Die.Load();
        _bag = new();

        _blast = Globals.Content.Load<Texture2D>("blast");
        _brain = Globals.Content.Load<Texture2D>("brain");
        _feet = Globals.Content.Load<Texture2D>("feet");

        StartNewTurn();
    }

    public void Reset()
    {
        _bag.Reset();
        _hand.Clear();
        _blasts = 0;
        _brainsTotal = 0;
        _brains = 0;
        _turns = 4;
    }

    public void Update()
    {
        InputManager.Update();

        if (InputManager.SpacePressed)
        {
            NextRoll();
        }
        else if (InputManager.EnterPressed && _blasts < 3)
        {
            EndTurn(false);
        }
    }

    public void StartNewTurn()
    {
        _hand.Add(_bag.PickRandomly());
        _hand.Add(_bag.PickRandomly());
        _hand.Add(_bag.PickRandomly());

        int x = 50;
        foreach (var die in _hand)
        {
            die.Position = new(x, 350);
            x += 150;
            die.Roll();
        }

        ResolveRoll();
    }

    public void EndTurn(bool fail)
    {
        _bag.Reset();
        _hand.Clear();
        _blasts = 0;
        if (!fail) _brainsTotal += _brains;
        _brains = 0;
        _turns--;

        if (_turns < 1)
        {
            Reset();
        }

        StartNewTurn();
    }

    public void ResolveRoll()
    {
        foreach (var die in _hand)
        {
            if (die.ActiveSide == Icons.Blast)
            {
                _blasts++;
            }

            if (die.ActiveSide == Icons.Brain)
            {
                _brains++;
            }
        }
    }

    public void NextRoll()
    {
        int newDice = 0;

        foreach (var die in _hand)
        {
            if (die.ActiveSide == Icons.Blast)
            {
                if (_blasts > 2)
                {
                    EndTurn(true);
                    return;
                }

                newDice++;
                die.used = true;
            }

            if (die.ActiveSide == Icons.Brain)
            {
                newDice++;
                die.used = true;
            }
        }

        _hand.RemoveAll(d => d.used);

        for (int i = 0; i < newDice; i++)
        {
            _hand.Add(_bag.PickRandomly());
        }

        var x = 50;
        foreach (var die in _hand)
        {
            die.Position = new(x, 350);
            x += 150;
            die.Roll();
        }

        ResolveRoll();
    }

    public void DrawUI()
    {
        int x = 50;

        for (int i = 0; i < _blasts; i++)
        {
            Globals.SpriteBatch.Draw(_blast, new Vector2(x, 200), null, Color.Red, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 1f);
            x += 40;
        }

        x = 50;

        for (int i = 0; i < _brainsTotal; i++)
        {
            Globals.SpriteBatch.Draw(_brain, new Vector2(x, 150), null, Color.Green, (_brainsTotal + _brains < 13) ? 0f : 0.5f, Vector2.Zero, 0.25f, SpriteEffects.None, 1f);
            x += 40;
        }

        x = 50;

        for (int i = 0; i < _brains; i++)
        {
            Globals.SpriteBatch.Draw(_brain, new Vector2(x, 250), null, Color.Yellow, (_brainsTotal + _brains < 13) ? 0f : 0.5f, Vector2.Zero, 0.25f, SpriteEffects.None, 1f);
            x += 40;
        }

        x = 50;

        for (int i = 0; i < _turns; i++)
        {
            Globals.SpriteBatch.Draw(_feet, new Vector2(x, 50), null, Color.White, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 1f);
            x += 40;
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _hand.ForEach(d => d.Draw());
        _bag.Draw();
        DrawUI();
        Globals.SpriteBatch.End();
    }
}
