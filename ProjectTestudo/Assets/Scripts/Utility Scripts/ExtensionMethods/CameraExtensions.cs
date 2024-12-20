using System;
using System.Collections;
using System.Collections.Generic;  
using UnityEngine;

public static class CameraExtensions
{
    private static MonoBehaviour coroutineRunner;

    public static void Initialize(MonoBehaviour runner)
    {
        coroutineRunner = runner;
    }

    public static void ShakeScreen(this Camera camera, float magnitude, float duration)
    {
        coroutineRunner.StartCoroutine(ShakeScreenCoroutine(camera, magnitude, duration));
    }

    private static IEnumerator ShakeScreenCoroutine(Camera camera, float magnitude, float duration)
    {
        Vector3 originalPosition = camera.transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            camera.transform.position = originalPosition + UnityEngine.Random.insideUnitSphere * magnitude;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        camera.transform.position = originalPosition;
    }

    public static void SetFieldOfView(this Camera camera, float fov)
    {
        camera.fieldOfView = fov;
    }

    public static void SetBackgroundColor(this Camera camera, Color color)
    {
        camera.backgroundColor = color;
    }

    public static void FadeOut(this Camera camera, float duration)
    {
        coroutineRunner.StartCoroutine(FadeOutCoroutine(camera, duration));
    }

    private static IEnumerator FadeOutCoroutine(Camera camera, float duration)
    {
        float startAlpha = camera.backgroundColor.a;
        float timer = 0;
        while (timer < duration)
        {
            Color newColor = camera.backgroundColor;
            newColor.a = Mathf.Lerp(startAlpha, 0, timer / duration);
            camera.backgroundColor = newColor;
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public static void FadeIn(this Camera camera, float duration)
    {
        coroutineRunner.StartCoroutine(FadeInCoroutine(camera, duration));
    }

    private static IEnumerator FadeInCoroutine(Camera camera, float duration)
    {
        float startAlpha = camera.backgroundColor.a;
        float timer = 0;
        while (timer < duration)
        {
            Color newColor = camera.backgroundColor;
            newColor.a = Mathf.Lerp(startAlpha, 1, timer / duration);
            camera.backgroundColor = newColor;
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public static void MoveToPosition(this Camera camera, Vector3 targetPosition, float speed)
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, speed * Time.deltaTime);
    }

    public static void RotateToRotation(this Camera camera, Quaternion targetRotation, float speed)
    {
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    public static void LookAt(this Camera camera, Transform target)
    {
        camera.transform.LookAt(target);
    }

    public static void LookAt(this Camera camera, Vector3 target)
    {
        camera.transform.LookAt(target);
    }

    public static void LookAt(this Camera camera, GameObject target)
    {
        camera.transform.LookAt(target.transform);
    }

    public static void Follow(this Camera camera, Transform target, Vector3 offset)
    {
        camera.transform.position = target.position + offset;
    }

    public static void Follow(this Camera camera, GameObject target, Vector3 offset)
    {
        camera.transform.position = target.transform.position + offset;
    }

    public static void Follow(this Camera camera, Vector3 target, Vector3 offset)
    {
        camera.transform.position = target + offset;
    }

    public static void Follow(this Camera camera, Transform target, Vector3 offset, float speed)
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, target.position + offset, speed * Time.deltaTime);
    }

    public static void Follow(this Camera camera, GameObject target, Vector3 offset, float speed)
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, target.transform.position + offset, speed * Time.deltaTime);
    }

    public static void Follow(this Camera camera, Vector3 target, Vector3 offset, float speed)
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, target + offset, speed * Time.deltaTime);
    }

    public static void ZoomIn(this Camera camera, float amount)
    {
        camera.fieldOfView -= amount;
    }

    public static void ZoomOut(this Camera camera, float amount)
    {
        camera.fieldOfView += amount;
    }

    public static void SetPosition(this Camera camera, Vector3 position)
    {
        camera.transform.position = position;
    }

    public static void SetRotation(this Camera camera, Quaternion rotation)
    {
        camera.transform.rotation = rotation;
    }

    public static void LockRotationAxis(this Camera camera, Vector3 lockedAxis)
    {
        camera.transform.eulerAngles = new Vector3(camera.transform.eulerAngles.x * lockedAxis.x,
                                                    camera.transform.eulerAngles.y * lockedAxis.y,
                                                    camera.transform.eulerAngles.z * lockedAxis.z);
    }

    public static void ResetPosition(this Camera camera, Vector3 targetPosition)
    {
        camera.transform.position = targetPosition;
    }

    public static void FollowTarget(this Camera camera, Transform target, float speed)
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, target.position, speed * Time.deltaTime);
    }

    public static void LookAtTarget(this Camera camera, Transform target)
    {
        camera.transform.LookAt(target);
    }

    public static void RotateAroundTarget(this Camera camera, Transform target, float speed, Vector3 axis)
    {
        camera.transform.RotateAround(target.position, axis, speed * Time.deltaTime);
    }

    public static void ToggleBackgroundColor(this Camera camera, Color colorA, Color colorB)
    {
        camera.backgroundColor = camera.backgroundColor == colorA ? colorB : colorA;
    }

    public static void SetBackgroundColor(this Camera camera, Color colorA, Color colorB, float duration)
    {
        coroutineRunner.StartCoroutine(ChangeBackgroundColorCoroutine(camera, colorA, colorB, duration));
    }

    private static IEnumerator ChangeBackgroundColorCoroutine(Camera camera, Color colorA, Color colorB, float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            camera.backgroundColor = Color.Lerp(colorA, colorB, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public static void SetRenderTarget(this Camera camera, RenderTexture renderTexture)
    {
        camera.targetTexture = renderTexture;
    }
}
