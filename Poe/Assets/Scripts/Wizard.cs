using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        typeOfUnit = "WizardUnit";
        Hp = 12;
        maxHP = hp;
        attack = 2;
        range = 1;
        speed = 0.8f;
        team = 3;
        GetComponent<MeshRenderer>().material = mat[0];
        gameObject.tag = "Team3";

        healthBar = GetComponentsInChildren<Image>()[1];
    }

}
