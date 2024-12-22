using System;
using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
    }

    public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
    }

    public static Vector3 Subtract(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(vector.x - x ?? 0, vector.y - y ?? 0, vector.z - z ?? 0);
    }

    public static Vector3 Multiply(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(vector.x * x ?? 1, vector.y * y ?? 1, vector.z * z ?? 1);
    }

    public static Vector3 Divide(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(vector.x / x ?? 1, vector.y / y ?? 1, vector.z / z ?? 1);
    }

    public static Vector3 Normalize(this Vector3 vector)
    {
        return vector.normalized;
    }

    public static Vector3 ClampMagnitude(this Vector3 vector, float max)
    {
        return Vector3.ClampMagnitude(vector, max);
    }

    public static Vector3 Cross(this Vector3 vector, Vector3 other)
    {
        return Vector3.Cross(vector, other);
    }

    public static float Distance(this Vector3 vector, Vector3 other)
    {
        return Vector3.Distance(vector, other);
    }

    public static float Dot(this Vector3 vector, Vector3 other)
    {
        return Vector3.Dot(vector, other);
    }

    public static Vector3 Lerp(this Vector3 vector, Vector3 target, float t)
    {
        return Vector3.Lerp(vector, target, t);
    }

    public static Vector3 LerpUnclamped(this Vector3 vector, Vector3 target, float t)
    {
        return Vector3.LerpUnclamped(vector, target, t);
    }

    public static Vector3 Max(this Vector3 vector, Vector3 other)
    {
        return Vector3.Max(vector, other);
    }

    public static Vector3 Min(this Vector3 vector, Vector3 other)
    {
        return Vector3.Min(vector, other);
    }

    public static Vector3 MoveTowards(this Vector3 vector, Vector3 target, float maxDistanceDelta)
    {
        return Vector3.MoveTowards(vector, target, maxDistanceDelta);
    }

    public static Vector3 Reflect(this Vector3 vector, Vector3 normal)
    {
        return Vector3.Reflect(vector, normal);
    }

    public static Vector3 RotateTowards(this Vector3 vector, Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta)
    {
        return Vector3.RotateTowards(vector, target, maxRadiansDelta, maxMagnitudeDelta);
    }

    public static Vector3 Scale(this Vector3 vector, Vector3 scale)
    {
        return Vector3.Scale(vector, scale);
    }

    public static Vector3 Slerp(this Vector3 vector, Vector3 target, float t)
    {
        return Vector3.Slerp(vector, target, t);
    }

    public static Vector3 SlerpUnclamped(this Vector3 vector, Vector3 target, float t)
    {
        return Vector3.SlerpUnclamped(vector, target, t);
    }

    public static Vector3 SmoothDamp(this Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
    {
        return Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }

    public static Vector3 WithX(this Vector3 vector, float x) => new Vector3(x, vector.y, vector.z);
    public static Vector3 WithY(this Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);
    public static Vector3 WithZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);

    public static Vector3 Rotate(this Vector3 vector, Quaternion rotation) => rotation * vector;

    public static Vector3 LerpTo(this Vector3 vector, Vector3 target, float t)
    {
        return Vector3.Lerp(vector, target, t);
    }

    public static Vector3 Average(this Vector3 vector, Vector3 other)
    {
        return (vector + other) / 2f;
    }

    public static float AngleBetween(this Vector3 vector, Vector3 target)
    {
        return Vector3.Angle(vector, target) * Mathf.Deg2Rad;
    }

    public static bool ApproximatelyEqualDistance(this Vector3 vector, Vector3 other, float tolerance = 0.0001f)
    {
        return Vector3.Distance(vector, other) < tolerance;
    }

    public static Vector3 RandomInsideSphere(this Vector3 vector, float radius)
    {
        return vector + UnityEngine.Random.insideUnitSphere * radius;
    }

    public static Vector3 Log(this Vector3 vector)
    {
        return new Vector3(Mathf.Log(vector.x), Mathf.Log(vector.y), Mathf.Log(vector.z));
    }

    //sphere detection
    public static bool HasObjectWithLayer(this Vector3 position, int layer, float radius = 0.1f)
    {
        int layerMask = 1 << layer;
        Collider[] colliders = Physics.OverlapSphere(position, radius, layerMask);
        return colliders.Length > 0;
    }

    //box detection
    public static bool HasObjectWithLayerInBox(this Vector3 position, int layer, Vector3 halfExtents, Quaternion rotation = default)
    {
        int layerMask = 1 << layer;
        Collider[] colliders = Physics.OverlapBox(position, halfExtents, rotation, layerMask);
        return colliders.Length > 0;
    }

    public static bool CheckAllAxesForCollision(this Vector3 position, float radius, LayerMask layerMask)
    {
        // Check along X-axis
        Vector3 xOffset = new Vector3(radius, 0, 0);
        if (Physics.CheckSphere(position + xOffset, radius, layerMask) ||
            Physics.CheckSphere(position - xOffset, radius, layerMask))
        {
            return true;
        }

        // Check along Y-axis
        Vector3 yOffset = new Vector3(0, radius, 0);
        if (Physics.CheckSphere(position + yOffset, radius, layerMask) ||
            Physics.CheckSphere(position - yOffset, radius, layerMask))
        {
            return true;
        }

        // Check along Z-axis
        Vector3 zOffset = new Vector3(0, 0, radius);
        if (Physics.CheckSphere(position + zOffset, radius, layerMask) ||
            Physics.CheckSphere(position - zOffset, radius, layerMask))
        {
            return true;
        }

        // No collisions detected
        return false;
    }

}