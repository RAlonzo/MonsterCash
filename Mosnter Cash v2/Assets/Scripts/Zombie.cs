using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public GameObject finishLine;
    public GameObject[] zombie;

    public float[] zombiePosition;

    public float velocity;
    public float deltaTime;
    public float acceleration;
    public float distance;
    public float maxVelocity;
    public float minVelocity;
    public float distFinish;
    public float myPosition;

    public int randomMotion;

    public Vector3 position;

    public bool raceStart;

    public enum State
    {
        Moving,
        Stop
    }

    public enum MovingState
    {
        Slow,
        Normal,
        Fast
    }

    private State _state;

    // Use this for initialization
    void Start()
    {

        raceStart = false;
        deltaTime = 0.1f;
        velocity = 4f;
        maxVelocity = 5.0f;
        minVelocity = 1.0f;
        _state = State.Moving;
        position = this.transform.position;
        distFinish = finishLine.transform.position.x - this.transform.position.x;

        StartCoroutine("RacerState");
    }

    IEnumerator RacerState()
    {
        while (true)
        {


            if (raceStart != false)
            {
                RandomMotion();
                switch (_state)
                {
                    case State.Moving:
                        InMotion(randomMotion);
                        break;
                    case State.Stop:
                        break;
                }
            }
            yield return 0;
        }
    }

    public void InMotion(int index)
    {
        switch(index)
        {
            case 3:
                break;
            case 2:
                Accelerating();
                break;
            case 1:
                Decelerating();
                break;
        }
    }

    private void RandomMotion()
    {

        randomMotion = Random.Range(1, 3);
    }

    void Movement()
    {
        if(velocity > minVelocity && velocity < maxVelocity)
        {
            velocity = deltaTime * acceleration;
        }
        distance = deltaTime * velocity;
        if (this.transform.position.x < distFinish)
        {
            position.x = position.x + distance + 0.005f;
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(position.x, this.transform.position.y, this.transform.position.z), 0.2f);
        }
    }

    public void RaceStatrt()
    {
        raceStart = true;
    }


    void Decelerating()
    {
        acceleration = Random.Range(-0.1f,0f);
        Movement();
    }

    void Accelerating()
    {
        acceleration = Random.Range(0f, 0.4f);
        Movement();
    }

    void DoubleAccelerating()
    {
        acceleration = Random.Range(0.5f, 0.8f);
        Movement();
    }
}
