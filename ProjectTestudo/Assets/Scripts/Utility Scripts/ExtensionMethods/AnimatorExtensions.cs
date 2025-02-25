using System;
using UnityEngine;

public static class AnimatorExtensions
{
    /// <summary>
    /// Sets the boolean parameter of the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="name">The name of the boolean parameter.</param>
    /// <param name="value">The value to set the boolean parameter to.</param>
    public static void SetBool(this Animator animator, string name, bool value)
    {
        animator.SetBool(name, value);
    }

    /// <summary>
    /// Sets the float parameter of the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="name">The name of the float parameter.</param>
    /// <param name="value">The value to set the float parameter to.</param>
    public static void SetFloat(this Animator animator, string name, float value)
    {
        animator.SetFloat(name, value);
    }

    /// <summary>
    /// Sets the integer parameter of the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="name">The name of the integer parameter.</param>
    /// <param name="value">The value to set the integer parameter to.</param>
    public static void SetInt(this Animator animator, string name, int value)
    {
        animator.SetInteger(name, value);
    }

    /// <summary>
    /// Sets the trigger parameter of the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="name">The name of the trigger parameter.</param>
    public static void SetTrigger(this Animator animator, string name)
    {
        animator.SetTrigger(name);
    }

    /// <summary>
    /// Resets the trigger parameter of the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="name">The name of the trigger parameter.</param>
    public static void ResetTrigger(this Animator animator, string name)
    {
        animator.ResetTrigger(name);
    }

    /// <summary>
    /// Plays the specified animation state in the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="stateName">The name of the state to play.</param>
    /// <param name="layer">The layer index (default is -1).</param>
    public static void Play(this Animator animator, string stateName, int layer = -1)
    {
        animator.Play(stateName, layer);
    }

    /// <summary>
    /// Cross fades to the specified animation state in the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="stateName">The name of the state to cross fade to.</param>
    /// <param name="transitionDuration">The duration of the cross fade transition.</param>
    /// <param name="layer">The layer index (default is -1).</param>
    public static void CrossFade(this Animator animator, string stateName, float transitionDuration, int layer = -1)
    {
        animator.CrossFade(stateName, transitionDuration, layer);
    }

    /// <summary>
    /// Cross fades to the specified animation state in the animator with a fixed time.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="stateName">The name of the state to cross fade to.</param>
    /// <param name="transitionDuration">The duration of the cross fade transition.</param>
    /// <param name="layer">The layer index (default is -1).</param>
    public static void CrossFadeInFixedTime(this Animator animator, string stateName, float transitionDuration, int layer = -1)
    {
        animator.CrossFadeInFixedTime(stateName, transitionDuration, layer);
    }

    /// <summary>
    /// Plays the specified animation state in the animator with a fixed time.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="stateName">The name of the state to play.</param>
    /// <param name="layer">The layer index (default is -1).</param>
    public static void PlayInFixedTime(this Animator animator, string stateName, int layer = -1)
    {
        animator.PlayInFixedTime(stateName, layer);
    }

    /// <summary>
    /// Sets the weight of a specific animation layer.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="layerIndex">The index of the animation layer.</param>
    /// <param name="weight">The weight to set for the layer.</param>
    public static void SetLayerWeight(this Animator animator, int layerIndex, float weight)
    {
        animator.SetLayerWeight(layerIndex, weight);
    }

    /// <summary>
    /// Gets the weight of a specific animation layer.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <param name="layerIndex">The index of the animation layer.</param>
    /// <returns>The weight of the specified layer.</returns>
    public static float GetLayerWeight(this Animator animator, int layerIndex)
    {
        return animator.GetLayerWeight(layerIndex);
    }

    /// <summary>
    /// Sets the position of an IK goal.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="goal">The IK goal (e.g., LeftFoot, RightHand).</param>
    /// <param name="position">The world position to set.</param>
    public static void SetIKPosition(this Animator animator, AvatarIKGoal goal, Vector3 position)
    {
        animator.SetIKPosition(goal, position);
    }

    /// <summary>
    /// Sets the rotation of an IK goal.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="goal">The IK goal (e.g., LeftFoot, RightHand).</param>
    /// <param name="rotation">The world rotation to set.</param>
    public static void SetIKRotation(this Animator animator, AvatarIKGoal goal, Quaternion rotation)
    {
        animator.SetIKRotation(goal, rotation);
    }

    /// <summary>
    /// Sets the weight for the position of an IK goal.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="goal">The IK goal (e.g., LeftFoot, RightHand).</param>
    /// <param name="weight">The weight to set for the IK position.</param>
    public static void SetIKPositionWeight(this Animator animator, AvatarIKGoal goal, float weight)
    {
        animator.SetIKPositionWeight(goal, weight);
    }

    /// <summary>
    /// Sets the weight for the rotation of an IK goal.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="goal">The IK goal (e.g., LeftFoot, RightHand).</param>
    /// <param name="weight">The weight to set for the IK rotation.</param>
    public static void SetIKRotationWeight(this Animator animator, AvatarIKGoal goal, float weight)
    {
        animator.SetIKRotationWeight(goal, weight);
    }

