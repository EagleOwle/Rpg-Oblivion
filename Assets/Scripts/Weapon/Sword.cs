using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon, IItem
{
    public string GetName()
    {
        return name;
    }
}
