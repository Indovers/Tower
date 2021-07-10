using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    private Drag drag;
    
    private int health;
    public int Health
    {
        get => health;
        set
        { 
            health = value;
            healthText.text = health.ToString();
        }
    }

    private int currentStage;

    public int CurrentStage
    {
        get => currentStage;
        set => currentStage = value;
    }

    private void Awake()
    {
        drag = FindObjectOfType<Drag>();
    }

    public void Initialize(int hp)
    {
        Health = hp;
        CurrentStage = 0;
    }

    public void StartDrag()
    {
        drag.isPlayerDragged = true;
    }
}
