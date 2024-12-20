using System;
using UnityEngine;


public static class ColliderExtensions
{
    public static bool IsTouching(this Collider collider, Collider other)
    {
        return collider.IsTouching(other);
    }
    public static bool IsTouchingLayers(this Collider collider, int layerMask)
    {
        return collider.IsTouchingLayers(layerMask);
    }
    public static bool Overlaps(this Collider collider, Collider other)
    {
        return collider.Overlaps(other);
    }
    public static bool Overlaps(this Collider collider, Collider other, out Collision collision)
    {
        return collider.Overlaps(other, out collision);
    }
    public static bool Overlaps(this Collider collider, Collider other, out Collider[] colliders)
    {
        return collider.Overlaps(other, out colliders);
    }
    public static bool Raycast(this Collider collider, Ray ray, out RaycastHit hitInfo, float maxDistance)
    {
        return collider.Raycast(ray, out hitInfo, maxDistance);
    }
    public static bool Raycast(this Collider collider, Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask)
    {
        return collider.Raycast(ray, out hitInfo, maxDistance, layerMask);
    }
    public static bool Raycast(this Collider collider, Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
    {
        return collider.Raycast(ray, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }


    public static void SetTrigger(this Collider collider, bool isTrigger)
    {
        collider.isTrigger = isTrigger;
    }

    public static void SetMaterial(this Collider collider, PhysicMaterial material)
    {
        collider.material = material;
    }

    public static void SetCenter(this Collider collider, Vector3 center)
    {
        collider.center = center;
    }

    public static void SetSize(this Collider collider, Vector3 size)
    {
        collider.size = size;
    }

    public static void SetDirection(this Collider collider, int direction)
    {
        collider.direction = direction;
    }

    public static bool IsTrigger(this Collider collider)
    {
        return collider.isTrigger;
    }

    public static bool BoundsContainsPoint(this Collider collider, Vector3 point)
    {
        return collider.bounds.Contains(point);
    }

    public static bool BoundsIntersects(this Collider collider, Bounds bounds)
    {
        return collider.bounds.Intersects(bounds);
    }

    public static bool BoundsIntersects(this Collider collider, Collider other)
    {
        return collider.bounds.Intersects(other.bounds);
    }

    public static void ApplyForce(this Collider collider, Vector3 force)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(force);
        }
    }

