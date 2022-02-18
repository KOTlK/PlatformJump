using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New/PlatformSpawnChances")]
public class PlatformSpawnChances : ScriptableObject
{
    [SerializeField] private List<TypeChances> Chances;

    public int GetChance(PlatformType type)
    {
        foreach (var chance in Chances)
        {
            if (chance.PlatformType == type)
            {
                return chance.Chance;
            }
        }
        return 0;
    }
}


[System.Serializable]
public class TypeChances
{
    public PlatformType PlatformType;
    public int Chance;
}
