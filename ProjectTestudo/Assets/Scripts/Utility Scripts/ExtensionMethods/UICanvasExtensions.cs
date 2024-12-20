using System;
using UnityEngine;
using UnityEngine.UI;



public static class UICanvasExtensions
{

    public static void SetCanvasGroupAlpha(this Canvas canvas, float alpha)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = alpha;
    }


    public static void SetCanvasGroupInteractable(this Canvas canvas, bool interactable)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.interactable = interactable;
    }

    public static void SetCanvasGroupBlocksRaycasts(this Canvas canvas, bool blocksRaycasts)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.blocksRaycasts = blocksRaycasts;
    }

    public static void EnableCanvas(this Canvas canvas)
    {
        canvas.gameObject.SetActive(true);
    }

    public static void DisableCanvas(this Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
    }

    public static void ToggleCanvas(this Canvas canvas)
    {
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
    }

    public static void SetCanvasSortingOrder(this Canvas canvas, int sortingOrder)
    {
        canvas.sortingOrder = sortingOrder;
    }

    public static void SetCanvasAlphaWithAnimation(this Canvas canvas, float targetAlpha, float duration)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }

        float startAlpha = canvasGroup.alpha;
        float timeElapsed = 0;

        canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / duration);
    }

    public static void SetCanvasInteractableWithAnimation(this Canvas canvas, bool targetInteractable, float duration)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }
        bool startInteractable = canvasGroup.interactable;
        float timeElapsed = 0;
        canvasGroup.interactable = startInteractable;
    }

    public static CanvasGroup GetCanvasGroup(this Canvas canvas)
    {
        return canvas.GetComponent<CanvasGroup>();
    }


    public static bool HasCanvasGroup(this Canvas canvas)
    {
        return canvas.GetComponent<CanvasGroup>() != null;
    }

    public static void SetCanvasLayer(this Canvas canvas, int layer)
    {
        canvas.gameObject.layer = layer;
    }

    public static void ShowLoadingScreen(this Canvas canvas)
    {
        GameObject loadingScreen = new GameObject("LoadingScreen");
        loadingScreen.transform.SetParent(canvas.transform);
        CanvasGroup canvasGroup = loadingScreen.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = true;
    }

    public static void HideLoadingScreen(this Canvas canvas)
    {
        Transform loadingScreen = canvas.transform.Find("LoadingScreen");
        if (loadingScreen != null)
        {
            CanvasGroup canvasGroup = loadingScreen.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0;
                canvasGroup.blocksRaycasts = false;
            }
        }
    }

    public static void SetBackgroundColorDynamically(this Canvas canvas, Color color)
    {
        if (canvas.worldCamera != null)
        {
            canvas.worldCamera.backgroundColor = color;
        }
    }

    public static void SetBackgroundColorDynamically(this Canvas canvas, Color color, float duration)
    {
        if (canvas.worldCamera != null)
        {
            Color startColor = canvas.worldCamera.backgroundColor;
            float timeElapsed = 0;
            canvas.worldCamera.backgroundColor = Color.Lerp(startColor, color, timeElapsed / duration);
        }
    }

    public static void SetBackgroundColorDynamically(this Canvas canvas, Color startColor, Color endColor, float duration)
    {
        if (canvas.worldCamera != null)
        {
            float timeElapsed = 0;
            canvas.worldCamera.backgroundColor = Color.Lerp(startColor, endColor, timeElapsed / duration);
        }
    }

    public static Text AddText(this Canvas canvas, string textContent, Font font, int fontSize, Color textColor)
    {
        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(canvas.transform);

        Text text = textObject.AddComponent<Text>();
        text.text = textContent;
        text.font = font;
        text.fontSize = fontSize;
        text.color = textColor;

        return text;
    }

    public static Image AddImage(this Canvas canvas, Sprite sprite, Color color)
    {
        GameObject imageObject = new GameObject("Image");
        imageObject.transform.SetParent(canvas.transform);
        Image image = imageObject.AddComponent<Image>();
        image.sprite = sprite;
        image.color = color;
        return image;
    }

    public static Button AddButton(this Canvas canvas, Sprite sprite, Color color, Action onClick)
    {
        GameObject buttonObject = new GameObject("Button");
        buttonObject.transform.SetParent(canvas.transform);
        Image image = buttonObject.AddComponent<Image>();
        image.sprite = sprite;
        image.color = color;
        Button button = buttonObject.AddComponent<Button>();
        button.onClick.AddListener(() => onClick());
        return button;
    }

    public static void FadeOut(this Canvas canvas, float duration)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0, duration * Time.deltaTime);
    }

    public static void FadeIn(this Canvas canvas, float duration)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, duration * Time.deltaTime);
    }

    public static void MakeTransparent(this Canvas canvas)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f;
    }

    public static void MakeOpaque(this Canvas canvas)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 1f;
    }

    public static void SetMaterialColor(this Canvas canvas, Color color)
    {
        Graphic graphic = canvas.GetComponentInChildren<Graphic>();
        if (graphic != null)
        {
            graphic.material.color = color;
        }
    }

    public static void SetMaterialColor(this Canvas canvas, string materialName, Color color)
    {
        Graphic graphic = canvas.GetComponentInChildren<Graphic>();
        if (graphic != null)
        {
            graphic.material.SetColor(materialName, color);
        }
    }

    public static void SetAlphaForChildren(this Canvas canvas, float alpha)
    {
        CanvasGroup[] canvasGroups = canvas.GetComponentsInChildren<CanvasGroup>();
        foreach (var group in canvasGroups)
        {
            group.alpha = alpha;
        }
    }

    public static void DisableElementsByTag(this Canvas canvas, string tag)
    {
        GameObject[] elements = GameObject.FindGameObjectsWithTag(tag);
        foreach (var element in elements)
        {
            element.SetActive(false);
        }
    }

    public static void EnableElementsByTag(this Canvas canvas, string tag)
    {
        GameObject[] elements = GameObject.FindGameObjectsWithTag(tag);
        foreach (var element in elements)
        {
            element.SetActive(true);
        }
    }

    public static void ToggleElementsByTag(this Canvas canvas, string tag)
    {
        GameObject[] elements = GameObject.FindGameObjectsWithTag(tag);
        foreach (var element in elements)
        {
            element.SetActive(!element.activeSelf);
        }
    }

}
