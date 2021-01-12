using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    private int Alcohol ;
    private int Rags ;
    private int Sugar;
    private int GunPowder;
    private int Canister;
   // private int Bile;
    private int MolotovCocktail;
    private int StunGrenade;
    private int HealthPack;
    private int PipeBomb;
    private int BileBomb;
    public GameObject Crafting_Panel;
    public Text AlcoholText;
    public Text RagsText;
    public Text SugarText;
    public Text GunPowderText;
    public Text CanisterText;
    public Button Molotov_Button;
    public Button Stun_Grenade_Button;
    public Button Health_Pack_Button;
    public Button Pipe_Bomb_Button;

////////////////////////////////////////Setters & Getters///////////////////////////////////////////////////////

    public int getAlcohol()
    {
        return this.Alcohol;
    }

    public void setAlcohol(int Alcohol)
    {   if(Alcohol<=10)
        this.Alcohol = Alcohol;
    }

    public int getRags()
    {
        return this.Rags;
    }

    public void setRags(int Rags)
    {   if(Rags<=10)
        this.Rags = Rags;
    }

    public int getHealthPack()
    {
        return this.HealthPack;
    }

    public void setHealthPack(int healthPack)
    {
        if (GetComponent<PlayerAddedBehavior>().getHealth() == 300)
            this.HealthPack = healthPack;
        else
            GetComponent<PlayerAddedBehavior>().heal(50);
    }

    public int getSugar()
    {
        return this.Sugar;
    }

    public void setSugar(int Sugar)
    {   if(Sugar<=10)
        this.Sugar = Sugar;
    }

    public int getGunPowder()
    {
        return this.GunPowder;
    }

    public void setGunPowder(int GunPowder)
    {
        if(GunPowder<=10)
        this.GunPowder = GunPowder;
    }

    public int getCanister()
    {
        return this.Canister;
    }

    public void setCanister(int Canister)
    {   if(Canister<=10)
        this.Canister = Canister;
    }

    // public int getBile()
    // {
    //     return this.Bile;
    // }

    // public void setBile(int Bile)
    // {
    //     this.Bile = Bile;
    // }

    // Start is called before the first frame update
    void Start()
    {
        Crafting_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AlcoholText.text ="Alcohol: "+ getAlcohol() +"/10";
        RagsText.text ="Rags: "+ getRags() +"/10";
        SugarText.text ="Sugar: "+ getSugar() +"/10";
        GunPowderText.text ="GunPowder: "+ getGunPowder() +"/10";
        CanisterText.text ="Canisters: "+ getCanister() +"/10";
        checkmolotov();
        checkstungrenade();
        CheckHealthPack();
        CheckPipeBomb();



        if(Input.GetKeyDown(KeyCode.T)){
            if( Crafting_Panel.gameObject.activeInHierarchy)
             Disable();
             else
             EnablePanel();
         }
    //this.GetComponent<grenades>().getMolInv();
    



        
    }
////////////////////////////////////////Crafting Methods///////////////////////////////////////////////////////
    private void makeMolotovCocktail(){
       if( this.GetComponent<grenades>().getMolInv()<3){
        if(getAlcohol()>=2 && getRags()>=2){
            setAlcohol(getAlcohol()-2);
            setRags(getRags()-2);
            this.GetComponent<grenades>().addMol(this.GetComponent<grenades>().getMolInv()+1);
                                            }
        }
    }
    private void makeStunGrenade(){
        if(this.GetComponent<grenades>().getStunInv()<2){
        if(getSugar()>=1 && getGunPowder()>=2){
            setSugar(getSugar()-1);
            setGunPowder(getGunPowder()-2);
            this.GetComponent<grenades>().addStun(this.GetComponent<grenades>().getStunInv()+1);
        }}
    }
    private void makeHealthPack(){
        if(getAlcohol()>=2 && getRags()>=2){
            setAlcohol(getAlcohol()-2);
            setRags(getRags()-2);
            HealthPack+=1;
        }

    }

    private void makePipeBomb(){
        if(this.GetComponent<grenades>().getPipeInv()<3){
    if(getAlcohol()>=1 && getGunPowder() >=1 &&getCanister()>=1 ){
        setAlcohol(getAlcohol()-1);
        setGunPowder(getGunPowder()-1);
        setCanister(getCanister()-1);
        this.GetComponent<grenades>().addPipe(this.GetComponent<grenades>().getPipeInv()+1);
    }}
}


//     private void makeBileBomb(){
//     if(getBile()>=1 && getGunPowder() >=1 &&getCanister()>=1 ){
//         setBile(getBile()-1);
//         setGunPowder(getGunPowder()-1);
//         setCanister(getCanister()-1);
//         BileBomb+=1;
//     }
// }

///////////////////////////////////////////Panel Manager///////////////////////////////////////////////////

public void EnablePanel(){
        if (Crafting_Panel!=null){
                 Crafting_Panel.SetActive(true);
                 Time.timeScale =0;
                 
             }
             

    }
    public void Disable(){
        Crafting_Panel.SetActive(false);
        Time.timeScale=1;
    }

    //void OnTriggerEnter(Collider other){
        //if(other.gameObject.tag=="Alcohol" || other.gameObject.tag=="Rag" || other.gameObject.tag=="Sugar" 
        //|| other.gameObject.tag=="GunPowder" || other.gameObject.tag=="Canister" ){
        //if(other.gameObject.tag=="Alcohol"){
            //setAlcohol(getAlcohol()+1);
            //}
        //if(other.gameObject.tag=="Rag")
            //setRags(getRags()+1);
        //if(other.gameObject.tag=="Sugar")
            //setSugar(getSugar()+1);
        //if(other.gameObject.tag=="GunPowder")
            //setGunPowder(getGunPowder()+1);
        //if(other.gameObject.tag=="Canister")
            //setCanister(getCanister()+1);

        //Destroy(other.gameObject);
    
    //}  
    //}

    private void checkmolotov(){
        if(getAlcohol()>=2 && getRags()>=2 && this.GetComponent<grenades>().getMolInv()<3)
        Molotov_Button.interactable = true;
        else
        Molotov_Button.interactable = false;
    }

     private void checkstungrenade(){
        if(getSugar()>=1 && getGunPowder()>=2 && this.GetComponent<grenades>().getStunInv()<2)
        Stun_Grenade_Button.interactable = true;
        else
        Stun_Grenade_Button.interactable = false;
    }

    private void CheckHealthPack(){
        if(getAlcohol()>=2 && getRags()>=2)
        Health_Pack_Button.interactable = true;
        else
        Health_Pack_Button.interactable = false;
    }
    private void CheckPipeBomb(){
        if(getAlcohol()>=1 && getGunPowder()>=1 && getCanister()>=1 && this.GetComponent<grenades>().getPipeInv()<3)
        Pipe_Bomb_Button.interactable = true;
        else
        Pipe_Bomb_Button.interactable = false;
    }











}
