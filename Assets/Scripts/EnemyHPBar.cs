using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public Transform EnemyTransform = null;
    
    private Image _bar = null;

    private void Awake()
    {
        _bar = GetComponent<Image>();
    }

    public void MapHealth(float max, float current)
    {
        _bar.fillAmount = current / max;
    }

    private void Update()
    {
        _bar.rectTransform.position = Camera.main.WorldToScreenPoint(EnemyTransform.position) + Vector3.up * 100;
    }
}
