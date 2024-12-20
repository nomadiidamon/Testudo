using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


public static class InterfaceExtensions
{

    public static bool Implements<TInterface>(this object obj)
    {
        return obj is TInterface;
    }

    public static bool Implements<TInterface>(this Type type)
    {
        return typeof(TInterface).IsAssignableFrom(type);
    }

    public static bool TryCastTo<TInterface>(this object obj, out TInterface result)
    {
        if (obj is TInterface)
        {
            result = (TInterface)obj;
            return true;
        }
        result = default(TInterface);
        return false;
    }

    public static void InvokeMethod<TInterface>(this object obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        method?.Invoke(obj, null);
    }

    public static string GetInterfaceName<TInterface>(this TInterface obj)
    {
        return typeof(TInterface).Name;
    }

    public static bool IsOfType<TInterface>(this object obj)
    {
        return obj is TInterface;
    }

    public static bool IsOfType<TInterface>(this Type type)
    {
        return typeof(TInterface).IsAssignableFrom(type);
    }

    public static string[] GetEvents<TInterface>(this TInterface obj)
    {
        return typeof(TInterface).GetEvents().Select(e => e.Name).ToArray();
    }

    public static string[] GetProperties<TInterface>(this TInterface obj)
    {
        return typeof(TInterface).GetProperties().Select(p => p.Name).ToArray();
    }

    public static string[] GetFields<TInterface>(this TInterface obj)
    {
        return typeof(TInterface).GetFields().Select(f => f.Name).ToArray();
    }

    public static string[] GetInterfaces<TInterface>(this TInterface obj)
    {
        return typeof(TInterface).GetInterfaces().Select(i => i.Name).ToArray();
    }

    public static string[] GetAttributes<TInterface>(this TInterface obj)
    {
        return typeof(TInterface).GetCustomAttributes(true).Select(a => a.GetType().Name).ToArray();
    }

    public static string[] GetBaseTypes<TInterface>(this TInterface obj)
    {
        var type = typeof(TInterface);
        var baseTypes = new List<string>();
        while (type.BaseType != null)
        {
            baseTypes.Add(type.BaseType.Name);
            type = type.BaseType;
        }
        return baseTypes.ToArray();
    }

    public static bool HasMethod<TInterface>(this TInterface obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        return method != null;
    }

    public static bool HasProperty<TInterface>(this TInterface obj, string propertyName)
    {
        var property = typeof(TInterface).GetProperty(propertyName);
        return property != null;
    }

    public static bool HasField<TInterface>(this TInterface obj, string fieldName)
    {
        var field = typeof(TInterface).GetField(fieldName);
        return field != null;
    }

    public static bool HasEvent<TInterface>(this TInterface obj, string eventName)
    {
        var eventInfo = typeof(TInterface).GetEvent(eventName);
        return eventInfo != null;
    }

    public static bool HasInterface<TInterface>(this TInterface obj, string interfaceName)
    {
        var interfaceType = typeof(TInterface).GetInterface(interfaceName);
        return interfaceType != null;
    }

    public static bool HasAttribute<TInterface>(this TInterface obj, string attributeName)
    {
        var attribute = typeof(TInterface).GetCustomAttributes(true).FirstOrDefault(a => a.GetType().Name == attributeName);
        return attribute != null;
    }

    public static bool HasBaseType<TInterface>(this TInterface obj, string baseTypeName)
    {
        var type = typeof(TInterface);
        while (type.BaseType != null)
        {
            if (type.BaseType.Name == baseTypeName)
            {
                return true;
            }
            type = type.BaseType;
        }
        return false;
    }

    public static TInterface Clone<TInterface>(this TInterface obj) where TInterface : ICloneable
    {
        return (TInterface)obj.Clone();
    }

    public static TInterface GetDefault<TInterface>()
    {
        return default(TInterface);
    }

    public static bool ImplementsInterface<TInterface>(this object obj)
    {
        return obj.GetType().GetInterfaces().Contains(typeof(TInterface));
    }

    public static bool ImplementsInterface<TInterface>(this Type type)
    {
        return type.GetInterfaces().Contains(typeof(TInterface));
    }

