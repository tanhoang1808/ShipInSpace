using System;
using UnityEngine;

public enum ShipCode 
{
    Destroyer = 1,
    Striker = 2,
    Thunder = 3,
    NoType = 4,

}

public class ShipCodeParse
{
    public static ShipCode FromString(string name)
    {
        try
        {
            return (ShipCode)System.Enum.Parse(typeof(ShipCode), name);

        }
        catch (ArgumentException e)
        {
            Debug.Log(e.ToString());
            return ShipCode.NoType;
        }
    }
}
