using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilding : Building
{

    public int unitType;
    public int productionSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        typeOfUnit = "FactoryBuilding";
        Hp = 50;
        maxHP = Hp;
        team = Random.Range(1, 3);
        GetComponent<MeshRenderer>().material = mat[team - 1];
        switch (team)
        {
            case 1:
                gameObject.tag = "Team1";
                break;
            case 2:
                gameObject.tag = "Team2";
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
