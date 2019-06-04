using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorGeneratorScript : MonoBehaviour {

    public GameObject sectorPrefab;
    public int number;

	// Use this for initialization
	void Start ()
    {
        populateSector();
	}
	
	public void populateSector()
    {
        float h = Camera.main.orthographicSize * 2;
        float w = h * Camera.main.aspect;

        SectorMap map = new SectorMap(number,w,h);
        List<Sector> sectors = map.sectors;

        for(int i = 0; i< sectors.Count;i++)
        {
            createSector(sectors[i]);
        }
    }

    private void createSector(Sector sector)
    {
        Instantiate(sectorPrefab,sector.loc,Quaternion.identity);
    }
}
