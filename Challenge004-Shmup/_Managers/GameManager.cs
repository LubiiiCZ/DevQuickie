namespace Challenge004;

/* RULES
https://en.wikipedia.org/wiki/Shoot_%27em_up
Art pack from: http://www.livingtheindie.com/
*/

/* ANALYSIS
 * Player's ship
    * Animation
    * Controls
    * Projectiles
 * Enemy ships
    * Animation
    * Movement
    * Projectiles
 * Game
    * Collisions
    * Explosion animation
    * Score counter
*/

public class GameManager
{
    private readonly Ship _ship;
    private readonly SpriteFont _font;
    private int _score;

    public GameManager()
    {
        _font = Globals.Content.Load<SpriteFont>("font");
        _ship = new(Globals.Content.Load<Texture2D>("ship"));
        for (int i = 0; i < 5; i++)
        {
            EnemyManager.AddEnemy();
        }
    }

    public void Restart()
    {
        _ship.Restart();
        EnemyManager.Restart();
        ProjectileManager.Restart();
        ExplosionManager.Restart();
        _score = 0;
    }

    public void HandleEnemyCollisions()
    {
        foreach (var enemy in EnemyManager.Enemies.ToArray())
        {
            foreach (var projectile in ProjectileManager.Projectiles.ToArray())
            {
                if (enemy.CollisionRectangle.Intersects(projectile.CollisionRectangle))
                {
                    ExplosionManager.AddExplosion(enemy.Position);
                    EnemyManager.Enemies.Remove(enemy);
                    ProjectileManager.Projectiles.Remove(projectile);
                    _score++;
                    break;
                };
            };
        };
    }

    public void HandlePlayerCollision()
    {
        foreach (var enemy in EnemyManager.Enemies)
        {
            if (enemy.CollisionRectangle.Intersects(_ship.CollisionRectangle))
            {
                Restart();
                break;
            };
        };

        foreach (var projectile in ProjectileManager.EnemyProjectiles)
        {
            if (projectile.CollisionRectangle.Intersects(_ship.CollisionRectangle))
            {
                Restart();
                break;
            };
        };
    }

    public void Update()
    {
        _ship.Update();
        EnemyManager.UpdateEnemies();
        ProjectileManager.UpdateProjectiles();
        HandleEnemyCollisions();
        HandlePlayerCollision();
        ExplosionManager.UpdateExplosions();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();

        EnemyManager.DrawEnemies();
        ProjectileManager.DrawProjectiles();
        ExplosionManager.DrawExplosions();
        _ship.Draw();

        Globals.SpriteBatch.DrawString(_font, _score.ToString(), Vector2.Zero, Color.White);

        Globals.SpriteBatch.End();
    }
}
