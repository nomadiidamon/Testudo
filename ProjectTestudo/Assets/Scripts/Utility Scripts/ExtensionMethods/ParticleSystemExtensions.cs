using System;
using UnityEngine;



public static class ParticleSystemExtensions
{


    public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate)
    {
        var emission = particleSystem.emission;
        emission.rateOverTime = emissionRate;
    }
    public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate, float duration)
    {
        var emission = particleSystem.emission;
        emission.rateOverTime = emissionRate;
        emission.enabled = true;
    }

    public static void StartEmission(this ParticleSystem particleSystem)
    {
        var emission = particleSystem.emission;
        emission.enabled = true;
    }

    public static void StopEmission(this ParticleSystem particleSystem)
    {
        var emission = particleSystem.emission;
        emission.enabled = false;
    }

    public static void SetColorOverLifetime(this ParticleSystem particleSystem, Gradient colorGradient)
    {
        var colorOverLifetime = particleSystem.colorOverLifetime;
        colorOverLifetime.color = colorGradient;
    }

    public static void SetSizeOverLifetime(this ParticleSystem particleSystem, AnimationCurve sizeCurve)
    {
        var sizeOverLifetime = particleSystem.sizeOverLifetime;
        sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(1, sizeCurve);
    }

    public static void SetSizeOverLifetime(this ParticleSystem particleSystem, AnimationCurve sizeCurve, float duration)
    {
        var sizeOverLifetime = particleSystem.sizeOverLifetime;
        sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(1, sizeCurve);
        sizeOverLifetime.enabled = true;
    }

    public static void SetRotationOverLifetime(this ParticleSystem particleSystem, AnimationCurve rotationCurve)
    {
        var rotationOverLifetime = particleSystem.rotationOverLifetime;
        rotationOverLifetime.z = new ParticleSystem.MinMaxCurve(0, rotationCurve);
    }

    public static void SetRotationOverLifetime(this ParticleSystem particleSystem, AnimationCurve rotationCurve, float duration)
    {
        var rotationOverLifetime = particleSystem.rotationOverLifetime;
        rotationOverLifetime.z = new ParticleSystem.MinMaxCurve(0, rotationCurve);
        rotationOverLifetime.enabled = true;
    }

    public static void SetSpeedOverLifetime(this ParticleSystem particleSystem, AnimationCurve speedCurve)
    {
        var speedOverLifetime = particleSystem.velocityOverLifetime;
        speedOverLifetime.x = new ParticleSystem.MinMaxCurve(1, speedCurve);
    }

    public static void SetSpeedOverLifetime(this ParticleSystem particleSystem, AnimationCurve speedCurve, float duration)
    {
        var speedOverLifetime = particleSystem.velocityOverLifetime;
        speedOverLifetime.x = new ParticleSystem.MinMaxCurve(1, speedCurve);
        speedOverLifetime.enabled = true;
    }

    public static void SetGravityOverLifetime(this ParticleSystem particleSystem, AnimationCurve gravityCurve)
    {
        var forceOverLifetime = particleSystem.forceOverLifetime;
        forceOverLifetime.y = new ParticleSystem.MinMaxCurve(1, gravityCurve);
    }

    public static void SetGravityOverLifetime(this ParticleSystem particleSystem, AnimationCurve gravityCurve, float duration)
    {
        var forceOverLifetime = particleSystem.forceOverLifetime;
        forceOverLifetime.y = new ParticleSystem.MinMaxCurve(1, gravityCurve);
        forceOverLifetime.enabled = true;
    }

    public static void SetColorBySpeed(this ParticleSystem particleSystem, Gradient colorGradient)
    {
        var colorBySpeed = particleSystem.colorBySpeed;
        colorBySpeed.color = colorGradient;
    }

    public static void SetSizeBySpeed(this ParticleSystem particleSystem, AnimationCurve sizeCurve)
    {
        var sizeBySpeed = particleSystem.sizeBySpeed;
        sizeBySpeed.size = new ParticleSystem.MinMaxCurve(1, sizeCurve);
    }

    public static void SetRotationBySpeed(this ParticleSystem particleSystem, AnimationCurve rotationCurve)
    {
        var rotationBySpeed = particleSystem.rotationBySpeed;
        rotationBySpeed.z = new ParticleSystem.MinMaxCurve(0, rotationCurve);
    }

    public static void SetSpeedBySpeed(this ParticleSystem particleSystem, AnimationCurve speedCurve)
    {
        var speedBySpeed = particleSystem.velocityOverLifetime;
        speedBySpeed.x = new ParticleSystem.MinMaxCurve(1, speedCurve);
    }

    public static void SetGravityBySpeed(this ParticleSystem particleSystem, AnimationCurve gravityCurve)
    {
        var forceBySpeed = particleSystem.forceOverLifetime;
        forceBySpeed.y = new ParticleSystem.MinMaxCurve(1, gravityCurve);
    }

    public static void StartWithDelay(this ParticleSystem ps, float delay)
    {
        ps.gameObject.SetActive(true);
        ps.Play();
        ps.time = -delay;
    }

    public static void StopWithDelay(this ParticleSystem ps, float delay)
    {
        ps.Stop();
        ps.time = delay;
    }

    public static void StopImmediately(this ParticleSystem ps)
    {
        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public static void ClearAllParticles(this ParticleSystem ps)
    {
        ps.Clear();
    }

    public static void SetStartColor(this ParticleSystem ps, Color color)
    {
        var main = ps.main;
        main.startColor = color;
    }

    public static void SetStartSize(this ParticleSystem ps, float size)
    {
        var main = ps.main;
        main.startSize = size;
    }

    public static void SetStartLifetime(this ParticleSystem ps, float lifetime)
    {
        var main = ps.main;
        main.startLifetime = lifetime;
    }

    public static void SetStartSpeed(this ParticleSystem ps, float speed)
    {
        var main = ps.main;
        main.startSpeed = speed;
    }

    public static void SetStartRotation(this ParticleSystem ps, float rotation)
    {
        var main = ps.main;
        main.startRotation = rotation;
    }

    public static void SetGravityModifier(this ParticleSystem ps, float modifier)
    {
        var main = ps.main;
        main.gravityModifier = modifier;
    }

    public static void SetLooping(this ParticleSystem ps, bool loop)
    {
        var main = ps.main;
        main.loop = loop;
    }

    public static void SetMaxParticles(this ParticleSystem ps, int maxParticles)
    {
        var main = ps.main;
        main.maxParticles = maxParticles;
    }

    public static int GetParticleCount(this ParticleSystem ps)
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.main.maxParticles];
        return ps.GetParticles(particles);
    }

    public static void SetStartRotationRandomness(this ParticleSystem ps, float randomness)
    {
        var main = ps.main;
        main.startRotationZ = new ParticleSystem.MinMaxCurve(randomness);
    }

    public static void SetStartSizeRandomness(this ParticleSystem ps, float randomness)
    {
        var main = ps.main;
        main.startSize = new ParticleSystem.MinMaxCurve(1, randomness);
    }

    public static void SetStartSpeedRandomness(this ParticleSystem ps, float randomness)
    {
        var main = ps.main;
        main.startSpeed = new ParticleSystem.MinMaxCurve(1, randomness);
    }

    public static void SetStartLifetimeRandomness(this ParticleSystem ps, float randomness)
    {
        var main = ps.main;
        main.startLifetime = new ParticleSystem.MinMaxCurve(1, randomness);
    }

    public static void PauseSystem(this ParticleSystem ps)
    {
        ps.Pause();
    }

    public static void ResumeSystem(this ParticleSystem ps)
    {
        ps.Play();
    }

    public static void SetDirectionalGravity(this ParticleSystem ps, Vector3 direction, float strength)
    {
        var main = ps.main;
        main.gravityModifier = strength;
        ps.transform.up = direction;
    }

    public static void SetStartRotationAxis(this ParticleSystem ps, Vector3 axis)
    {
        var main = ps.main;
        main.startRotation = new ParticleSystem.MinMaxCurve(0f, axis.magnitude);
    }

    public static void SetEmissionRateOverTime(this ParticleSystem ps, AnimationCurve curve)
    {
        var emission = ps.emission;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(1f, curve);
    }

    public static void ToggleLoop(this ParticleSystem ps)
    {
        var main = ps.main;
        main.loop = !main.loop;
    }

    public static void SetSimulationSpeed(this ParticleSystem ps, float speed)
    {
        var main = ps.main;
        main.simulationSpeed = speed;
    }

    public static void StopWithFadeOut(this ParticleSystem ps, float fadeDuration)
    {
        var main = ps.main;
        main.startLifetime = new ParticleSystem.MinMaxCurve(main.startLifetime.constant - fadeDuration);
        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public static void Reset(this ParticleSystem ps)
    {
        ps.Clear();
        ps.Play();
    }



}
