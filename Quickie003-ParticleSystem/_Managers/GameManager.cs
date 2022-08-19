namespace Quickie003;

public class GameManager
{
    private readonly MouseEmitter _mouseEmitter = new();
    private readonly StaticEmitter _staticEmitter = new(new(300, 300));
    private readonly StaticEmitter _staticEmitter2 = new(new(500, 500));

    public void Init()
    {
        ParticleEmitterData ped = new()
        {
            interval = 0.01f,
            emitCount = 10,
            angleVariance = 180f
        };

        ParticleEmitter pe = new(_mouseEmitter, ped);
        ParticleManager.AddParticleEmitter(pe);

        ParticleEmitterData ped2 = new()
        {
            interval = 0.01f,
            emitCount = 10
        };

        ParticleEmitter pe2 = new(_staticEmitter, ped2);
        ParticleManager.AddParticleEmitter(pe2);

        ParticleEmitterData ped3 = new()
        {
            interval = 1f,
            emitCount = 150,
            angleVariance = 180f,
            lifespanMin = 2f,
            lifespanMax = 2f,
            speedMin = 100f,
            speedMax = 100f,
            particleData = new()
            {
                colorStart = Color.Green,
                colorEnd = Color.Yellow,
                sizeStart = 8,
                sizeEnd = 32
            }
        };

        ParticleEmitter pe3 = new(_staticEmitter2, ped3);
        ParticleManager.AddParticleEmitter(pe3);
    }

    public static void Update()
    {
        InputManager.Update();
        ParticleManager.Update();
    }

    public static void Draw()
    {
        ParticleManager.Draw();
    }
}
