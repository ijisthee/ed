using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Candy : MonoBehaviour {

    public int Column { get; set; }
    public int Row { get; set; }
    public string Type { get; set; }

    // Use this for initialization
    void Start () {
		
	}

    /// <summary>
    /// Constructor alternative
    /// </summary>
    /// <param name="type"></param>
    /// <param name="row"></param>
    /// <param name="column"></param>
    public void Assign(string type, int row, int column)
    {
        if (string.IsNullOrEmpty(type))
        {
            throw new ArgumentException("type");
        }
        Column = column;
        Row = row;
        Type = type;
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Checks if the current shape is of the same type as the parameter
    /// </summary>
    /// <param name="otherShape"></param>
    /// <returns></returns>
    public bool IsSameType(Candy otherShape)
    {
        if (otherShape == null || !(otherShape is Candy))
            throw new ArgumentException("otherShape");

        return string.Compare(this.Type, (otherShape as Candy).Type) == 0;
    }
}
