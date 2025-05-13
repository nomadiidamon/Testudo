using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorLerpByRange : MonoBehaviour
{
    [Header("Color Settings")]
    public List<Color> colorList = new List<Color>(); //{ Color.red, Color.yellow, Color.green, Color.cyan, Color.blue };

    [Header("Range Settings")]
    public int minValue = 0;
    public int maxValue = 100;
    [Range(0, 100)] public int currentValue = 0;

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        UpdateColor();
    }

    void Update()
    {
        UpdateColor();
    }

    void UpdateColor()
    {
        if (colorList.Count < 2 || maxValue <= minValue)
            return;

        float normalized = Mathf.InverseLerp(minValue, maxValue, currentValue);
        int colorIndex = Mathf.FloorToInt(normalized * (colorList.Count - 1));
        int nextColorIndex = Mathf.Clamp(colorIndex + 1, 0, colorList.Count - 1);

        float t = (normalized * (colorList.Count - 1)) - colorIndex;
        Color lerpedColor = Color.Lerp(colorList[colorIndex], colorList[nextColorIndex], t);

        meshRenderer.material.color = lerpedColor;
    }
}