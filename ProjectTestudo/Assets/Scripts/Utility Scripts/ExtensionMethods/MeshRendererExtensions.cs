using System;
using UnityEngine;


public static class MeshRendererExtensions
{


    public static void SetMaterial(this MeshRenderer renderer, Material material)
    {
        renderer.material = material;
    }
    public static void SetMaterialAtIndex(this MeshRenderer renderer, int index, Material material)
    {
        Material[] materials = renderer.materials;
        if (index >= 0 && index < materials.Length)
        {
            materials[index] = material;
            renderer.materials = materials;
        }
    }
    public static void SetMaterials(this MeshRenderer renderer, Material[] materials)
    {
        renderer.materials = materials;
    }
    public static Bounds GetBounds(this MeshRenderer renderer)
    {
        return renderer.bounds;
    }
    public static void SetBounds(this MeshRenderer renderer, Bounds bounds)
    {
        renderer.bounds = bounds;
    }
    public static void BakeMesh(this MeshRenderer renderer, Mesh mesh)
    {
        renderer.BakeMesh(mesh);
    }
    public static void BakeMesh(this MeshRenderer renderer, Mesh mesh, bool useScale)
    {
        renderer.BakeMesh(mesh, useScale);
    }
    public static int GetSubMeshCount(this MeshRenderer renderer)
    {
        return renderer.sharedMesh.subMeshCount;
    }

    public static void SetCastShadows(this MeshRenderer renderer, bool castShadows)
    {
        renderer.shadowCastingMode = castShadows ? UnityEngine.Rendering.ShadowCastingMode.On : UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    public static void SetReceiveShadows(this MeshRenderer renderer, bool receiveShadows)
    {
        renderer.receiveShadows = receiveShadows;
    }

    public static void SetTransparency(this MeshRenderer renderer, float alpha)
    {
        Color color = renderer.material.color;
        color.a = alpha;
        renderer.material.color = color;
    }

    public static void SetGlow(this MeshRenderer renderer, Color color, float intensity)
    {
        renderer.material.SetColor("_EmissionColor", color * intensity);
    }

    public static void SetShader(this MeshRenderer renderer, Shader shader)
    {
        renderer.material.shader = shader;
    }




}