    /// <summary>
    /// Sets the look-at weight of the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="weight">The weight to set for the look-at effect.</param>
    public static void SetLookAtWeight(this Animator animator, float weight)
    {
        animator.SetLookAtWeight(weight);
    }

    /// <summary>
    /// Sets the speed of the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="speed">The speed value to set.</param>
    public static void SetSpeed(this Animator animator, float speed)
    {
        animator.speed = speed;
    }

    /// <summary>
    /// Gets the speed of the animator.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <returns>The current speed of the animator.</returns>
    public static float GetSpeed(this Animator animator)
    {
        return animator.speed;
    }

    /// <summary>
    /// Plays the specified animation by name.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="animationName">The name of the animation to play.</param>
    public static void PlayAnimation(this Animator animator, string animationName)
    {
        animator.Play(animationName);
    }

    /// <summary>
    /// Checks if the specified animation is currently playing.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <param name="animationName">The name of the animation to check.</param>
    /// <returns>True if the animation is currently playing, otherwise false.</returns>
    public static bool IsPlaying(this Animator animator, string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

    /// <summary>
    /// Cross fades to the specified state in the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="stateName">The name of the state to cross fade to.</param>
    /// <param name="transitionDuration">The duration of the transition.</param>
    public static void CrossFadeToState(this Animator animator, string stateName, float transitionDuration)
    {
        animator.CrossFade(stateName, transitionDuration);
    }

    /// <summary>
    /// Cross fades to the specified state in the animator with a specific layer.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="stateName">The name of the state to cross fade to.</param>
    /// <param name="transitionDuration">The duration of the transition.</param>
    /// <param name="layer">The layer index.</param>
    public static void CrossFadeToState(this Animator animator, string stateName, float transitionDuration, int layer)
    {
        animator.CrossFade(stateName, transitionDuration, layer);
    }

    /// <summary>
    /// Gets the current normalized time of the animation.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <returns>The normalized time of the current animation.</returns>
    public static float GetCurrentNormalizedTime(this Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    /// <summary>
    /// Gets the length of the current animation.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <returns>The length of the current animation.</returns>
    public static float GetCurrentAnimationLength(this Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length;
    }

    /// <summary>
    /// Resets all parameters in the animator to their default values.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
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

    /// <summary>
    /// Sets a parameter value based on its type.
    /// </summary>
    /// <typeparam name="T">The type of the parameter (bool, float, int, or string).</typeparam>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <param name="value">The value to set the parameter to.</param>
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

    /// <summary>
    /// Sets the speed of the animation state.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="speed">The speed to set for the animation state.</param>
    public static void SetAnimationStateSpeed(this Animator animator, float speed)
    {
        animator.speed = speed;
    }

    /// <summary>
    /// Checks if the current animation is looping.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <returns>True if the current animation is looping, otherwise false.</returns>
    public static bool IsAnimationLooping(this Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).loop;
    }

    /// <summary>
    /// Checks if the animator is currently transitioning between states.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <returns>True if the animator is transitioning, otherwise false.</returns>
    public static bool IsTransitioning(this Animator animator)
    {
        return animator.IsInTransition(0);
    }

    /// <summary>
    /// Gets the name of the next animation state.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <returns>The name of the next animation state, or null if there is no transition.</returns>
    public static string GetNextAnimationName(this Animator animator)
    {
        var transition = animator.GetAnimatorTransitionInfo(0);
        return transition.IsName("") ? null : transition.nameHash.ToString();
    }

    /// <summary>
    /// Sets the time scale for the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="timeScale">The time scale to set for the animator.</param>
    public static void SetAnimationTimeScale(this Animator animator, float timeScale)
    {
        animator.speed = timeScale;
    }

    /// <summary>
    /// Gets the total time of all animations in the animator.
    /// </summary>
    /// <param name="animator">The Animator component to query.</param>
    /// <returns>The total time of all animations in the animator.</returns>
    public static float GetTotalAnimationTime(this Animator animator)
    {
        float totalTime = 0f;
        foreach (var state in animator.GetCurrentAnimatorClipInfo(0))
        {
            totalTime += state.clip.length;
        }
        return totalTime;
    }

    /// <summary>
    /// Pauses all animations in the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    public static void PauseAnimations(this Animator animator)
    {
        animator.speed = 0;
    }

    /// <summary>
    /// Resumes all animations in the animator.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    public static void ResumeAnimations(this Animator animator)
    {
        animator.speed = 1;
    }

    /// <summary>
    /// Cross fades between two animation states.
    /// </summary>
    /// <param name="animator">The Animator component to modify.</param>
    /// <param name="fromState">The name of the state to fade from.</param>
    /// <param name="toState">The name of the state to fade to.</param>
    /// <param name="duration">The duration of the fade.</param>
    public static void FadeBetweenStates(this Animator animator, string fromState, string toState, float duration)
    {
        animator.CrossFade(fromState, duration);
    }
}
