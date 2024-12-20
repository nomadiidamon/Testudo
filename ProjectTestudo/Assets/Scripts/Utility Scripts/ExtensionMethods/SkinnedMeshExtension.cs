using System;
using UnityEngine;


public static class SkinnedMeshExtensions
{
    public static void SetBlendShapeWeight(this SkinnedMeshRenderer skinnedMesh, int index, float weight)
    {
        skinnedMesh.SetBlendShapeWeight(index, weight);
    }
    public static float GetBlendShapeWeight(this SkinnedMeshRenderer skinnedMesh, int index)
    {
        return skinnedMesh.GetBlendShapeWeight(index);
    }

    public static void SetMaterial(this SkinnedMeshRenderer renderer, Material material)
    {
        renderer.material = material;
    }

    public static void SetMaterialAtIndex(this SkinnedMeshRenderer renderer, int index, Material material)
    {
        Material[] materials = renderer.materials;
        if (index >= 0 && index < materials.Length)
        {
            materials[index] = material;
            renderer.materials = materials;
        }
    }

    public static void SetMaterials(this SkinnedMeshRenderer renderer, Material[] materials)
    {
        renderer.materials = materials;
    }

    public static Bounds GetBounds(this SkinnedMeshRenderer renderer)
    {
        return renderer.bounds;
    }

    public static void SetBounds(this SkinnedMeshRenderer renderer, Bounds bounds)
    {
        renderer.bounds = bounds;
    }

    public static void BakeMesh(this SkinnedMeshRenderer renderer, Mesh mesh)
    {
        renderer.BakeMesh(mesh);
    }

    public static void BakeMesh(this SkinnedMeshRenderer renderer, Mesh mesh, bool useScale)
    {
        renderer.BakeMesh(mesh, useScale);
    }

    public static int GetSubMeshCount(this SkinnedMeshRenderer renderer)
    {
        return renderer.sharedMesh.subMeshCount;
    }


}



