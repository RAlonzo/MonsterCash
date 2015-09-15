using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;

		public Count (int min, int max) 
		{
			minimum = min;
			maximum = max;
		}
	}

	public int columns =40;
	public int rows =5;
	public Count itemsCount = new Count(1,5);
	public GameObject finishLine;
	public GameObject[] zombieTiles;
	public GameObject[] itemTiles;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List<Vector3>();

	void InitialiseList()
	{
		gridPositions.Clear ();

		for (int x = 1; x < columns; x++) 
		{
			for (int y = 1; y < rows; y++)
			{
				gridPositions.Add(new Vector3(x,y,0f));
			}
		}
	}

	void ZombieSetup() 
	{
		boardHolder = new GameObject ("Board").transform;

		int x = 1;

		for (int y = -1; y < rows + 1; y++)
		{
			GameObject toInstantiate = zombieTiles[y +1];

			GameObject instance = Instantiate(toInstantiate, new Vector3 (x,y,0f), Quaternion.identity) as GameObject;
		
			instance.transform.SetParent(boardHolder);
		}
	}

	//RandomPosition returns a random position from our list gridPositions.
	Vector3 RandomPosition() 
	{
		int randomIndex = Random.Range (0, gridPositions.Count); 
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	//LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
	void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
	{
		//Choose a random number of objects to instantiate within the minimum and maximum limits
		int objectCount = Random.Range (minimum, maximum + 1);

		//Instantiate objects until the randomly chosen limit objectCount is reached
		for (int i = 0; i < objectCount; i++) {
			//Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
			Vector3 randomPosition = RandomPosition ();
			
			//Choose a random tile from tileArray and assign it to tileChoice
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			
			//Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
			Instantiate (tileChoice, randomPosition, Quaternion.identity);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
