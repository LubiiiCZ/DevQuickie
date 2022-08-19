namespace Quickie003;

public static class ParticleManager
{
    	private static readonly List<Particle> _particles = new();
        private static readonly List<ParticleEmitter> _particleEmitters = new();

        public static void AddParticle(Particle p)
        {
            _particles.Add(p);
        }

        public static void AddParticleEmitter(ParticleEmitter e)
        {
            _particleEmitters.Add(e);
        }

        public static void UpdateParticles()
        {
            foreach (var particle in _particles)
            {
                particle.Update();
            }

            _particles.RemoveAll(p => p.isFinished);
        }

        public static void UpdateEmitters()
        {
            foreach (var emitter in _particleEmitters)
            {
                emitter.Update();
            }
        }

        public static void Update()
        {
            UpdateParticles();
            UpdateEmitters();
        }

        public static void Draw()
        {
            foreach (var particle in _particles)
            {
                particle.Draw();
            }
        }
}
