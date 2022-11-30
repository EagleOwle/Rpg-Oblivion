using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon, IItem
{
    public string GetName()
    {
        return name;
    }
}
