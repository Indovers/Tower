using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEmpty : TowerBase
{
    public override int Interact(Player player)
    {
        return 0;
    }

    public TowerEmpty(string _type, int _stageValue) : base(_type, _stageValue)
    {
        
    }
}
