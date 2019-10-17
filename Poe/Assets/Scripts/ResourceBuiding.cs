using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuiding : Building
{

    public string resourceType = "Wood";
    public int resourcesGenerated = 0;
    public int generatedPerRound = 2;
    public int remainingResources = 100;

    // Start is called before the first frame update
    void Start()
    {
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
