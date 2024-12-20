using System;
using UnityEngine;

public static class RigidbodyExtensions
{
    public static void ApplyLocalForce(this Rigidbody rb, Vector3 force)
    {
        rb.AddForce(rb.transform.TransformDirection(force));
    }

    public static void ApplyLocalTorque(this Rigidbody rb, Vector3 torque)
    {
        rb.AddTorque(rb.transform.TransformDirection(torque));
    }

    public static void SetVelocityX(this Rigidbody rb, float velocity)
    {
        rb.velocity = new Vector3(velocity, rb.velocity.y, rb.velocity.z);
    }

    public static void SetVelocityY(this Rigidbody rb, float velocity)
    {
        rb.velocity = new Vector3(rb.velocity.x, velocity, rb.velocity.z);
    }

    public static void SetVelocityZ(this Rigidbody rb, float velocity)
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, velocity);
    }


    public static void AddDampedForce(this Rigidbody rb, Vector3 force, float damping)
    {
        rb.AddForce(force * damping);
    }

    public static float GetSquaredVelocityMagnitude(this Rigidbody rb)
    {
        return rb.velocity.sqrMagnitude;
    }

    public static void ApplyForceDelayed(this Rigidbody rb, Vector3 force, float delay)
    {
        rb.GetComponent<MonoBehaviour>().StartCoroutine(ApplyForceAfterDelay(rb, force, delay));
    }

    private static IEnumerator ApplyForceAfterDelay(Rigidbody rb, Vector3 force, float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.AddForce(force);
    }

    public static void SetAngularVelocity(this Rigidbody rb, Vector3 angularVelocity)
    {
        rb.angularVelocity = angularVelocity;
    }

    public static float GetAngularVelocityMagnitude(this Rigidbody rb)
    {
        return rb.angularVelocity.magnitude;
    }

    public static void RotateToAngle(this Rigidbody rb, Vector3 targetRotation, float speed)
    {
        Vector3 rotation = Vector3.RotateTowards(rb.transform.forward, targetRotation, speed * Time.deltaTime, 0.0f);
        rb.rotation = Quaternion.LookRotation(rotation);
    }

    public static void SetVelocityTo(this Rigidbody rb, Vector3 targetVelocity)
    {
        rb.velocity = targetVelocity;
    }

    public static void ApplyImpulseAtPoint(this Rigidbody rb, Vector3 impulse, Vector3 point)
    {
        rb.AddForceAtPosition(impulse, point, ForceMode.Impulse);
    }

    public static void SetPositionDirectly(this Rigidbody rb, Vector3 position)
    {
        rb.position = position;
    }

    public static void ApplyExplosionForce(this Rigidbody rb, float explosionForce, Vector3 explosionPosition, float radius)
    {
        rb.AddExplosionForce(explosionForce, explosionPosition, radius);
    }


    public static void ApplyDragForce(this Rigidbody rb, float dragCoefficient)
    {
        rb.drag = dragCoefficient;
    }



    public static void ApplyAngularDrag(this Rigidbody rb, float angularDragCoefficient)
    {
        rb.angularDrag = angularDragCoefficient;
    }

    public static void Sleep(this Rigidbody rb)
    {
        rb.Sleep();
    }

    public static void WakeUp(this Rigidbody rb)
    {
        rb.WakeUp();
    }


    public static bool IsSleeping(this Rigidbody rb)
    {
        return rb.IsSleeping();
    }


    public static void SetRandomVelocity(this Rigidbody rb, float minSpeed, float maxSpeed)
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Random.onUnitSphere * speed;
    }

    public static void ResetVelocity(this Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
    }


    public static void ResetAngularVelocity(this Rigidbody rb)
    {
        rb.angularVelocity = Vector3.zero;
    }

    public static void ApplyForceThroughRaycast(this Rigidbody rb, Vector3 direction, float distance)
    {
        RaycastHit hit;
        if (Physics.Raycast(rb.position, direction, out hit, distance))
        {
            rb.AddForceAtPosition(direction * hit.distance, hit.point);
        }
    }

    public static void ApplyImpulseByDistance(this Rigidbody rb, float force, float distance)
    {
        Vector3 direction = (rb.transform.position - Camera.main.transform.position).normalized;
        rb.AddForce(direction * force * distance, ForceMode.Impulse);
    }

    public static void MoveTowardsPoint(this Rigidbody rb, Vector3 targetPoint, float speed)
    {
        Vector3 direction = (targetPoint - rb.position).normalized;
        rb.AddForce(direction * speed);
    }

    public static void ApplyForceForDuration(this Rigidbody rb, Vector3 force, float duration)
    {
        rb.AddForce(force, ForceMode.Force);
        rb.GetComponent<MonoBehaviour>().StartCoroutine(StopForceAfterDuration(rb, duration));
    }

    private static IEnumerator StopForceAfterDuration(Rigidbody rb, float duration)
    {
        yield return new WaitForSeconds(duration);
        rb.velocity = Vector3.zero;
    }

    public static void IgnoreGravityForTime(this Rigidbody rb, float time)
    {
        rb.useGravity = false;
        rb.GetComponent<MonoBehaviour>().StartCoroutine(RestoreGravityAfterTime(rb, time));
    }

    private static IEnumerator RestoreGravityAfterTime(Rigidbody rb, float time)
    {
        yield return new WaitForSeconds(time);
        rb.useGravity = true;
    }

    public static float GetSpeedInForwardDirection(this Rigidbody rb)
    {
        return Vector3.Dot(rb.velocity, rb.transform.forward);
    }

    public static void ApplyForceByMass(this Rigidbody rb, Vector3 force)
    {
        rb.AddForce(force * rb.mass, ForceMode.Force);
    }


    public static void StopAtPosition(this Rigidbody rb, Vector3 position)
    {
        if (Vector3.Distance(rb.position, position) < 0.1f)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public static void ApplyStopImpulse(this Rigidbody rb)
    {
        rb.AddForce(-rb.velocity, ForceMode.Impulse);
    }

    public static void SmoothMoveToPoint(this Rigidbody rb, Vector3 targetPosition, float smoothTime)
    {
        rb.position = Vector3.SmoothDamp(rb.position, targetPosition, ref rb.velocity, smoothTime);
    }

    public static bool IsMoving(this Rigidbody rb)
    {
        return rb.velocity.magnitude > 0.1f;
    }


    public static void ApplyJumpForce(this Rigidbody rb, float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce * rb.mass, ForceMode.Impulse);
    }

    public static void RotateToAlignWithTarget(this Rigidbody rb, Vector3 targetPosition, float torqueAmount)
    {
        Vector3 directionToTarget = (targetPosition - rb.position).normalized;
        Vector3 torque = Vector3.Cross(rb.transform.forward, directionToTarget);
        rb.AddTorque(torque * torqueAmount);
    }

    public static void FreezeMovementInDirection(this Rigidbody rb, Vector3 direction)
    {
        rb.velocity = Vector3.Project(rb.velocity, direction);
    }

    public static void ResetAll(this Rigidbody rb)
    {
        rb.position = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    public static void ApplyWindResistance(this Rigidbody rb, float windForce)
    {
        rb.AddForce(-rb.velocity.normalized * windForce, ForceMode.Force);
    }

    public static void ApplyRandomTorque(this Rigidbody rb, float torqueAmount)
    {
        rb.AddTorque(Random.onUnitSphere * torqueAmount, ForceMode.Impulse);
    }

    public static void ApplyPushForce(this Rigidbody rb, float forceAmount)
    {
        rb.AddForce(rb.transform.forward * forceAmount, ForceMode.Impulse);
    }

    public static void ApplyReverseForce(this Rigidbody rb, float forceAmount)
    {
        rb.AddForce(-rb.transform.forward * forceAmount, ForceMode.Impulse);
    }

    public static bool IsMovingDown(this Rigidbody rb)
    {
        return rb.velocity.y < 0;
    }

    public static void ApplySimpleGravity(this Rigidbody rb, float gravity)
    {
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    public static void ApplyBounceForce(this Rigidbody rb, float bounceAmount)
    {
        rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y * bounceAmount, rb.velocity.z);
    }

    public static void ApplyAirResistance(this Rigidbody rb, float dragAmount)
    {
        rb.velocity *= 1 - dragAmount * Time.deltaTime;
    }

    public static bool IsMovingUp(this Rigidbody rb)
    {
        return rb.velocity.y > 0;
    }

    public static void ApplySpin(this Rigidbody rb, float torqueAmount)
    {
        rb.AddTorque(Vector3.up * torqueAmount, ForceMode.VelocityChange);
    }

    public static void ApplyImpulseAtHeight(this Rigidbody rb, float impulseForce, float height)
    {
        Vector3 position = new Vector3(rb.position.x, height, rb.position.z);
        rb.AddForceAtPosition(Vector3.up * impulseForce, position, ForceMode.Impulse);
    }


    public static void ApplyThrustForce(this Rigidbody rb, float thrustAmount)
    {
        rb.AddForce(rb.transform.forward * thrustAmount, ForceMode.Acceleration);
    }

    public static void ApplyReverseThrust(this Rigidbody rb, float thrustAmount)
    {
        rb.AddForce(-rb.transform.forward * thrustAmount, ForceMode.Acceleration);
    }

    public static void ApplyMagneticForce(this Rigidbody rb, Vector3 targetPosition, float magneticStrength)
    {
        Vector3 direction = (targetPosition - rb.position).normalized;
        rb.AddForce(direction * magneticStrength, ForceMode.Force);
    }

    public static void ApplyRandomDirectionalForce(this Rigidbody rb, float forceMagnitude)
    {
        Vector3 randomDirection = Random.onUnitSphere;
        rb.AddForce(randomDirection * forceMagnitude, ForceMode.Impulse);
    }

    public static void ApplyConstantForce(this Rigidbody rb, Vector3 direction, float forceMagnitude)
    {
        rb.AddForce(direction.normalized * forceMagnitude, ForceMode.Force);
    }

    public static void ApplyUpwardThrust(this Rigidbody rb, float thrustAmount)
    {
        rb.AddForce(Vector3.up * thrustAmount, ForceMode.VelocityChange);
    }

    public static void SetVelocityByDirection(this Rigidbody rb, Vector3 direction, float speed)
    {
        rb.velocity = direction.normalized * speed;
    }

    public static void ApplyShakeForce(this Rigidbody rb, float shakeMagnitude)
    {
        Vector3 shakeForce = new Vector3(Random.Range(-shakeMagnitude, shakeMagnitude), 0, Random.Range(-shakeMagnitude, shakeMagnitude));
        rb.AddForce(shakeForce, ForceMode.Impulse);
    }

    public static void ApplyGroundSlamForce(this Rigidbody rb, float slamForce)
    {
        rb.AddForce(Vector3.down * slamForce, ForceMode.Impulse);
    }

    public static void ApplyLiftOffForce(this Rigidbody rb, float liftForce)
    {
        rb.AddForce(Vector3.up * liftForce, ForceMode.VelocityChange);
    }

    public static void ApplyForceInDirectionOfVelocity(this Rigidbody rb, float forceAmount)
    {
        rb.AddForce(rb.velocity.normalized * forceAmount, ForceMode.VelocityChange);
    }

    public static void ApplyForceTowardsCamera(this Rigidbody rb, float forceAmount)
    {
        Vector3 direction = (Camera.main.transform.position - rb.position).normalized;
        rb.AddForce(direction * forceAmount, ForceMode.Force);
    }

    public static void ApplyRadialForce(this Rigidbody rb, Vector3 point, float forceAmount)
    {
        Vector3 direction = (rb.position - point).normalized;
        rb.AddForce(direction * forceAmount, ForceMode.Force);
    }

    public static void ApplyImpulseBySpeed(this Rigidbody rb, float speedMultiplier)
    {
        rb.AddForce(rb.velocity.normalized * speedMultiplier, ForceMode.Impulse);
    }


    public static void ApplyImpulseBySpeed(this Rigidbody rb, float speedMultiplier)
    {
        rb.AddForce(rb.velocity.normalized * speedMultiplier, ForceMode.Impulse);
    }

    public static void ApplyReverseForceBasedOnVelocity(this Rigidbody rb, float forceAmount)
    {
        rb.AddForce(-rb.velocity.normalized * forceAmount, ForceMode.VelocityChange);


    }


    public static void ApplyKnockbackForce(this Rigidbody rb, Vector3 impactPoint, float knockbackStrength)
    {
        Vector3 direction = (rb.position - impactPoint).normalized;
        rb.AddForce(direction * knockbackStrength, ForceMode.Impulse);
    }

    public static void ApplyCustomGravity(this Rigidbody rb, float gravityAmount)
    {
        rb.AddForce(Vector3.down * gravityAmount, ForceMode.Acceleration);
    }

    public static void ApplyShockwaveForce(this Rigidbody rb, float shockwaveStrength, Vector3 center)
    {
        Vector3 direction = (rb.position - center).normalized;
        rb.AddForce(direction * shockwaveStrength, ForceMode.Impulse);

    }

    public static void ApplyExplosionForce(this Rigidbody rb, float explosionStrength, Vector3 explosionPoint)
    {
        Vector3 direction = (rb.position - explosionPoint).normalized;
        rb.AddForce(direction * explosionStrength, ForceMode.Impulse);
    }

    public static void ApplySpringForce(this Rigidbody rb, Vector3 targetPosition, float springStrength)
    {
        Vector3 direction = (targetPosition - rb.position);
        rb.AddForce(direction * springStrength, ForceMode.Force);
    }

    public static void ApplyImpactForce(this Rigidbody rb, float impactMultiplier)
    {
        rb.AddForce(-rb.velocity.normalized * impactMultiplier, ForceMode.Impulse);
    }

    public static void ApplyAcceleratingForce(this Rigidbody rb, float acceleration)
    {
        rb.AddForce(rb.transform.forward * acceleration * Time.deltaTime, ForceMode.Acceleration);
    }


    public static void ApplyMagneticForce(this Rigidbody rb, Vector3 targetPosition, float magneticStrength)
    {
        Vector3 direction = (targetPosition - rb.position).normalized;
        rb.AddForce(direction * magneticStrength, ForceMode.Force);
    }


    public static void ApplyUpwardForce(this Rigidbody rb, float upwardStrength)
    {
        rb.AddForce(Vector3.up * upwardStrength, ForceMode.Impulse);
    }

    public static void ApplyGravitationalAnomalyForce(this Rigidbody rb, Vector3 anomalyCenter, float anomalyStrength)
    {
        Vector3 direction = (rb.position - anomalyCenter).normalized;
        rb.AddForce(direction * anomalyStrength, ForceMode.Acceleration);
    }

    public static void ApplyRandomPushForce(this Rigidbody rb, float forceStrength)
    {
        Vector3 randomDirection = Random.onUnitSphere;
        rb.AddForce(randomDirection * forceStrength, ForceMode.Force);
    }

    public static void ApplyHeavyLandingForce(this Rigidbody rb, float landingStrength)
    {
        rb.AddForce(Vector3.down * landingStrength, ForceMode.Impulse);
    }

    public static void ApplySlipperySurfaceForce(this Rigidbody rb, float frictionFactor)
    {
        rb.velocity *= 1 - frictionFactor * Time.deltaTime;
    }






// Extension method to make the Rigidbody always walk on any surface with flexible surface detection
    public static void WalkOnSurface(this Rigidbody rb, float downwardForce = 9.81f, float maxRaycastDistance = 1.5f, 
                                     ISurface surfaceHelper = null, bool useCustomSurface = false)
    {
        // Raycast hit information
        RaycastHit hit;

        // Perform the raycast downward to check the surface directly below the object
        if (Physics.Raycast(rb.position, Vector3.down, out hit, maxRaycastDistance))
        {
            // Check if custom surface logic is needed
            if (useCustomSurface && surfaceHelper != null)
            {
                // Use the custom surface logic from the helper interface
                Vector3 surfaceNormal = surfaceHelper.GetSurfaceNormal(rb.position);
                float gravityStrength = surfaceHelper.GetGravityStrength();

                // Apply custom gravity based on the surface's normal and strength
                Vector3 forceDirection = -surfaceNormal * gravityStrength;
                rb.AddForce(forceDirection, ForceMode.Acceleration);
            }
            else
            {
                // Default behavior: Apply standard gravity or downward force based on surface normal
                Vector3 forceDirection = Vector3.zero;

                // Use the surface normal from the raycast hit
                if (hit.normal != Vector3.up) // Surface is not flat, so consider the normal
                {
                    forceDirection = -hit.normal * downwardForce;
                }
                else
                {
                    // Standard gravity pull when on a flat surface
                    forceDirection = Vector3.down * downwardForce;
                }

                // Apply the force to simulate gravity
                rb.AddForce(forceDirection, ForceMode.Acceleration);
            }
        }
    }












}
