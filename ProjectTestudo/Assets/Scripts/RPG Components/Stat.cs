using System;
using UnityEngine;

public class Stat : Level, IStat
{
    public new string name;
    public string description;

    public int softCap;
    public float softCapRate;
    public int hardCap;
    public float hardCapRate;

    public Stat(string _name, int level)
        : base(level)
    {
        name = _name;
    }


    public void SetDescription(string _description)
    {
        description = _description;
    }

    public void SetSoftCap(int value, float rate)
    {
        softCap = value;
        softCapRate = rate;
    }

    public void SetHardCap(int value, float rate)
    {
        hardCap = value;
        hardCapRate = rate;
    }

    public void SetName(string _name)
    {
        name = _name;
    }

}
