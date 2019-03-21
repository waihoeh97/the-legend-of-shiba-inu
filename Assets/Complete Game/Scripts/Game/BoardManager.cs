using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardManager : ColorToPrefab
{
	public Texture2D mapGround;
    public Texture2D mapTree;
	public Texture2D mapEnvironmentObject;

    public ColorPrefab[] colorMappings;

    private float tileSize = 0.64f;

	void GenerateTileMap(Texture2D map)
	{
		for (int x = 0; x < map.width; x++)
		{
			for ( int y = 0; y < map.height; y++)
			{
				BoardSetup(map, x, y);
			}
		}
    }

	void BoardSetup(Texture2D map, int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0)
		{
			//! Pixel is transparrent. Ignore.
			return;
		}
        
		foreach(ColorPrefab colorMapping in colorMappings)
		{
            if (colorMapping.color.Equals(pixelColor))
			{
				Vector2 position = new Vector2(x * tileSize, y *tileSize);
				Instantiate(colorMapping.tileObject, position, Quaternion.identity, transform);
                
//                if(colorMapping.tile == 0)
//                {
//                    colorMapping.tileObject.GetComponent<SpriteRenderer>().sortingLayerName = "Floor";
//                }
//                else
//                {
//                    colorMapping.tileObject.GetComponent<SpriteRenderer>().sortingLayerName = "Floor";
//                }
                
            }
		}
        
	}

	public void SetupScene()
	{
        GenerateTileMap(mapGround);
        GenerateTileMap(mapTree);
		GenerateTileMap(mapEnvironmentObject);
    }
}