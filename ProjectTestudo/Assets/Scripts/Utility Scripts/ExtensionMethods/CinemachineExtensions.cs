﻿using System;
using UnityEngine;
using UnityEngine.Cinemachine;

public static class CinemachineExtensions
{
    public static void SetLookAtTarget(this CinemachineVirtualCamera virtualCamera, Transform target)
    {
        CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent < CinemachineTransposer
    }

    public static void SetLookAtTarget(this CinemachineVirtualCamera virtualCamera, Vector3 target)
    {
        CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent < CinemachineTransposer
    }

    public static void SetLookAtTarget(this CinemachineVirtualCamera virtualCamera, GameObject target)
    {
        CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent < CinemachineTransposer
    }

    public static void Zoom(this CinemachineVirtualCamera vcam, float zoomAmount)
    {
        vcam.m_Lens.FieldOfView = Mathf.Clamp(vcam.m_Lens.FieldOfView + zoomAmount, 10f, 90f);
    }

    public static void SetCameraEnabled(this CinemachineVirtualCamera vcam, bool isEnabled)
    {
        vcam.gameObject.SetActive(isEnabled);
    }


    public static void SetPriority(this CinemachineVirtualCamera vcam, int priority)
    {
        vcam.m_Priority = priority;
    }

    public static void SetFollowTarget(this CinemachineVirtualCamera vcam, Transform target)
    {
        vcam.Follow = target;
    }

    public static void SetFollowDistance(this CinemachineVirtualCamera vcam, float distance)
    {
        if (vcam.GetCinemachineComponent<CinemachineTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 0, -distance);
        }
    }

    public static void SetPosition(this CinemachineVirtualCamera vcam, Vector3 targetPosition)
    {
        vcam.transform.position = targetPosition;
    }

    public static void SetDamping(this CinemachineVirtualCamera vcam, float damping)
    {
        if (vcam.GetCinemachineComponent<CinemachineTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = damping;
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = damping;
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_ZDamping = damping;
        }
    }

    public static void SetDeadZoneWidth(this CinemachineVirtualCamera vcam, float width)
    {
        if (vcam.GetCinemachineComponent<CinemachineComposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = width;
        }
    }

    public static void SetOrbitRadius(this CinemachineVirtualCamera vcam, float radius)
    {
        if (vcam.GetCinemachineComponent<CinemachineOrbitalTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_FollowOffset = new Vector3(0, 0, -radius);
        }
    }

    public static void SetTiltAngle(this CinemachineVirtualCamera vcam, float tilt)
    {
        if (vcam.GetCinemachineComponent<CinemachineOrbitalTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_Rotation = tilt;
        }
    }

    public static void SetFollowSpeed(this CinemachineVirtualCamera vcam, float speed)
    {
        if (vcam.GetCinemachineComponent<CinemachineTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = speed;
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = speed;
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_ZDamping = speed;
        }
    }

    public static void SetLookaheadTime(this CinemachineVirtualCamera vcam, float time)
    {
        if (vcam.GetCinemachineComponent<CinemachineFramingTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_LookaheadTime = time;
        }
    }

    public static void SetMaxZoomLevel(this CinemachineVirtualCamera vcam, float zoomLevel)
    {
        if (vcam.GetCinemachineComponent<CinemachineTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 0, -zoomLevel);
        }
    }

    public static void SetSoftZoneWidth(this CinemachineVirtualCamera vcam, float width)
    {
        if (vcam.GetCinemachineComponent<CinemachineFramingTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_SoftZoneWidth = width;
        }
    }

    public static void SetFriction(this CinemachineVirtualCamera vcam, float friction)
    {
        if (vcam.GetCinemachineComponent<CinemachineTransposer>() != null)
        {
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = friction;
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = friction;
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_ZDamping = friction;
        }
    }

    public static void TransitionToCamera(this CinemachineBrain brain, CinemachineVirtualCamera targetCamera, float transitionTime)
    {
        brain.ActiveVirtualCamera = targetCamera;
        brain.m_DefaultBlend.m_Time = transitionTime;
    }

    public static void SetActiveCameraPriority(this CinemachineBrain brain, int priority)
    {
        foreach (var vcam in brain.GetComponentsInChildren<CinemachineVirtualCamera>())
        {
            vcam.m_Priority = priority;
        }
    }

    public static void FadeOut(this CinemachineBrain brain, float duration)
    {
        brain.m_DefaultBlend.m_Time = duration;
        brain.m_DefaultBlend.m_BlendStyle = CinemachineBlendDefinition.Style.Cut;
    }

    public static void FadeIn(this CinemachineBrain brain, float duration)
    {
        brain.m_DefaultBlend.m_Time = duration;
        brain.m_DefaultBlend.m_BlendStyle = CinemachineBlendDefinition.Style.Cut;
    }

    public static void SmoothlyTransitionFov(this CinemachineVirtualCamera vcam, float targetFov, float speed)
    {
        vcam.StartCoroutine(SmoothFovTransition(vcam, targetFov, speed));
    }

    private static IEnumerator SmoothFovTransition(CinemachineVirtualCamera vcam, float targetFov, float speed)
    {
        float startFov = vcam.m_Lens.FieldOfView;
        float timer = 0;
        while (timer < speed)
        {
            vcam.m_Lens.FieldOfView = Mathf.Lerp(startFov, targetFov, timer / speed);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public static void ToggleVirtualCamera(this CinemachineVirtualCamera vcam, bool isActive)
    {
        vcam.gameObject.SetActive(isActive);
    }

    public static void EnableAutoTracking(this CinemachineVirtualCamera vcam, Transform target)
    {
        vcam.Follow = target;
        vcam.LookAt = target;
    }

    public static void Shake(this CinemachineVirtualCamera vcam, float intensity, float duration)
    {
        var noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (noise != null)
        {
            noise.m_AmplitudeGain = intensity;
            noise.m_FrequencyGain = intensity;
            vcam.StartCoroutine(StopShakeAfterDuration(noise, duration));
        }
    }

    private static IEnumerator StopShakeAfterDuration(CinemachineBasicMultiChannelPerlin noise, float duration)
    {
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }
}
