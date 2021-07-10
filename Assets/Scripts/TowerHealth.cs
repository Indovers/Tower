using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : TowerBase
{
    public override int Interact(Player player)
    {
        return StageValue;
    }

    public TowerHealth(string _type, int _stageValue) : base(_type, _stageValue)
    {
    }
}
