using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public INotifyValueChanged<PlayerController> notifyValueChanged;
    Canvas[] canvases;

    public Canvas currentCanvas;
    public Canvas pauseCanvas;
    public Canvas otherCanvas;

    public bool isPaused = false;


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
                        pauseCanvas = canvases[i];
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

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed) // Ensure it only triggers once per press
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            currentCanvas.DisableCanvas();
            currentCanvas = pauseCanvas;
            currentCanvas.EnableCanvas();
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            currentCanvas.DisableCanvas();
            currentCanvas = otherCanvas;
            currentCanvas.EnableCanvas();
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 1;
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
