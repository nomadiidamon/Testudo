using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
