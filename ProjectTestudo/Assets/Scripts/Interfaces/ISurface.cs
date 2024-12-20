using System;
using UnityEngine;

public interface ISurface
{
    LayerMask layerMask { get; set; }
    Vector3 GetSurfaceNormal(Vector3 position);
    bool IsGrounded(Vector3 position);
    float GetGravityStrength();
}
