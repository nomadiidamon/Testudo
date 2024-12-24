using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public INotifyValueChanged<PlayerController> notifyValueChanged;
    Canvas[] canvases;

    public Canvas currentCanvas;
    public Canvas generalUICanvas;

    // Ability Menu
    // Map Menu
    // Stat Menu
    // Inventory Menu
    // Equipment Menu


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        canvases = GetComponents<Canvas>();
        if (canvases.Length > 0)
        {
            for (int i = 0; i < canvases.Length; i++)
            {
                switch (canvases[i].name)
                {
                    case "General_UI_Canvas":
                        generalUICanvas = canvases[i];
                        break;

                    case "AbilityMenu":
                        break;

                    case "MapMenu":
                        break;


                    case null:
                        break;
                }
            }
        }
    }

    void Update()
    {
        
    }



    public void Pause()
    {

    }

    public void Resume()
    {

    }

    public void Restart()
    {

    }

    public void Quit()
    {

    }



    public void Load()
    {

    }

    public void Save() 
    { 
    
    }


    public void Menu()
    {

    }

    public void Inventory()
    {

    }

    public void WeaponSelect()
    {

    }

    public void ArmorSelect()
    {

    }

    public void Settings()
    {

    }

    public void Stats()
    {

    }

    public void Records()
    {

    }



    public void ScreenEffect()
    {

    }

}
