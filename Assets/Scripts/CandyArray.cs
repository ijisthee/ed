using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CandyArray : MonoBehaviour {

    private GameObject[,] candies = new GameObject[Constants.Rows, Constants.Columns];

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <returns></returns>
    public GameObject this[int row, int column]
    {
        get
        {
            try
            {
                return candies[row, column];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        set
        {
            candies[row, column] = value;
        }
    }

    /// <summary>
    /// Removes (sets as null) an item from the array
    /// </summary>
    /// <param name="item"></param>
    public void Remove(GameObject item)
    {
        candies[item.GetComponent<Candy>().Row, item.GetComponent<Candy>().Column] = null;
    }
}
