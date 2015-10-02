using UnityEngine;
using System.Collections;

public class RacerMovement : MonoBehaviour {

    public GameObject finishLine;
    public GameObject startLine;
    float acceleration;
    bool raceStart;


    // Use this for initialization
    void Start () {
        raceStart = false;
        acceleration = Random.Range(0.01f, 0.03f);
        Debug.Log(acceleration);
    }
	
	// Update is called once per frame
	void Update () {
        if(raceStart == true)
        {
            Vector3 position = this.transform.position;
            if (position.x >= 25 && position.x <= 25.2f)
            {
                Deccelerate();
                Debug.Log(acceleration);
            }
            else if (position.x >= 50 && position.x <= 50.2f)
            {
                Accelerate();
                Debug.Log(acceleration);
            }
            else if (position.x >= 75 && position.x <= 75.2f)
            {
                Deccelerate();
                Debug.Log(acceleration);
            }
            position.x = position.x + acceleration + 0.03f;
            this.transform.position = position;
        }
    }

    void Deccelerate()
    {
        acceleration = Random.Range(-0.02f, -0.01f);
    }

    void Accelerate()
    {
        acceleration = Random.Range(0.00f, 0.01f);
    }

    public void Racestart()
    {
        raceStart = true;
    }
}
