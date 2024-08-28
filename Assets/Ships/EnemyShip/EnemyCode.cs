using System;
using UnityEngine;

public enum EnemyCode 
{
    Fighter = 1,
    Bomber = 2,
    Assult = 3,
    Tanker = 4,
    Destructor = 5,
    NoCode = 6,
}

public class EnemyCodeParse
{
    public static EnemyCode FromString(string name)
    {
        try
        {
            return (EnemyCode)System.Enum.Parse(typeof(EnemyCode), name);

        }
        catch(ArgumentException e)
        {
            Debug.Log(e.ToString());
            return EnemyCode.NoCode;
        }
    }
}
