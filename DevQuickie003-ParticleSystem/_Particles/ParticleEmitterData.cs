namespace Quickie003;

public struct ParticleEmitterData
{
    public ParticleData particleData = new();
    public float angle = 0f;
    public float angleVariance = 45f;
    public float lifespanMin = 0.1f;
    public float lifespanMax = 2f;
    public float speedMin = 10f;
    public float speedMax = 100f;
    public float interval = 1f;
    public int emitCount = 1;

    public ParticleEmitterData()
    {
    }
}
