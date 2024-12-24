using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;


    // all player stats to set reference values to

    // player health value
    private float playerCurrentHealth { get; set; }
    private float playerMaxHealth { get; set; }
    private float playerMinHealth { get; set; }

    // player stamina value
    private float playerCurrentStamina { get; set; }
    private float playerMaxStamina { get; set; }
    private float playerMinStamina { get; set; }

    // player mana value
    private float playerCurrentMana { get; set; }
    private float playerMaxMana { get; set; }
    private float playerMinMana { get; set; }

    // player experience value
    private float playerCurrentExperience { get; set; }
    private float playerMaxExperience { get; set; }
    private float playerMinExperience { get; set; }

    // player level value
    private int playerLevel { get; set; }




    // player stamina bar

    // player health bar

    // player mana bar

    // player souls
    public long playerSoulsValue;


    // player experience bar
    public float playerMaxSouls;
    public float playerMinSouls;

    // player level display
    public int playerCurrentLevel;






    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
