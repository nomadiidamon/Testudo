using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public static class LightExtensions
{
    private static MonoBehaviour GetMonoBehaviour(Light light)
    {
        return light.GetComponent<MonoBehaviour>();
    }

    public static void SetIntensity(this Light light, float intensity)
    {
        light.intensity = intensity;
    }

    public static void SetRange(this Light light, float range)
    {
        light.range = range;
    }

    public static void SetColor(this Light light, Color color)
    {
        light.color = color;
    }

    public static void Flicker(this Light light, float minIntensity, float maxIntensity, float duration)
    {
        GetMonoBehaviour(light).StartCoroutine(FlickerCoroutine(light, minIntensity, maxIntensity, duration));
    }

    private static IEnumerator FlickerCoroutine(Light light, float minIntensity, float maxIntensity, float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            light.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(timer * 2, 1));
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public static void FadeOut(this Light light, float duration)
    {
        GetMonoBehaviour(light).StartCoroutine(FadeOutCoroutine(light, duration));
    }

    private static IEnumerator FadeOutCoroutine(Light light, float duration)
    {
        float startIntensity = light.intensity;
        float timer = 0;
        while (timer < duration)
        {
            light.intensity = Mathf.Lerp(startIntensity, 0, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public static void FadeIn(this Light light, float duration)
    {
        GetMonoBehaviour(light).StartCoroutine(FadeInCoroutine(light, duration));
    }

    private static IEnumerator FadeInCoroutine(Light light, float duration)
    {
        float startIntensity = light.intensity;
        float timer = 0;
        while (timer < duration)
        {
            light.intensity = Mathf.Lerp(startIntensity, 1, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public static void SetShadowStrength(this Light light, float strength)
    {
        light.shadowStrength = strength;
    }

    public static void SetShadowResolution(this Light light, LightShadowResolution resolution)
    {
        light.shadowResolution = resolution;
    }

    public static void SetShadowBias(this Light light, float bias)
    {
        light.shadowBias = bias;
    }

    public static void SetShadowNormalBias(this Light light, float normalBias)
    {
        light.shadowNormalBias = normalBias;
    }

    public static void Toggle(this Light light)
    {
        light.enabled = !light.enabled;
    }

    public static void SetColorTemperature(this Light light, float temperature)
    {
        light.colorTemperature = temperature;
    }

    public static void SetBounceIntensity(this Light light, float intensity)
    {
        light.bounceIntensity = intensity;
    }

    public static void SetCullingMask(this Light light, LayerMask cullingMask)
    {
        light.cullingMask = cullingMask;
    }

    public static void SetFlare(this Light light, Flare flare)
    {
        light.flare = flare;
    }

    public static void SetSpotAngle(this Light light, float angle)
    {
        light.spotAngle = angle;
    }

    public static void SetCookie(this Light light, Texture cookie)
    {
        light.cookie = cookie;
    }

    public static void SetRenderMode(this Light light, LightRenderMode renderMode)
    {
        light.renderMode = renderMode;
    }

    public static void SetAreaSize(this Light light, Vector2 size)
    {
        light.areaSize = size;
    }
}
