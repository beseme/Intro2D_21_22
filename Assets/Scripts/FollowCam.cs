using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FollowCam : MonoBehaviour
{
   public float SmoothTime = .1f;

   private void FixedUpdate()
   {
      Vector3 velocity = Vector3.zero;

      transform.position = Vector3.SmoothDamp(transform.position,
         GameManager.Instance.Player.transform.position + Vector3.back * 10, ref velocity, SmoothTime);
   }
}
