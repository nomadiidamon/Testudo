using System;
using UnityEngine;

public static class RendererExtensions
{
    public static void SetMaterial(this Renderer renderer, Material material)
    {
        renderer.material = material;
    }

    public static void SetMaterialAtIndex(this Renderer renderer, int index, Material material)
    {
        Material[] materials = renderer.materials;
        if (index >= 0 && index < materials.Length)
        {
            materials[index] = material;
            renderer.materials = materials;
        }
    }

    public static void Show(this Renderer renderer)
    {
        renderer.enabled = true;
    }

    public static void Hide(this Renderer renderer)
    {
        renderer.enabled = false;
    }

    public static void SetSortingLayer(this Renderer renderer, string sortingLayer)
    {
        renderer.sortingLayerName = sortingLayer;
    }

    public static void SetRenderQueue(this Renderer renderer, int queue)
    {
        renderer.material.renderQueue = queue;
    }

    public static void SetTransparency(this Renderer renderer, float alpha)
    {
        Color color = renderer.material.color;
        color.a = alpha;
        renderer.material.color = color;
    }

    public static void SetGlow(this Renderer renderer, Color glowColor, float intensity)
    {
        renderer.material.SetColor("_EmissionColor", glowColor * intensity);
    }

    public static void SetShader(this Renderer renderer, Shader shader)
    {
        renderer.material.shader = shader;
    }


    public static void ApplyTint(this Renderer renderer, Color color)
    {
        renderer.material.SetColor("_Color", color);
    }




}
