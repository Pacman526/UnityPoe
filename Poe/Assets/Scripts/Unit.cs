using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int range;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int attack;
    [SerializeField] protected float speed;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] mat;
    float timer = 0;
    public string typeOfUnit;

    public int Hp { get => hp; set => hp = value; }
    public int MaxHP { get => maxHP; }
    public int Attack { get => attack; }
    public float Speed { get => speed; }
    public int Range { get => range; }
    public int Team { get => team; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject Enemy = GetClosestUnit();
        
        if (Enemy.GetComponent<Building>())
        {
            if (!IsInRange(Enemy))
            {
                transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, speed * Time.deltaTime);
            }
            else if (Enemy.GetComponent<Building>().Hp < 0)
            {
                Destroy(Enemy);
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > 0.2f)
                {
                    Enemy.GetComponent<Building>().Hp -= attack;
                    timer = 0;
                }

            }
        }else

        if (!IsInRange(Enemy))
        {
            transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, speed * Time.deltaTime);
        }
        else if(Enemy.GetComponent<Unit>().hp < 0)
        {
            Destroy(Enemy);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >0.2f)
            {
                Enemy.GetComponent<Unit>().hp -= attack;
                timer = 0;
            }
            
        }
    }

    protected bool IsInRange(GameObject Enemy)
    {
        if (Vector3.Distance(transform.position, Enemy.transform.position) <= range)
            return true;
        else return false;

    }

    protected GameObject GetClosestUnit()
    {
        GameObject unit = null;
        GameObject[] units = null;
      

        switch (team)
        {
            case 1:
                units = GameObject.FindGameObjectsWithTag("Team2");
                break;
            case 2:
                units = GameObject.FindGameObjectsWithTag("Team1");

                break;
        }

        float distance = 9999;
        foreach (GameObject temp in units)
        {
            float tempDist = Vector3.Distance(transform.position, temp.transform.position);
            if (tempDist <= distance)
            {
                distance = tempDist;
                unit = temp;
            }
        }

        return unit;
    }
}

