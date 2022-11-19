using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZoneType
{
    CREATION, REST, FIRE, ANIMALS, ZAWN
}
public abstract class BaseZone : MonoBehaviour
{
    // Serialized Fields
    public int MaxWitches;
    
    // NonSerialized fields
    [System.NonSerialized] public BoxCollider2D Collider;
    protected List<Witch> Witches;
    public ZoneType Type;
    
    public void Init(ZoneType type)
    {
        Collider = GetComponent<BoxCollider2D>();
        Type = type;

        Witches = new List<Witch>();
    }

    public bool AddWitch(Witch witch)
    {
        bool CanAddWitch = Witches.Count < MaxWitches;
        
        if(CanAddWitch) Witches.Add(witch);
        return CanAddWitch; // true if added
    }

    public void RemoveWitch(Witch witch)
    {
        Witches.Remove(witch);
    }
}
