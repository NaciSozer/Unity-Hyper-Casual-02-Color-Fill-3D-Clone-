using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatArea : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    [SerializeField] private float xStartPos;
    [SerializeField] private float yStartPos;
    [SerializeField] private int columnSize;
    [SerializeField] private int rowSize;
    [Range(0, 2)] [SerializeField] private int xSpace;
    [Range(0, 2)] [SerializeField] private int ySpace;
    [SerializeField] GameObject areas,addArea;
   
    public void CreatAllArea()
    {
        areas = GameObject.FindGameObjectWithTag("Areas");

        if(areas.transform.childCount == 0) {
            for (int i = 0; i < columnSize * rowSize; i++)
            {
                addArea = Instantiate(ground, new Vector3
                    (xStartPos + (xSpace * (i / columnSize)),
                    0f,
                    yStartPos + (ySpace * (i % columnSize))), Quaternion.identity);
                addArea.transform.SetParent(areas.transform);
                //Debug.Log(xSpace + " Kadar boþluk var" + ySpace + " Kadar boþluk var");
                Debug.Log(ground.transform.position);
            }
        }

        else
        {
            DeleteAllArea();
            CreatAllArea();
        }
        
    }

    public void DeleteAllArea()
    {
        var allarea = GameObject.FindGameObjectsWithTag("Box");
        foreach (var area in allarea)
        {
            DestroyImmediate(area);
        }
    }


    
}
