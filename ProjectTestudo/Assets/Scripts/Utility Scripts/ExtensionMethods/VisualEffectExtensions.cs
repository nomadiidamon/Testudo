using System;
using UnityEngine;
using UnityEngine.VFX;

public static class VisualEffectExtensions
{

    public static void SetVisualEffectEnabled(this VisualEffect visualEffect, bool enabled)
    {
        visualEffect.enabled = enabled;
    }
    public static void PlayVisualEffect(this VisualEffect visualEffect)
    {
        visualEffect.Play();
    }
    public static void StopVisualEffect(this VisualEffect visualEffect)
    {
        visualEffect.Stop();
    }
    //public static void PauseVisualEffect(this VisualEffect visualEffect)
    //{
    //    visualEffect.Pause();
    //}
    //public static void ResumeVisualEffect(this VisualEffect visualEffect)
    //{
    //    visualEffect.Resume();
    //}
    //public static void SetVisualEffectTime(this VisualEffect visualEffect, float time)
    //{
    //    visualEffect.time = time;
    //}
    //public static void SetVisualEffectSpeed(this VisualEffect visualEffect, float speed)
    //{
    //    visualEffect.speed = speed;
    //}
    //public static void SetVisualEffectPlayOnAwake(this VisualEffect visualEffect, bool playOnAwake)
    //{
    //    visualEffect.playOnAwake = playOnAwake;
    //}
    //public static void SetVisualEffectLoop(this VisualEffect visualEffect, bool loop)
    //{
    //    visualEffect.loop = loop;
    //}
    //public static void SetVisualEffectDuration(this VisualEffect visualEffect, float duration)
    //{
    //    visualEffect.duration = duration;
    //}
    //public static void SetVisualEffectTimeScale(this VisualEffect visualEffect, float timeScale)
    //{
    //    visualEffect.timeScale = timeScale;
    //}
    //public static void SetVisualEffectStopAction(this VisualEffect visualEffect, VisualEffectStopAction stopAction)
    //{
    //    visualEffect.stopAction = stopAction;
    //}
    //public static void SetVisualEffectResetOnStop(this VisualEffect visualEffect, bool resetOnStop)
    //{
    //    visualEffect.resetOnStop = resetOnStop;
    //}
    //public static void SetVisualEffectAutoRandomSeed(this VisualEffect visualEffect, bool autoRandomSeed)
    //{
    //    visualEffect.autoRandomSeed = autoRandomSeed;
    //}
    //public static void SetVisualEffectRandomSeed(this VisualEffect visualEffect, uint randomSeed)
    //{
    //    visualEffect.randomSeed = randomSeed;
    //}
    //public static void SetVisualEffectUseOwner(this VisualEffect visualEffect, bool useOwner)
    //{
    //    visualEffect.useOwner = useOwner;
    //}
    //public static void SetVisualEffectUseOwnerAlpha(this VisualEffect visualEffect, bool useOwnerAlpha)
    //{
    //    visualEffect.useOwner

    //}






}
