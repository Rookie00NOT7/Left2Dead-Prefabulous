using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   [HideInInspector]
   public bool ellieSelected = true;

   private void Awake() {
      if (Instance == null) {
          Instance = this;
          DontDestroyOnLoad(this.gameObject);
      } else {
          Destroy(this);
      }
   }
}
