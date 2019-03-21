using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToPrefab : MonoBehaviour
{
    public enum TileKind
    {
        GROUND = 0,

		TREE_1_1,
		TREE_1_2,
		TREE_1_3,
		TREE_1_4,
		TREE_1_5,

		TREE_2_1,
		TREE_2_2,
		TREE_2_3,
		TREE_2_4,
		TREE_2_5,

		TREE_3_1,
		TREE_3_2,
		TREE_3_3,
		TREE_3_4,
		TREE_3_5,

		TREE_4_1,
		TREE_4_2,
		TREE_4_3,
		TREE_4_4,
		TREE_4_5,

		TREE_5_1,
		TREE_5_2,
		TREE_5_3,
		TREE_5_4,
		TREE_5_5,

		TREE_6_1,
		TREE_6_2,
		TREE_6_3,
		TREE_6_4,
		TREE_6_5,

		TREE_7_1,
		TREE_7_2,
		TREE_7_3,
		TREE_7_4,
		TREE_7_5,

        TREE_FRONT,
        TREE_MID,
        TREE_CLONE,
        TREE_REAR,

		FIRE,
		BUSH
    }

    [System.Serializable]
    public class ColorPrefab
    {
        //public GameObject tilePrefab;
        public TileKind tile;
        public Color color;
        public GameObject tileObject;
    }
}


