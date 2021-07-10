using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool isPlayerDragged;

    [SerializeField] private CanvasGroup loseGroup;
    
    private Level level;
    public Player player;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
    }

    public void StageInteraction(int stageId, int towerId)
    {
        if(!isPlayerDragged) return;
        if (towerId > 1) return;
        if (player.CurrentStage + 1 < stageId && towerId > 0) return;

        var result = level.towers[towerId].stages[stageId].Interact(player);
        if (result < 0)
        {
            loseGroup.alpha = 1;
            loseGroup.blocksRaycasts = true;
        }
        else
        {
            player.Health += result;

            if (towerId == 0)
            {
                player.CurrentStage = stageId;
                player.transform.SetParent(level.towers[0].stages[stageId].StageTransform);
                player.transform.localPosition = Vector3.zero;
                
                level.EmptyStage(stageId);
            }
            else
            {
                level.TeleportStage(stageId);
            }
        }
        
        isPlayerDragged = false;
    }
}
