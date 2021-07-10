using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase
{
    public abstract int Interact(Player player);

    private int stageValue;
    private string type;
    private Transform stageTransform;

    public int StageValue
    {
        get => stageValue;
        set => stageValue = value;
    }

    public string Type
    {
        get => type;
        set => type = value;
    }

    public Transform StageTransform
    {
        get => stageTransform;
        set => stageTransform = value;
    }

    public TowerBase(string _type, int _stageValue)
    {
        Type = _type;
        StageValue = _stageValue;
    }
}
