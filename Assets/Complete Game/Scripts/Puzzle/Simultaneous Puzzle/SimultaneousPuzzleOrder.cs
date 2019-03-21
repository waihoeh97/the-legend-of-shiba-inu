using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class SimultaneousPuzzleOrder : MonoBehaviour {

public enum Order
{
    PUZZLE_FIRST = 1,
    PUZZLE_SECOND,
    PUZZLE_THIRD,
    PUZZLE_FOURTH
}

[System.Serializable]
public class SimultaneousPuzzleArray
{
    public Order platformOrder;
	public GameObject puzzleObject;
    public Transform platformTransform;
	public SimultaneousPuzzleProperty platformScript;
}
//}
