using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerStage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private TextMeshProUGUI typeText;

    private Drag drag;

    private void Awake()
    {
        drag = FindObjectOfType<Drag>();
    }

    public void Initialize(int value, string type)
    {
        if(type == "player" || type == "empty")
            return;
        valueText.text = value.ToString();
        typeText.text = type;    
    }

    public void Empty()
    {
        valueText.text = "";
        typeText.text = "";   
    }

    public void StageSelected()
    {
        drag.StageInteraction(transform.GetSiblingIndex(), transform.parent.GetSiblingIndex());
    }
}
