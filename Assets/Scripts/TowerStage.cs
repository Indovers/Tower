using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerStage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private TextMeshProUGUI typeText;
    [SerializeField] private Image content;

    private Drag drag;

    private void Awake()
    {
        drag = FindObjectOfType<Drag>();
    }

    public void Initialize(int value, string type, Sprite _content)
    {
        if (type == "player" || type == "empty")
        {
            content.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            typeText.text = "";
            valueText.text = "";
            return;
        }
        valueText.text = value.ToString();

        print(_content);
        content.sprite = _content;
        content.GetComponent<RectTransform>().sizeDelta = _content == null ?  Vector2.zero : new Vector2(100, 100);
        typeText.text = _content == null ? type : "";
    }

    public void Empty()
    {
        valueText.text = "";
        typeText.text = "";  
        content.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
    }

    public void StageSelected()
    {
        drag.StageInteraction(transform.GetSiblingIndex()-1, transform.parent.GetSiblingIndex());
    }
}
