using System;
using UnityEngine;


public static class MeshRendererExtensions
{
    // Other methods...

    public static int GetSubMeshCount(this MeshRenderer renderer)
    {
        MeshFilter meshFilter = renderer.GetComponent<MeshFilter>();
        if (meshFilter != null && meshFilter.sharedMesh != null)
        {
            return meshFilter.sharedMesh.subMeshCount;
        }
        return 0;
    }

    // Other methods...
}