    public static string ImplementsInterface<TInterface>(this TInterface obj)
    {
        return obj.GetType().GetInterfaces().Contains(typeof(TInterface)).ToString();
    }

    public static Type[] GetMethodParameterTypes<TInterface>(this TInterface obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        return method?.GetParameters().Select(p => p.ParameterType).ToArray();
    }

    public static Type[] GetPropertyParameterTypes<TInterface>(this TInterface obj, string propertyName)
    {
        var property = typeof(TInterface).GetProperty(propertyName);
        return property?.GetIndexParameters().Select(p => p.ParameterType).ToArray();
    }

    public static void AddEventListener<TInterface>(this TInterface obj, string eventName, Delegate listener)
    {
        var eventInfo = typeof(TInterface).GetEvent(eventName);
        eventInfo?.AddEventHandler(obj, listener);
    }

    public static void RemoveEventListener<TInterface>(this TInterface obj, string eventName, Delegate listener)
    {
        var eventInfo = typeof(TInterface).GetEvent(eventName);
        eventInfo?.RemoveEventHandler(obj, listener);
    }

    public static void InvokeEvent<TInterface>(this TInterface obj, string eventName, params object[] args)
    {
        var eventInfo = typeof(TInterface).GetEvent(eventName);
        var eventDelegate = (MulticastDelegate)eventInfo?.GetRaiseMethod()?.Invoke(obj, null);
        if (eventDelegate != null)
        {
            foreach (var handler in eventDelegate.GetInvocationList())
            {
                handler.Method.Invoke(handler.Target, args);
            }
        }
    }

    public static void AddEventHandler<TInterface>(this TInterface obj, string eventName, Delegate handler)
    {
        var eventInfo = typeof(TInterface).GetEvent(eventName);
        eventInfo?.AddEventHandler(obj, handler);
    }

    public static void RemoveEventHandler<TInterface>(this TInterface obj, string eventName, Delegate handler)
    {
        var eventInfo = typeof(TInterface).GetEvent(eventName);
        eventInfo?.RemoveEventHandler(obj, handler);
    }

    public static void AddListener<TInterface>(this TInterface obj, string eventName, Delegate listener)
    {
        var eventInfo = typeof(TInterface).GetEvent(eventName);
        eventInfo?.AddEventHandler(obj, listener);
    }

    public static void RemoveListener<TInterface>(this TInterface obj, string eventName, Delegate listener)
    {
        var eventInfo = typeof(TInterface).GetEvent(eventName);
        eventInfo?.RemoveEventHandler(obj, listener);
    }

    public static bool ContainsMethod<TInterface>(this TInterface obj, string methodName)
    {
        return typeof(TInterface).GetMethod(methodName) != null;
    }

    public static object CreateInstance<TInterface>(this TInterface obj)
    {
        return Activator.CreateInstance(obj.GetType());
    }

    public static Type GetMethodReturnType<TInterface>(this TInterface obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        return method?.ReturnType;
    }

    public static bool IsMethodVirtual<TInterface>(this TInterface obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        return method?.IsVirtual ?? false;
    }

    public static bool IsMethodStatic<TInterface>(this TInterface obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        return method?.IsStatic ?? false;
    }

    public static bool IsMethodAbstract<TInterface>(this TInterface obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        return method?.IsAbstract ?? false;
    }

    public static bool IsMethodFinal<TInterface>(this TInterface obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        return method?.IsFinal ?? false;
    }

    public static bool IsMethodOverride<TInterface>(this TInterface obj, string methodName)
    {
        var method = typeof(TInterface).GetMethod(methodName);
        return method?.IsVirtual ?? false && method?.GetBaseDefinition().DeclaringType != method.DeclaringType;
    }

    public static MethodInfo[] GetMethodsWithoutParameters<TInterface>(this TInterface obj)
    {
        return typeof(TInterface).GetMethods().Where(m => m.GetParameters().Length == 0).ToArray();
    }

    public static MethodInfo[] GetMethodsWithParameters<TInterface>(this TInterface obj)
    {
        return typeof(TInterface).GetMethods().Where(m => m.GetParameters().Length > 0).ToArray();
    }





}
