using System;
using UnityEngine;

public static class GameObjectExtensions
{
    public static void SetLayerRecursively(this GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetLayerRecursively(layer);
        }
    }

    public static void SetActiveRecursively(this GameObject obj, bool active)
    {
        obj.SetActive(active);
        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetActiveRecursively(active);
        }
    }

    public static T GetOrAdd<T> (this GameObject gameObject) where T : Component
    {
        T component = gameObject.GetComponent<T>();
        if (!component) component = gameObject.AddComponent<T>();

        return component;
    }

    public static T OrNull<T>(this T obj) where T : Object => (bool)obj ? obj : null;


    public static GameObject FindChildByName(this GameObject gameObject, string childName)
    {
        Transform childTransform = gameObject.transform.Find(childName);
        return childTransform != null ? childTransform.gameObject : null;
    }

    public static GameObject FindChildByTag(this GameObject gameObject, string tag)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }
        return null;
    }

    public static bool HasComponent<T>(this GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>() != null;
    }

    public static void LogComponents<T>(this GameObject gameObject) where T : Component
    {
        T[] components = gameObject.GetComponents<T>();
        foreach (T component in components)
        {
            Debug.Log(component);
        }
    }

    public static void LogComponentsInChildren<T>(this GameObject gameObject) where T : Component
    {
        T[] components = gameObject.GetComponentsInChildren<T>();
        foreach (T component in components)
        {
            Debug.Log(component);
        }
    }

    public static bool IsDescendantOf(this GameObject gameObject, GameObject parent)
    {
        return gameObject.transform.IsChildOf(parent.transform);
    }

    public static Collider GetCollider(this GameObject gameObject)
    {
        return gameObject.GetComponent<Collider>();
    }

    public static Collider2D GetCollider2D(this GameObject gameObject)
    {
        return gameObject.GetComponent<Collider2D>();
    }

    public static bool HasRigidbody(this GameObject gameObject)
    {
        return gameObject.GetComponent<Rigidbody>() != null;
    }

    public static void EnableComponent<T>(this GameObject gameObject) where T : Behaviour
    {
        T component = gameObject.GetComponent<T>();
        if (component != null)
        {
            component.enabled = true;
        }
    }

    public static void DisableComponent<T>(this GameObject gameObject) where T : Behaviour
    {
        T component = gameObject.GetComponent<T>();
        if (component != null)
        {
            component.enabled = false;
        }
    }

    public static void SetMaterialColor(this GameObject gameObject, Color color)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    public static void SetMaterialColor(this GameObject gameObject, string materialName, Color color)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.SetColor(materialName, color);
        }
    }

    public static bool IsCollidingWith(this GameObject gameObject, GameObject other)
    {
        Collider collider = gameObject.GetComponent<Collider>();
        Collider otherCollider = other.GetComponent<Collider>();
        return collider != null && otherCollider != null && collider.bounds.Intersects(otherCollider.bounds);
    }

    public static void RotateToFace(this GameObject gameObject, Vector3 point)
    {
        Vector3 direction = point - gameObject.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        gameObject.transform.rotation = rotation;
    }

    public static void RotateToFace(this GameObject gameObject, GameObject target)
    {
        gameObject.RotateToFace(target.transform.position);
    }

    public static void RotateToFace(this GameObject gameObject, Transform target)
    {
        gameObject.RotateToFace(target.position);
    }

    public static ParticleSystem AddParticleSystem(this GameObject gameObject)
    {
        return gameObject.GetOrAddComponent<ParticleSystem>();
    }

    public static ParticleSystemRenderer AddParticleSystemRenderer(this GameObject gameObject)
    {
        return gameObject.GetOrAddComponent<ParticleSystemRenderer>();
    }

    public static ParticleSystem.MainModule GetMainModule(this GameObject gameObject)
    {
        return gameObject.AddParticleSystem().main;
    }
}


