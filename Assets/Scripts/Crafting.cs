using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    private int Alcohol;
    private int Rags;
    private int Sugar;
    private int GunPowder;
    private int Canister;
    private int Bile;
    private int MolotovCocktail;
    private int StunGrenade;
    private int HealthPack;
    private int PipeBomb;
    private int BileBomb;

////////////////////////////////////////Setters & Getters///////////////////////////////////////////////////////

    public int getAlcohol()
    {
        return this.Alcohol;
    }

    public void setAlcohol(int Alcohol)
    {
        this.Alcohol = Alcohol;
    }

    public int getRags()
    {
        return this.Rags;
    }

    public void setRags(int Rags)
    {
        this.Rags = Rags;
    }

    public int getSugar()
    {
        return this.Sugar;
    }

    public void setSugar(int Sugar)
    {
        this.Sugar = Sugar;
    }

    public int getGunPowder()
    {
        return this.GunPowder;
    }

    public void setGunPowder(int GunPowder)
    {
        this.GunPowder = GunPowder;
    }

    public int getCanister()
    {
        return this.Canister;
    }

    public void setCanister(int Canister)
    {
        this.Canister = Canister;
    }

    public int getBile()
    {
        return this.Bile;
    }

    public void setBile(int Bile)
    {
        this.Bile = Bile;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
////////////////////////////////////////Crafting Methods///////////////////////////////////////////////////////
    private void makeMolotovCocktail(){
        if(getAlcohol()>=2 && getRags()>=2){
            setAlcohol(getAlcohol()-2);
            setRags(getRags()-2);
            MolotovCocktail+=1;
        }
    }
    private void makeStunGrenade(){
        if(getSugar()>=1 && getGunPowder()>=2){
            setSugar(getSugar()-1);
            setGunPowder(getGunPowder()-2);
            StunGrenade+=1;
        }
    }
    private void makeHealthPack(){
        if(getAlcohol()>=2 && getRags()>=2){
            setAlcohol(getAlcohol()-2);
            setRags(getRags()-2);
            HealthPack+=1;
        }

    }

    private void makePipeBomb(){
    if(getAlcohol()>=1 && getGunPowder() >=1 &&getCanister()>=1 ){
        setAlcohol(getAlcohol()-1);
        setGunPowder(getGunPowder()-1);
        setCanister(getCanister()-1);
        PipeBomb+=1;
    }
}


    private void makeBileBomb(){
    if(getBile()>=1 && getGunPowder() >=1 &&getCanister()>=1 ){
        setBile(getBile()-1);
        setGunPowder(getGunPowder()-1);
        setCanister(getCanister()-1);
        BileBomb+=1;
    }
}

}
