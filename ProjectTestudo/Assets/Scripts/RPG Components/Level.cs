using System;

public class Level
{   
    private int levelValue {  get;  set; }
    private int currentExperience { get; set; }
    private int experienceToNextLevel { get;  set; }
    private float experienceMultiplier { get;  set; }

    public Level(int _level = 1, int _currentExperience = 0, int _experienceToNextLevel = 100, float _experienceMultiplier = 1.385f)
    {
        levelValue = _level;
        currentExperience = _currentExperience;
        experienceToNextLevel = _experienceToNextLevel;
        experienceMultiplier = _experienceMultiplier;
    }

    public void AddExperience(int experience)
    {
        currentExperience += experience;
        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    public virtual void LevelUp()
    {
        levelValue++;
        currentExperience -= experienceToNextLevel;
        experienceToNextLevel = (int)(experienceToNextLevel * experienceMultiplier);
    }

    public int GetLevel()
    {
        return levelValue;
    }

    public int GetCurrentExperience()
    {
        return currentExperience;
    }

    public int GetExperienceToNextLevel()
    {
        return experienceToNextLevel;
    }


    public float GetExperienceMultiplier()
    {
        return experienceMultiplier;
    }

    public void SetLevel(int _level)
    {
        levelValue = _level;
    }

    public void SetCurrentExperience(int _currentExperience)
    {
        currentExperience = _currentExperience;
    }

    public void SetExperienceToNextLevel(int _experienceToNextLevel)
    {
        experienceToNextLevel = _experienceToNextLevel;
    }


    public void SetExperienceMultiplier(float _experienceMultiplier)
    {
        experienceMultiplier = _experienceMultiplier;
    }

    public override string ToString()
    {
        return $"Level: {levelValue}, Current XP: {currentExperience}, XP to Next Level: {experienceToNextLevel}, Multiplier: {experienceMultiplier}";
    }


}
