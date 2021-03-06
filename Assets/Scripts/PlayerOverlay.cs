using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerOverlay : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Health & Rage Text")]
    public Text healthValue;
    public Text rageValue;

    [Header("Weapons")]
    public Text weaponAmmo;
    public RawImage weaponImage;
    public Texture pistolTexture;
    public Texture smgTexture;
    public Texture shotgunTexture;
    public Texture huntingTexture;
    public Texture assaultRifleTexture;

    [Header("Grenades")]
    public Text nadeCount;
    public RawImage grenadeImage;
    public Texture pipeTexture;
    public Texture molotovTexture;
    public Texture stunTexture;

    [Header("Panels")]
    public GameObject healthAndRagePanel;
    public GameObject nadesPanel;
    public GameObject weaponsPanel;
    public GameObject objectivePanel;
    public GameObject allyPanel;
    public GameObject timerPanel;

    private Text objectiveText;
    private Text allyAmmoCount;
    private Text timeText;

    private void Start() {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); 
        objectiveText = objectivePanel.transform.GetChild(0).GetComponent<Text>();
        allyAmmoCount = allyPanel.transform.GetChild(0).GetComponent<Text>();
        timeText = timerPanel.transform.GetChild(0).GetComponent<Text>();
    }

   private void Update() {
       healthValue.text = gameManager.GetHealth().ToString();
       rageValue.text = gameManager.GetRageMeter().ToString();

       switch (gameManager.GetEquippedNade()) {
           case 0:
            grenadeImage.texture = pipeTexture;
            nadeCount.text = gameManager.GetPipeCount().ToString();
            break;
           case 1:
            grenadeImage.texture = molotovTexture;
            nadeCount.text = gameManager.GetMolotovCount().ToString();
            break;
           default:
            grenadeImage.texture = stunTexture;
            nadeCount.text = gameManager.GetStunCount().ToString();
            break;
       }

       switch (gameManager.GetEquippedWeapon()) {
           case 0:
            weaponImage.texture = pistolTexture;
            weaponAmmo.text = gameManager.GetPistolAmmo().ToString() + "/∞";
            break;
           case 1:
            weaponImage.texture = smgTexture;
            weaponAmmo.text = gameManager.GetSMGAmmo().ToString() + "/" + gameManager.GetSMGReserve().ToString();
            break;
           case 2:
            weaponImage.texture = shotgunTexture;
            weaponAmmo.text = gameManager.GetShotgunAmmo().ToString() + "/" + gameManager.GetShotgunReserve().ToString();
            break;
           case 3:
            weaponImage.texture = huntingTexture;
            weaponAmmo.text = gameManager.GetHuntingAmmo().ToString() + "/" + gameManager.GetHuntingReserve().ToString();
            break;
           default:
            weaponImage.texture = assaultRifleTexture;
            weaponAmmo.text = gameManager.GetAssaultRifleAmmo().ToString() + "/" + gameManager.GetAssaultRifleReserve().ToString();
            break;
       }

       objectiveText.text = "Current Objective: " + levelManager.ObjectiveText();



       if (AllyManager.Instance.checkCompanion()) {
           allyAmmoCount.text = "Ally Ammo: " + EllieBehavior.RoundCount();
       } else {
           allyAmmoCount.text = "Ally Ammo: " + louisBehaviour.RoundCount();
       }

       if(GameObject.FindWithTag("LevelManager").GetComponent<levelManager>().getLevel() == 3)
       {
            timerPanel.SetActive(true);
            timeText.text = ((int) GameObject.FindWithTag("timer").GetComponent<countdown>().getTimeRemaning()).ToString();
       }
   } 

}
