using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyManager : MonoBehaviour
{
  public GameObject Ellie;
  public GameObject Louis;
  public static AllyManager Instance;
  
  private bool isEllie = true;
  private Vector3 allyPosition;
  private WaitForSeconds startLoad = new WaitForSeconds(0.05f);

  private void Awake() {
      if (Instance == null) {
          Instance = this;
          DontDestroyOnLoad(this.gameObject);
      } else {
          Destroy(this.gameObject);
          return;
      }
  }

  public bool checkCompanion() {
      return isEllie;
  }

  public void ChooseEllie() {
      isEllie = true;
  }

  public void ChooseLouis() {
      isEllie = false;
  }

  public bool GetIsEllie() {
      return isEllie;
  }

  public void SetIsEllie(bool state) {
      isEllie = state;
  }

  public void StartGame() {
      SceneManager.LoadScene("Scene_A");
      StartCoroutine(SpawnAlly());
  }
  public IEnumerator SpawnAlly() {
      yield return startLoad;

      allyPosition = GameObject.FindWithTag("AllyInitialPos").transform.position;

      if (isEllie) {
          Instantiate(Ellie, allyPosition, Quaternion.identity);
      } else {
          Instantiate(Louis, allyPosition, Quaternion.identity);
      }
  }
}
