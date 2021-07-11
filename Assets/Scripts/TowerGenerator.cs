using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject stagePrefab;
    [SerializeField] private Sprite[] contentSprites;
    [SerializeField] private Transform towersHolder;

    private Drag drag;
    private Level level;

    private void Awake()
    {
        drag = FindObjectOfType<Drag>();
        level = FindObjectOfType<Level>();
    }

    public void GenerateTowers(List<Tower> towers)
    {
        for(int i = 0; i < towers.Count; i++)
        {
            var towerObject = Instantiate(towerPrefab, towersHolder);
            for(int j = 0; j < towers[i].stages.Count; j++)
            {
                var stage = Instantiate(stagePrefab, towerObject.transform).GetComponent<TowerStage>();
                stage.Initialize(towers[i].stages[j].StageValue, towers[i].stages[j].Type, GetContentSprite(towers[i].stages[j].Type));
                level.towers[i].stages[j].StageTransform = stage.transform;
                
                if (towers[i].stages[j].Type == "player")
                {
                    var player = Instantiate(playerPrefab, level.towers[i].stages[j].StageTransform);
                    player.GetComponent<Player>().Initialize(towers[i].stages[j].StageValue);
                    drag.player = player.GetComponent<Player>();
                }
            }
        }
    }

    private Sprite GetContentSprite(string type)
    {
        switch (type)
        {
            case "enemy":
                return contentSprites[0];
            case "health":
                return contentSprites[1];
            default:
                return null;
        }
    }

    public void ShiftTowers()
    {
        Destroy(towersHolder.GetChild(1).gameObject);
    }

    public void TeleportStage(Transform _transform)
    {
        _transform.SetParent(towersHolder.GetChild(0));
    }
}
