using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class RacerPositions : MonoBehaviour
{
    List<Racer> zombieRacers = new List<Racer>();

    public GameObject[] racers;
    public GameObject finishLine;

    private string racerTag;

    public string[] standingNames;

    private bool first;
    private bool second;
    private bool third;
    private bool fourth;
    private bool fifth;

    public float[] displacement;
    public float maxDisplacement;
    public int[] lap;
    public int endStanding;

    // Use this for initialization
    void Start()
    {
        zombieRacers.Add(new Racer("Ruben", 100));
        zombieRacers.Add(new Racer("Kevin", 100));
        zombieRacers.Add(new Racer("Matt", 100));
        zombieRacers.Add(new Racer("Rafael", 100));
        zombieRacers.Add(new Racer("Demi", 100));

        endStanding = 0;
        for (int i = 0; i < 5; i++)
        {
            displacement[i] = finishLine.transform.position.x - racers[i].transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            displacement[i] = finishLine.transform.position.x - racers[i].transform.position.x;
        }

        zombieRacers.Sort();
    }
}
