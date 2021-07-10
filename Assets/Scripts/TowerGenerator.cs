using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject stagePrefab;
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
                stage.Initialize(towers[i].stages[j].StageValue, towers[i].stages[j].Type);
                level.towers[i].stages[j].StageTransform = stage.transform;
                
                if (i == 0 && j == 0)
                {
                    var player = Instantiate(playerPrefab, towersHolder.GetChild(0).GetChild(0).transform);
                    player.GetComponent<Player>().Initialize(towers[i].stages[j].StageValue);
                    drag.player = player.GetComponent<Player>();
                }
            }
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
