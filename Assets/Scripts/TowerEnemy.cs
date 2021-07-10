using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : TowerBase
{
    public override int Interact(Player player)
    {
        if (player.Health >= StageValue)
        {
            return StageValue;
        }
        
        return -1;
    }

    public TowerEnemy(string _type, int _stageValue) : base(_type, _stageValue)
    {
    }
}
