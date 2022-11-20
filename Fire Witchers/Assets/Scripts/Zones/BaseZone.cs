using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ZoneType
{
    TRAINING, REST, FIRE, ANIMALS, ZAWN
}
public abstract class BaseZone : MonoBehaviour
{
    // Serialized Fields
    public int MaxWitches;
    public TextMeshProUGUI WitchNumber;
    
    // NonSerialized fields
    [System.NonSerialized] public BoxCollider2D Collider;
    [System.NonSerialized] public ZoneType Type;
    protected List<Witch> Witches;
    protected Coroutine ZoneCoroutine;
    
    public void Init(ZoneType type)
    {
        Collider = GetComponent<BoxCollider2D>();
        Type = type;

        Witches = new List<Witch>();
    }

    private void Start()
    {
        WitchNumber.text = Witches.Count + " / " + MaxWitches;
    }

    public bool AddWitch(Witch witch)
    {
        bool CanAddWitch = Witches.Count < MaxWitches;

        if (CanAddWitch)
        {
            if(witch.CurrentZone != null)
                witch.CurrentZone.RemoveWitch(witch);
            Witches.Add(witch);
            WitchNumber.text = Witches.Count + " / " + MaxWitches;
        }
        if (Witches.Count > 0) ZoneCoroutine = StartCoroutine(ZoneAction());
        return CanAddWitch; // true if added
    }

    public void RemoveWitch(Witch witch)
    {
        Witches.Remove(witch);
        WitchNumber.text = Witches.Count + " / " + MaxWitches;
        if (Witches.Count == 0) StopCoroutine(ZoneCoroutine);
    }

    protected abstract IEnumerator ZoneAction();
}