    public static void ApplyForce(this Collider collider, Vector3 force, ForceMode mode)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(force, mode);
        }
    }

    public static void ApplyTorque(this Collider collider, Vector3 torque)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddTorque(torque);
        }
    }

    public static Vector3 GetRigidbodyVelocity(this Collider collider)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        return rb != null ? rb.velocity : Vector3.zero;
    }

    public static Vector3 GetRigidbodyAngularVelocity(this Collider collider)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        return rb != null ? rb.angularVelocity : Vector3.zero;
    }

    public static void SetRigidbodyVelocity(this Collider collider, Vector3 velocity)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = velocity;
        }
    }

    public static void SetRigidbodyAngularVelocity(this Collider collider, Vector3 angularVelocity)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.angularVelocity = angularVelocity;
        }
    }

    public static void SetRigidbodyDrag(this Collider collider, float drag)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.drag = drag;
        }
    }

    public static void SetRigidbodyAngularDrag(this Collider collider, float angularDrag)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.angularDrag = angularDrag;
        }
    }

    public static void SetRigidbodyMass(this Collider collider, float mass)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = mass;
        }
    }

    public static void SetRigidbodyUseGravity(this Collider collider, bool useGravity)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = useGravity;
        }
    }

    public static void SetRigidbodyIsKinematic(this Collider collider, bool isKinematic)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = isKinematic;
        }
    }

    public static void SetRigidbodyInterpolation(this Collider collider, RigidbodyInterpolation interpolation)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.interpolation = interpolation;
        }
    }

    public static void SetRigidbodyCollisionDetection(this Collider collider, CollisionDetectionMode mode)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.collisionDetectionMode = mode;
        }
    }

    public static void SetRigidbodyConstraints(this Collider collider, RigidbodyConstraints constraints)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = constraints;
        }
    }

    public static void SetRigidbodyFreezePosition(this Collider collider, bool freeze)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = freeze ? rb.constraints | RigidbodyConstraints.FreezePosition : rb.constraints & ~RigidbodyConstraints.FreezePosition;
        }
    }

    public static void SetRigidbodyFreezeRotation(this Collider collider, bool freeze)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = freeze ? rb.constraints | RigidbodyConstraints.FreezeRotation : rb.constraints & ~RigidbodyConstraints.FreezeRotation;
        }
    }

    public static void SetRigidbodyFreezePositionX(this Collider collider, bool freeze)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = freeze ? rb.constraints | RigidbodyConstraints.FreezePositionX : rb.constraints & ~RigidbodyConstraints.FreezePositionX;
        }
    }

    public static void SetRigidbodyFreezePositionY(this Collider collider, bool freeze)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = freeze ? rb.constraints | RigidbodyConstraints.FreezePositionY : rb.constraints & ~RigidbodyConstraints.FreezePositionY;
        }
    }

    public static void SetRigidbodyFreezePositionZ(this Collider collider, bool freeze)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = freeze ? rb.constraints | RigidbodyConstraints.FreezePositionZ : rb.constraints & ~RigidbodyConstraints.FreezePositionZ;
        }
    }

    public static void SetRigidbodyFreezeRotationX(this Collider collider, bool freeze)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = freeze ? rb.constraints | RigidbodyConstraints.FreezeRotationX : rb.constraints & ~RigidbodyConstraints.FreezeRotationX;
        }
    }

    public static void SetRigidbodyFreezeRotationY(this Collider collider, bool freeze)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = freeze ? rb.constraints | RigidbodyConstraints.FreezeRotationY : rb.constraints & ~RigidbodyConstraints.FreezeRotationY;
        }
    }

    public static void SetRigidbodyFreezeRotationZ(this Collider collider, bool freeze)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = freeze ? rb.constraints | RigidbodyConstraints.FreezeRotationZ : rb.constraints & ~RigidbodyConstraints.FreezeRotationZ;
        }
    }

    public static void SetRigidbodyMaxAngularVelocity(this Collider collider, float maxAngularVelocity)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.maxAngularVelocity = maxAngularVelocity;
        }
    }

    public static void SetRigidbodySleepThreshold(this Collider collider, float sleepThreshold)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.sleepThreshold = sleepThreshold;
        }
    }

    public static bool RaycastFromCollider(this Collider collider, Vector3 direction, out RaycastHit hit, float maxDistance = Mathf.Infinity)
    {
        return Physics.Raycast(collider.transform.position, direction, out hit, maxDistance);
    }

    public static bool RaycastFromCollider(this Collider collider, Vector3 direction, out RaycastHit hit, float maxDistance, int layerMask)
    {
        return Physics.Raycast(collider.transform.position, direction, out hit, maxDistance, layerMask);
    }

    public static bool RaycastFromCollider(this Collider collider, Vector3 direction, out RaycastHit hit, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
    {
        return Physics.Raycast(collider.transform.position, direction, out hit, maxDistance, layerMask, queryTriggerInteraction);
    }


    public static bool RaycastTriggerOnly(this Collider collider, Vector3 direction, out RaycastHit hit, float maxDistance = Mathf.Infinity)
    {
        return Physics.Raycast(collider.transform.position, direction, out hit, maxDistance, Physics.AllLayers, QueryTriggerInteraction.Collide);
    }

    public static bool IsTouchingAnyCollider(this Collider collider)
    {
        Collider[] colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents);
        return colliders.Length > 0;
    }

    public static bool IsTouchingAnyCollider(this Collider collider, int layerMask)
    {
        Collider[] colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, Quaternion.identity, layerMask);
        return colliders.Length > 0;
    }

    public static bool IsTouchingColliderWithTag(this Collider collider, string tag)
    {
        Collider[] colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents);
        foreach (Collider c in colliders)
        {
            if (c.CompareTag(tag))
                return true;
        }
        return false;
    }

    public static float GetRigidbodyMass(this Collider collider)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        return rb != null ? rb.mass : 0f;
    }

    public static bool IsInLayer(this Collider collider, LayerMask layerMask)
    {
        return (layerMask.value & (1 << collider.gameObject.layer)) > 0;
    }

    public static bool IsInLayer(this Collider collider, int layer)
    {
        return collider.gameObject.layer == layer;
    }

    public static bool IsInLayer(this Collider collider, string layerName)
    {
        return collider.gameObject.layer == LayerMask.NameToLayer(layerName);
    }

    public static Vector3 GetSurfaceNormal(this Collider collider, RaycastHit hit)
    {
        return hit.normal;
    }

    public static Vector3 GetVelocityAtContactPoint(this Collider collider, RaycastHit hit)
    {
        Rigidbody rb = collider.GetAttachedRigidbody();
        return rb != null ? rb.GetPointVelocity(hit.point) : Vector3.zero;
    }

    public static Vector3 GetAngularVelocityAtContactPoint(this Collider collider, RaycastHit hit)
    {
        Rigidbody rb = collider.GetAttachedRigidbody();
        return rb != null ? rb.GetPointVelocity(hit.point) : Vector3.zero;
    }


}
