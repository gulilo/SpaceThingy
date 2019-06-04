using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorMap
{
    int numberOfSectors;
	public List<Sector> sectors;

    public SectorMap(int numOfSectors, float sizeX,float sizeY)
    {
        numberOfSectors = numOfSectors;
        sectors = new List<Sector>();
        for (int i = 0; i < numberOfSectors; i++)
        {
            Sector s = new Sector(sizeX, sizeY);

            sectors.Add(s);
        }
    }


}
