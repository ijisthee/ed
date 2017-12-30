using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class CandyManager : MonoBehaviour {

    public CandyArray candies;

    public int Rows = 12;
    public int Columns = 8;

    public readonly Vector2 BottomRight = new Vector2(-2.37f, -4.27f);
    public readonly Vector2 CandySize = new Vector2(0.7f, 0.7f);

    private Vector2[] SpawnPositions;
    public GameObject[] CandyPrefabs;
    public SoundManager soundManager;

    // Use this for initialization
    void Start () {
        InitializeCandies();
        InitializeCandyAndSpawnPositions();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Initialize candies
    /// </summary>
    private void InitializeCandies()
    {
        //just assign the name of the prefab
        foreach (var item in CandyPrefabs)
        {
            item.GetComponent<Candy>().Type = item.name;

        }
    }

    public void InitializeCandyAndSpawnPositions()
    {
        if (candies != null)
            DestroyAllCandy();

        candies = new CandyArray();
        SpawnPositions = new Vector2[Columns];

        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                GameObject newCandy = GetRandomCandy();

                //check if two previous horizontal are of the same type
                while (column >= 2 && candies[row, column - 1].GetComponent<Candy>()
                    .IsSameType(newCandy.GetComponent<Candy>())
                    && candies[row, column - 2].GetComponent<Candy>().IsSameType(newCandy.GetComponent<Candy>()))
                {
                    newCandy = GetRandomCandy();
                }

                //check if two previous vertical are of the same type
                while (row >= 2 && candies[row - 1, column].GetComponent<Candy>()
                .IsSameType(newCandy.GetComponent<Candy>())
                && candies[row - 2, column].GetComponent<Candy>().IsSameType(newCandy.GetComponent<Candy>()))
                {
                newCandy = GetRandomCandy();
                }

                InstantiateAndPlaceNewCandy(row, column, newCandy);
            }
        }

        SetupSpawnPositions();
    }

    private void InstantiateAndPlaceNewCandy(int row, int column, GameObject newCandy)
    {
        GameObject go = Instantiate(newCandy,
            BottomRight + new Vector2(column * CandySize.x, row * CandySize.y), Quaternion.identity)
            as GameObject;

        //assign the specific properties
        go.GetComponent<Candy>().Assign(newCandy.GetComponent<Candy>().Type, row, column);
        candies[row, column] = go;
    }

    private void SetupSpawnPositions()
    {
        //create the spawn positions for the new candies (will pop from the 'ceiling')
        for (int column = 0; column < Columns; column++)
        {
            SpawnPositions[column] = BottomRight
                + new Vector2(column * CandySize.x, Rows * CandySize.y);
        }
    }

    /// <summary>
    /// Get a random candy
    /// </summary>
    /// <returns></returns>
    private GameObject GetRandomCandy()
    {
        return CandyPrefabs[Random.Range(0, CandyPrefabs.Length)];
    }

    /// <summary>
    /// Destroy all candy gameobjects
    /// </summary>
    private void DestroyAllCandy()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                Destroy(candies[row, column]);
            }
        }
    }
}
