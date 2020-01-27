using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FoodSpawner : MonoBehaviour
{
    public static FoodSpawner instance;
    public foodObject colorScore;
    public List<int> possibleColors;
    
    public GameObject red_Food;
    public GameObject blue_Food;
    public GameObject yellow_Food;
    public GameObject green_Food;

    void Awake(){
        getData();
        MakeInstance();
    }

    void MakeInstance(){
        if (instance == null){
            instance = this;
        }
    }

    void getData(){
        string configPath = Application.dataPath + "/Scripts/helper scripts/foodData.json";
        if (File.Exists(configPath))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/Scripts/helper scripts/foodData.json");
            print(saveString);
            colorScore = JsonUtility.FromJson<foodObject>(saveString);
        }
        if (colorScore.red != 0)
        {
            possibleColors.Add(0);
        }
        if (colorScore.blue != 0)
        {
            possibleColors.Add(1);
        }
        if (colorScore.green != 0)
        {
            possibleColors.Add(2);
        }
        if (colorScore.yellow != 0)
        {
            possibleColors.Add(3);
        }
        print(possibleColors);
    }

    public foodReturn getSpawn(){
        System.Random rnd = new System.Random();
        int listCount = possibleColors.Count;
        int rndNum = possibleColors[rnd.Next(0, listCount)];
        foodReturn retFood = new foodReturn();
        if(rndNum == 0){
            retFood.foodColor = red_Food;
            retFood.foodScore = colorScore.red;
            return retFood;
        }
        else if (rndNum == 1){
            retFood.foodColor = blue_Food;
            retFood.foodScore = colorScore.blue;
            return retFood;
        }
        else if (rndNum == 2){
            retFood.foodColor = green_Food;
            retFood.foodScore = colorScore.green;
            return retFood;
        }
        else{
            retFood.foodColor = yellow_Food;
            retFood.foodScore = colorScore.yellow;
            return retFood;
        }
    }

}
