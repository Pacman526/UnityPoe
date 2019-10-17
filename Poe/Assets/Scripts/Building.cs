using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{

    [SerializeField] protected int HP;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] mat;

    public int Hp { get => HP; set => HP = value; }
    public int MaxHP { get => maxHP; }
    public int Team { get => team; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
