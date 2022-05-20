using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdToName
{

    void Awake()
    {
    }

    public string GetName(int id)
    {
        string i = "None";
        if (id == 0) i = "poo";

        return i;
    }

}

