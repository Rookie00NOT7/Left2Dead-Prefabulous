using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public bool ellieSelected = true;

    private PlayerAddedBehavior player;
    private huntingRifleBehavior huntingRifle;
    private SMGbehavior submachinegun;
    private ShotgunBehaviour shotgun;
    private PistolBehavior pistol;
    private grenades grenades;
    private weaponManager weaponManager;

    //   private void Awake() {
    //      if (Instance == null) {
    //          Instance = this;
    //          DontDestroyOnLoad(this.gameObject);
    //      } else {
    //          Destroy(this);
    //      }
    //   }

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerAddedBehavior>();
        grenades = GameObject.FindWithTag("Player").GetComponent<grenades>();
        huntingRifle = GameObject.FindWithTag("playerHuntingRifle").GetComponent<huntingRifleBehavior>();
        submachinegun = GameObject.FindWithTag("playerSGM").GetComponent<SMGbehavior>();
        shotgun = GameObject.FindWithTag("Shotty").GetComponent<ShotgunBehaviour>();
        pistol = GameObject.FindWithTag("playerGun").GetComponent<PistolBehavior>();
        weaponManager = GameObject.FindWithTag("WeaponManager").GetComponent<weaponManager>();
    }

    public int GetHealth()
    {
        return player.getHealth();
    }

    public int GetRageMeter()
    {
        return player.getRageMeter();
    }

    public int GetPipeCount()
    {
        return grenades.getPipeInv();
    }

    public int GetMolotovCount()
    {
        return grenades.getMolInv();
    }

    public int GetStunCount()
    {
        return grenades.getStunInv();
    }

    public int GetHuntingAmmo()
    {
        return huntingRifle.getClipCap();
    }

    public int GetHuntingReserve()
    {
        return huntingRifle.getTotalBullets();
    }

    public int GetSMGAmmo()
    {
        return submachinegun.getClipCap();
    }

    public int GetSMGReserve()
    {
        return submachinegun.getAmmo();
    }

    public int GetShotgunAmmo()
    {
        return shotgun.GetCurrentShellCount();
    }

    public int GetShotgunReserve()
    {
        return shotgun.GetCurrentReserveAmmo();
    }

    public int GetPistolAmmo()
    {
        return pistol.getClipCap();
    }

    public int GetEquippedWeapon()
    {
        return weaponManager.GetEquippedWeapon();
    }

    public int GetEquippedNade()
    {
        return grenades.GetEquippedNade();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            PlayerStatsLog();
        }
    }

    private void PlayerStatsLog()
    {
        Debug.Log("---------- Player Stats ----------");
        Debug.Log("Player Health: " + GetHealth());
        Debug.Log("Player Rage Meter: " + GetRageMeter());
        Debug.Log("Pipe Bomb Count: " + GetPipeCount());
        Debug.Log("Molotov Count: " + GetMolotovCount());
        Debug.Log("Stun Grenade Count: " + GetStunCount());
        Debug.Log("Shotgun Current Ammo Count: " + GetShotgunAmmo());
        Debug.Log("Shotgun Reserve Ammo Count: " + GetShotgunReserve());
        Debug.Log("SMG Current Ammo Count: " + GetSMGAmmo());
        Debug.Log("SMG Reserve Ammo Count: " + GetSMGReserve());
        Debug.Log("Shotgun Current Ammo Count: " + GetShotgunAmmo());
        Debug.Log("Shotgun Reserve Ammo Count: " + GetShotgunReserve());
        Debug.Log("Pistol Current Ammo Count: " + GetPistolAmmo());
        Debug.Log("----------------------------------");
    }

}
