using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlayer : TowerBase
{
    public override int Interact(Player player)
    {
        return 0;
    }

    public TowerPlayer(string _type, int _stageValue) : base(_type, _stageValue)
    {
    }
}
