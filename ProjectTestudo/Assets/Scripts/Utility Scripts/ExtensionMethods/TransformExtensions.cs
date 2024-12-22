using System;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static Transform FindChildByName(this Transform transform, string name)
    {
        foreach (Transform child in transform)
        {
            if (child.name == name)
                return child;
        }
        return null;
    }

    public static void SetRotationToTargetDirection(this Transform transform, Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public static void RotateTowardsTarget(this Transform transform, Transform target, float speed)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    public static bool IsAbove(this Transform transform, Transform other)
    {
        return transform.position.y > other.position.y;
    }

    public static bool IsBelow(this Transform transform, Transform other)
    {
        return transform.position.y < other.position.y;
    }

    public static bool IsLeftOf(this Transform transform, Transform other)
    {
        return transform.position.x < other.position.x;
    }

    public static bool IsRightOf(this Transform transform, Transform other)
    {
        return transform.position.x > other.position.x;
    }

    public static bool IsInFrontOf(this Transform transform, Transform other)
    {
        return transform.position.z > other.position.z;
    }

    public static bool IsBehind(this Transform transform, Transform other)
    {
        return transform.position.z < other.position.z;
    }

    public static float CalculateDistanceTo(this Transform transform, Transform target)
    {
        return Vector3.Distance(transform.position, target.position);
    }

    public static Vector3 CalculateDirectionTo(this Transform transform, Transform target)
    {
        return (target.position - transform.position).normalized;
    }

    public static void RotateToMatch(this Transform transform, Transform target)
    {
        transform.rotation = target.rotation;
    }

    public static void SetUniformScale(this Transform transform, float scale)
    {
        transform.localScale = Vector3.one * scale;
    }

    public static void MultiplyLocalScale(this Transform transform, Vector3 multiplier)
    {
        transform.localScale = Vector3.Scale(transform.localScale, multiplier);
    }

    public static void ScaleToMatch(this Transform transform, Transform target)
    {
        transform.localScale = target.localScale;
    }

    public static void TranslateAlongAxis(this Transform transform, Vector3 axis, float distance)
    {
        transform.position += axis.normalized * distance;
    }

    public static void MoveTowardsPosition(this Transform transform, Vector3 targetPosition, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public static Quaternion GetWorldRotation(this Transform transform)
    {
        return transform.rotation;
    }

    public static void SetWorldRotation(this Transform transform, Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public static void RotateAroundWorldAxis(this Transform transform, Vector3 worldAxis, float angle)
    {
        transform.Rotate(worldAxis, angle, Space.World);
    }

    public static void RotateAroundLocalAxis(this Transform transform, Vector3 localAxis, float angle)
    {
        transform.Rotate(localAxis, angle, Space.Self);
    }

    public static void AlignWith(this Transform transform, Transform target)
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    public static void AlignWith(this Transform transform, Transform target, Vector3 offset)
    {
        transform.position = target.position + offset;
        transform.rotation = target.rotation;
    }

    public static void AlignWith(this Transform transform, Transform target, Vector3 positionOffset, Vector3 rotationOffset)
    {
        transform.position = target.position + positionOffset;
        transform.rotation = target.rotation * Quaternion.Euler(rotationOffset);
    }

    public static void AlignWith(this Transform transform, Transform target, Vector3 positionOffset, Vector3 rotationOffset, Vector3 scale)
    {
        transform.position = target.position + positionOffset;
        transform.rotation = target.rotation * Quaternion.Euler(rotationOffset);
        transform.localScale = scale;
    }

    public static void AlignWith(this Transform transform, Transform target, Vector3 positionOffset, Vector3 rotationOffset, float scale)
    {
        transform.position = target.position + positionOffset;
        transform.rotation = target.rotation * Quaternion.Euler(rotationOffset);
        transform.localScale = Vector3.one * scale;
    }

    public static void DetachAndDestroy(this Transform transform)
    {
        transform.SetParent(null);
        GameObject.Destroy(transform.gameObject);
    }

    public static void LerpPosition(this Transform transform, Vector3 targetPosition, float t)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, t);
    }


    public static void LerpRotation(this Transform transform, Quaternion targetRotation, float t)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, t);
    }

    public static void LerpScale(this Transform transform, Vector3 targetScale, float t)
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, t);
    }

    public static void LerpLocalPosition(this Transform transform, Vector3 targetPosition, float t)
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, t);
    }

    public static void LerpLocalRotation(this Transform transform, Quaternion targetRotation, float t)
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, t);
    }

    public static void LerpLocalScale(this Transform transform, Vector3 targetScale, float t)
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, t);
    }

    public static void SlerpRotation(this Transform transform, Quaternion targetRotation, float t)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t);
    }

    public static float GetDistanceTo(this Transform transform, Transform target)
    {
        return Vector3.Distance(transform.position, target.position);
    }

    public static void MirrorAcrossAxis(this Transform transform, Vector3 axis)
    {
        transform.position = Vector3.Reflect(transform.position, axis.normalized);
    }

    public static void MirrorAcrossPlane(this Transform transform, Plane plane)
    {
        transform.position = plane.ClosestPointOnPlane(transform.position) + (transform.position - plane.ClosestPointOnPlane(transform.position));
    }

    public static void RotateAroundObject(this Transform transform, Transform target, Vector3 axis, float angle)
    {
        transform.RotateAround(target.position, axis, angle);
    }

    public static void RotateAround(this Transform transform, Vector3 point, Vector3 axis, float angle)
    {
        transform.RotateAround(point, axis, angle);
    }

    public static void RotateAroundAxisWithDuration(this Transform transform, Vector3 axis, float angle, float duration)
    {
        transform.Rotate(axis, angle * (Time.deltaTime / duration), Space.World);
    }

    public static void SwapPositionWith(this Transform transform, Transform target)
    {
        Vector3 temp = transform.position;
        transform.position = target.position;
        target.position = temp;
    }

    public static void SwapRotationWith(this Transform transform, Transform target)
    {
        Quaternion temp = transform.rotation;
        transform.rotation = target.rotation;
        target.rotation = temp;
    }

    public static void SwapScaleWith(this Transform transform, Transform target)
    {
        Vector3 temp = transform.localScale;
        transform.localScale = target.localScale;
        target.localScale = temp;
    }

    public static Vector3 GetFlattenedPosition(this Transform transform, Vector3 planeNormal)
    {
        return Vector3.ProjectOnPlane(transform.position, planeNormal);
    }

    public static void RotateSmoothlyTowards(this Transform transform, Vector3 targetPosition, float rotationSpeed)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public static void RotateSmoothlyTowards(this Transform transform, Transform target, float rotationSpeed)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public static void RotateSmoothlyTowards(this Transform transform, Vector3 targetPosition, float rotationSpeed, float maxDegreesDelta)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxDegreesDelta);
    }

    public static void SetXPositionOnly(this Transform transform, float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public static void SetYPositionOnly(this Transform transform, float y)
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    public static void SetZPositionOnly(this Transform transform, float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }

    public static Vector3 GetWorldPosition(this Transform transform)
    {
        return transform.position;
    }

    public static List<GameObject> GetAllChildren(this Transform transform)
    {
        List<GameObject> children = new List<GameObject>();

        // Loop through all child transforms and add their game objects to the list
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);

            // Recursively add children of children (if any)
            children.AddRange(child.GetAllChildren());
        }

        return children;
    }




}
