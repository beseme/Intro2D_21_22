using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
   private Image _bar = null;

   private void Awake()
   {
      _bar = GetComponent<Image>();
   }

   public void MapHealth(float max, float current)
   {
      _bar.fillAmount = current / max;
   }
}
