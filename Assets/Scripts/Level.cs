using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public List<Tower> towers = new List<Tower>();

    private string jsonString;
    private JsonData itemData;

    private TowerGenerator towerGenerator;

    private void Awake()
    {
        towerGenerator = GetComponent<TowerGenerator>();
    }

    private void Start()
    {
        ParseDataFromJSON();
        
        towerGenerator.GenerateTowers(towers);
    }

    private void ParseDataFromJSON()
    {
        /*string filePath = Application.streamingAssetsPath + "/levelData.json";
        string jsonString;
             
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }
     
            jsonString = reader.text;
        }
        else
        {
            jsonString = File.ReadAllText(filePath);
        }
        itemData = JsonMapper.ToObject(jsonString);
        
        
        for (int i = 0; i < itemData["Tower"][0].Count; i++)
        {
            var newTower = new Tower();
            for (int j = 0; j < itemData["Tower"][0][i].Count; j++)
            {
                switch (itemData["Tower"][0][i][j]["type"].ToString())
                {
                    case "enemy":
                        newTower.stages.Add(new TowerEnemy(itemData["Tower"][0][i][j]["type"].ToString(), (int) itemData["Tower"][0][i][j]["value"]));
                        break;
                    case "health":
                        newTower.stages.Add(new TowerHealth(itemData["Tower"][0][i][j]["type"].ToString(), (int) itemData["Tower"][0][i][j]["value"]));
                        break;
                    case "player":
                        newTower.stages.Add(new TowerPlayer(itemData["Tower"][0][i][j]["type"].ToString(), (int) itemData["Tower"][0][i][j]["value"]));
                        break;
                }
                //print(itemData["Tower"][0][i][j]["value"]);
            }
            towers.Add(newTower);
        }*/
        
        //TEST VALUES
        var newTower = new Tower();
        newTower.stages.Add(new TowerPlayer("player", 3));
        newTower.stages.Add(new TowerHealth("health", 2));
        towers.Add(newTower);
        newTower = new Tower();
        newTower.stages.Add(new TowerEnemy("enemy", 5));
        newTower.stages.Add(new TowerEnemy("enemy", 9));
        newTower.stages.Add(new TowerEnemy("enemy", 18));
        towers.Add(newTower);
        newTower = new Tower();
        newTower.stages.Add(new TowerEnemy("enemy", 23));
        newTower.stages.Add(new TowerEnemy("enemy", 40));
        newTower.stages.Add(new TowerEnemy("enemy", 84));
        towers.Add(newTower);
    }

    public void EmptyStage(int stageId)
    {
        var _transform = towers[0].stages[stageId].StageTransform;
        towers[0].stages[stageId] = new TowerEmpty("empty", 0);
        towers[0].stages[stageId].StageTransform = _transform;

        _transform.GetComponent<TowerStage>().Empty();
    }

    public void TeleportStage(int stageId)
    {
        var _transform = towers[1].stages[stageId].StageTransform;
        towers[1].stages.RemoveAt(stageId);
        towers[0].stages.Add(new TowerEmpty("empty", 0));
        towers[0].stages[towers[0].stages.Count-1].StageTransform = _transform;
        _transform.GetComponent<TowerStage>().Empty();
        
        towerGenerator.TeleportStage(_transform);
        
        ShiftTowers();
    }

    private void ShiftTowers()
    {
        if (towers[1].stages.Count == 0)
        {
            towers.RemoveAt(1);
            towerGenerator.ShiftTowers();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

public class Tower
{
    public List<TowerBase> stages = new List<TowerBase>();
}
