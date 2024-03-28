namespace Quickie003;

public class ParticleEmitter(IEmitter emitter, ParticleEmitterData data)
{
    private readonly ParticleEmitterData _data = data;
    private float _intervalLeft = data.interval;
    private readonly IEmitter _emitter = emitter;

    private void Emit(Vector2 pos)
    {
        ParticleData d = _data.particleData;
        d.lifespan = Globals.RandomFloat(_data.lifespanMin, _data.lifespanMax);
        d.speed = Globals.RandomFloat(_data.speedMin, _data.speedMax);
        d.angle = Globals.RandomFloat(_data.angle - _data.angleVariance, _data.angle + _data.angleVariance);

        Particle p = new(pos, d);
        ParticleManager.AddParticle(p);
    }

    public void Update()
    {
        _intervalLeft -= Globals.TotalSeconds;
        while (_intervalLeft <= 0f)
        {
            _intervalLeft += _data.interval;
            var pos = _emitter.EmitPosition;
            for (int i = 0; i < _data.emitCount; i++)
            {
                Emit(pos);
            }
        }
    }
}
