using UnityEngine;
using System.Collections.Generic;

public class Sector
{
	public Vector2 loc { get; private set; }
	public List<Sector> connected { get; private set; }

	public Sector(float sizeX, float sizeY)
	{
		float locX = Random.Range(-sizeX / 2, sizeX / 2);
		float locY = Random.Range(-sizeY / 2, sizeY / 2);
		loc = new Vector2(locX, locY);

		connected = new List<Sector>();
	}

	public void connectToSector(Sector s)
	{
		connected.Add(s);
	}
}