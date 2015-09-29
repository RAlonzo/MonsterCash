using UnityEngine;
using System.Collections;
using System;

public class Racer : IComparable<Racer>
{
    public string name;
    public int displacement;

    public Racer(string newName, int newDisplacement)
    {
        name = newName;
        displacement = newDisplacement;
    }

    public void setDisplacement(int newDisplacement)
    {
        displacement = newDisplacement;
    }

    public int getDisplacement()
    {
        return displacement;
    }

    public int CompareTo(Racer other)
    {
        if (other == null)
        {
            return 1;
        }

        return displacement - other.displacement;
    }
}
