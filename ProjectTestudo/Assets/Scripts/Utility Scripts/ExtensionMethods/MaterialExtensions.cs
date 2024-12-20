using System;
using UnityEngine;

public static class MaterialExtensions
{


    public static void SetColor(this Material material, string propertyName, Color color)
    {
        material.SetColor(propertyName, color);
    }
    public static void SetFloat(this Material material, string propertyName, float value)
    {
        material.SetFloat(propertyName, value);
    }
    public static void SetInt(this Material material, string propertyName, int value)
    {
        material.SetInt(propertyName, value);
    }
    public static void SetMatrix(this Material material, string propertyName, Matrix4x4 matrix)
    {
        material.SetMatrix(propertyName, matrix);
    }
    public static void SetTexture(this Material material, string propertyName, Texture texture)
    {
        material.SetTexture(propertyName, texture);
    }
    public static void SetVector(this Material material, string propertyName, Vector4 vector)
    {
        material.SetVector(propertyName, vector);
    }
    public static void SetColorArray(this Material material, string propertyName, Color[] colors)
    {
        material.SetColorArray(propertyName, colors);
    }
    public static void SetFloatArray(this Material material, string propertyName, float[] values)
    {
        material.SetFloatArray(propertyName, values);
    }
    public static void SetMatrixArray(this Material material, string propertyName, Matrix4x4[] matrices)
    {
        material.SetMatrixArray(propertyName, matrices);
    }
    public static void SetTextureArray(this Material material, string propertyName, Texture[] textures)
    {
        material.SetTextureArray(propertyName, textures);
    }
    public static void SetVectorArray(this Material material, string propertyName, Vector4[] vectors)
    {
        material.SetVectorArray(propertyName, vectors);
    }
    public static void SetBuffer(this Material material, string propertyName, ComputeBuffer buffer)
    {
        material.SetBuffer(propertyName, buffer);
    }
    public static void SetColor(this Material material, int propertyID, Color color)
    {
        material.SetColor(propertyID, color);
    }
    public static void SetFloat(this Material material, int propertyID, float value)
    {
        material.SetFloat(propertyID, value);
    }
    public static void SetInt(this Material material, int propertyID, int value)
    {
        material.SetInt(propertyID, value);
    }
    public static void SetMatrix(this Material material, int propertyID, Matrix4x4 matrix)
    {
        material.SetMatrix(propertyID, matrix);
    }

    public static void SetMainColor(this Material material, Color color)
    {
        material.SetColor("_Color", color);
    }

    public static void SetMainTexture(this Material material, Texture texture)
    {
        material.SetTexture("_MainTex", texture);
    }

    public static void SetMainTextureOffset(this Material material, Vector2 offset)
    {
        material.SetTextureOffset("_MainTex", offset);
    }


    public static void SetMainTextureScale(this Material material, Vector2 scale)
    {
        material.SetTextureScale("_MainTex", scale);
    }

    public static void SetMainTextureTiling(this Material material, Vector2 tiling)
    {
        material.SetTextureScale("_MainTex", tiling);
    }

    public static void SetMetallic(this Material material, float metallic)
    {
        material.SetFloat("_Metallic", Mathf.Clamp01(metallic));
    }

    public static void SetEmissionColor(this Material material, Color color)
    {
        material.SetColor("_EmissionColor", color);
    }

    public static void SetTransparency(this Material material, float transparency)
    {
        material.SetFloat("_Mode", transparency);
    }

    public static void SetShader(this Material material, Shader shader)
    {
        material.shader = shader;
    }

    public static void SetShader(this Material material, string shaderName)
    {
        material.shader = Shader.Find(shaderName);
    }

    public static void SetShader(this Material material, string shaderName, string fallbackShaderName)
    {
        Shader shader = Shader.Find(shaderName);
        if (shader == null)
        {
            shader = Shader.Find(fallbackShaderName);
        }
        material.shader = shader;
    }


}
