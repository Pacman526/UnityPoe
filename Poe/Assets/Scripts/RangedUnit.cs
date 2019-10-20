using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        typeOfUnit = "RangedUnit";
        Hp = 8;
        maxHP = hp;
        attack = 1;
        range = 2;
        speed = 0.5f;
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

 
}
