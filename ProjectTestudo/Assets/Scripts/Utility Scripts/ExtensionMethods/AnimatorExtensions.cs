using System;
using UnityEngine;

public static class AnimatorExtensions
{

    public static void SetBool(this Animator animator, string name, bool value)
    {
        animator.SetBool(name, value);
    }
    public static void SetFloat(this Animator animator, string name, float value)
    {
        animator.SetFloat(name, value);
    }
    public static void SetInt(this Animator animator, string name, int value)
    {
        animator.SetInteger(name, value);
    }
    public static void SetTrigger(this Animator animator, string name)
    {
        animator.SetTrigger(name);
    }
    public static void ResetTrigger(this Animator animator, string name)
    {
        animator.ResetTrigger(name);
    }
    public static void Play(this Animator animator, string stateName, int layer = -1)
    {
        animator.Play(stateName, layer);
    }
    public static void CrossFade(this Animator animator, string stateName, float transitionDuration, int layer = -1)
    {
        animator.CrossFade(stateName, transitionDuration, layer);
    }
    public static void CrossFadeInFixedTime(this Animator animator, string stateName, float transitionDuration, int layer = -1)
    {
        animator.CrossFadeInFixedTime(stateName, transitionDuration, layer);
    }
    public static void PlayInFixedTime(this Animator animator, string stateName, int layer = -1)
    {
        animator.PlayInFixedTime(stateName, layer);
    }
    public static void SetLayerWeight(this Animator animator, int layerIndex, float weight)
    {
        animator.SetLayerWeight(layerIndex, weight);
    }
    public static float GetLayerWeight(this Animator animator, int layerIndex)
    {
        return animator.GetLayerWeight(layerIndex);
    }
    public static void SetIKPosition(this Animator animator, AvatarIKGoal goal, Vector3 position)
    {
        animator.SetIKPosition(goal, position);
    }
    public static void SetIKRotation(this Animator animator, AvatarIKGoal goal, Quaternion rotation)
    {
        animator.SetIKRotation(goal, rotation);
    }
    public static void SetIKPositionWeight(this Animator animator, AvatarIKGoal goal, float weight)
    {
        animator.SetIKPositionWeight(goal, weight);
    }
    public static void SetIKRotationWeight(this Animator animator, AvatarIKGoal goal, float weight)
    {
        animator.SetIKRotationWeight(goal, weight);
    }
    public static void SetLookAtPosition(this Animator animator, Vector3 position)
    {
        animator.SetLookAtPosition

    }


    public static void SetLookAtWeight(this Animator animator, float weight)
    {
        animator.SetLookAtWeight(weight);
    }

    public static void SetSpeed(this Animator animator, float speed)
    {
        animator.speed = speed;
    }

    public static float GetSpeed(this Animator animator)
    {
        return animator.speed;
    }


    public static void PlayAnimation(this Animator animator, string animationName)
    {
        animator.Play(animationName);
    }

    public static bool IsPlaying(this Animator animator, string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

    public static void CrossFadeToState(this Animator animator, string stateName, float transitionDuration)
    {
        animator.CrossFade(stateName, transitionDuration);
    }

    public static void CrossFadeToState(this Animator animator, string stateName, float transitionDuration, int layer)
    {
        animator.CrossFade(stateName, transitionDuration, layer);
    }

    public static string GetCurrentStateName(this Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("");
    }

    public static float GetCurrentNormalizedTime(this Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    public static float GetCurrentAnimationLength(this Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public static void ResetAllParameters(this Animator animator)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            switch (param.type)
            {
                case AnimatorControllerParameterType.Bool:
                    animator.SetBool(param.name, false);
                    break;
                case AnimatorControllerParameterType.Float:
                    animator.SetFloat(param.name, 0f);
                    break;
                case AnimatorControllerParameterType.Int:
                    animator.SetInteger(param.name, 0);
                    break;
                case AnimatorControllerParameterType.Trigger:
                    animator.ResetTrigger(param.name);
                    break;
            }
        }
    }

    public static void SetParameter<T>(this Animator animator, string parameterName, T value)
    {
        if (typeof(T) == typeof(bool))
        {
            animator.SetBool(parameterName, (bool)(object)value);
        }
        else if (typeof(T) == typeof(float))
        {
            animator.SetFloat(parameterName, (float)(object)value);
        }
        else if (typeof(T) == typeof(int))
        {
            animator.SetInteger(parameterName, (int)(object)value);
        }
        else if (typeof(T) == typeof(string))
        {
            animator.SetTrigger(parameterName);
        }
    }

    public static void SetAnimationStateSpeed(this Animator animator, float speed)
    {
        animator.speed = speed;
    }

    public static bool IsAnimationLooping(this Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).loop;
    }

    public static bool IsTransitioning(this Animator animator)
    {
        return animator.IsInTransition(0);
    }

    public static string GetNextAnimationName(this Animator animator)
    {
        var transition = animator.GetAnimatorTransitionInfo(0);
        return transition.IsName("") ? null : transition.nameHash.ToString();
    }

    public static void SetAnimationTimeScale(this Animator animator, float timeScale)
    {
        animator.speed = timeScale;
    }

    public static float GetTotalAnimationTime(this Animator animator)
    {
        float totalTime = 0f;
        foreach (var state in animator.GetCurrentAnimatorClipInfo(0))
        {
            totalTime += state.clip.length;
        }
        return totalTime;
    }

    public static void PauseAnimations(this Animator animator)
    {
        animator.speed = 0;
    }

    public static void ResumeAnimations(this Animator animator)
    {
        animator.speed = 1;
    }

    public static void AddEventToAnimation(this Animator animator, string animationName, float time, string functionName)
    {
        var clip = animator.runtimeAnimatorController.animationClips.FirstOrDefault(c => c.name == animationName);
        if (clip != null)
        {
            AnimationEvent newEvent = new AnimationEvent
            {
                time = time,
                functionName = functionName
            };
            clip.AddEvent(newEvent);
        }
    }

    public static float GetAnimationDuration(this Animator animator, string animationName)
    {
        var clip = animator.runtimeAnimatorController.animationClips.FirstOrDefault(c => c.name == animationName);
        return clip != null ? clip.length : 0f;
    }

    public static bool HasEvent(this Animator animator, string animationName, string functionName)
    {
        var clip = animator.runtimeAnimatorController.animationClips.FirstOrDefault(c => c.name == animationName);
        if (clip != null)
        {
            return clip.events.Any(e => e.functionName == functionName);
        }
        return false;
    }


    public static string GetCurrentAnimationName(this Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("");
    }

    public static void FadeBetweenStates(this Animator animator, string fromState, string toState, float duration)
    {
        animator.CrossFade(fromState, duration);
    }






}
