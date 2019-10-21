using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int range;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int attack;
    [SerializeField] protected float speed;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] mat;
    [SerializeField] protected string typeOfUnit;
    [SerializeField] GameObject Enemy;
    float timer = 0;
    

    protected Image healthBar;

    public int Hp { get => hp; set => hp = value; }
    public int MaxHP { get => maxHP; }
    public int Attack { get => attack; }
    public float Speed { get => speed; }
    public int Range { get => range; }
    public int Team { get => team; }
    public string TypeOfUnit { get => typeOfUnit; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] units = null;

        Enemy = GetClosestUnit();
        healthBar.fillAmount = (float)hp / maxHP;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        if (tag == "Team3")
        {
            if (!IsInRange(Enemy))
            {
                transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, speed * Time.deltaTime);
            }
            else if (Enemy.GetComponent<Unit>().hp < 0)
            {
                Destroy(Enemy);
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > 0.4f)
                {
                    units = GameObject.FindGameObjectsWithTag("Team1");
                    foreach (GameObject temp in units)
                    {
                        if (temp.GetComponent<Building>())
                        {

                        }
                        else
                        {
                            if(IsInRange(temp))
                            {
                                temp.GetComponent<Unit>().hp -= attack;
                            }
                        }
                    }

                    units = GameObject.FindGameObjectsWithTag("Team2");
                    foreach (GameObject temp in units)
                    {
                        if (temp.GetComponent<Building>())
                        {

                        }
                        else
                        {
                            if (IsInRange(temp))
                            {
                                temp.GetComponent<Unit>().hp -= attack;
                                healthBar.fillAmount = (float)hp / maxHP;
                            }
                        }
                    }

                    timer = 0;

                }
            }
        }

        else
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
                if (timer > 0.5f)
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
            if (timer >0.5f)
            {
                Enemy.GetComponent<Unit>().hp -= attack;
                timer = 0;
                healthBar.fillAmount = (float)hp / maxHP;
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
        float distance = 9999;


        switch (team)
        {
            case 1:
                units = GameObject.FindGameObjectsWithTag("Team2");

                foreach (GameObject temp in units)
                {
                    float tempDist = Vector3.Distance(transform.position, temp.transform.position);
                    if (tempDist <= distance)
                    {
                        distance = tempDist;
                        unit = temp;
                    }
                }

                units = GameObject.FindGameObjectsWithTag("Team3");

                foreach (GameObject temp in units)
                {
                    float tempDist = Vector3.Distance(transform.position, temp.transform.position);
                    if (tempDist <= distance)
                    {
                        distance = tempDist;
                        unit = temp;
                    }
                }

                break;
            case 2:
                units = GameObject.FindGameObjectsWithTag("Team1");

                foreach (GameObject temp in units)
                {
                    float tempDist = Vector3.Distance(transform.position, temp.transform.position);
                    if (tempDist <= distance)
                    {
                        distance = tempDist;
                        unit = temp;
                    }
                }

                units = GameObject.FindGameObjectsWithTag("Team3");

                foreach (GameObject temp in units)
                {
                    float tempDist = Vector3.Distance(transform.position, temp.transform.position);
                    if (tempDist <= distance)
                    {
                        distance = tempDist;
                        unit = temp;
                    }
                }


                break;
            case 3:
                units = GameObject.FindGameObjectsWithTag("Team1");

                foreach (GameObject temp in units)
                {
                    if (temp.GetComponent<Building>())
                    {

                    }
                    else
                    {
                        float tempDist = Vector3.Distance(transform.position, temp.transform.position);
                        if (tempDist <= distance)
                        {
                            distance = tempDist;
                            unit = temp;
                        }
                    }

                }

                units = GameObject.FindGameObjectsWithTag("Team2");

                foreach (GameObject temp in units)
                {
                    if (temp.GetComponent<Building>())
                    {

                    }
                    else
                    {
                        float tempDist = Vector3.Distance(transform.position, temp.transform.position);
                        if (tempDist <= distance)
                        {
                            distance = tempDist;
                            unit = temp;
                        }
                    }
                }


                break;
        }
        return unit;
    }
}

