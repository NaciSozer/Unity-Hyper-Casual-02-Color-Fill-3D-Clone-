using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorKontrooler : MonoBehaviour
{
    public static int boxNumber;
    public Material[] material;
    MeshRenderer color;
    LevelManager levelControl;
    void Start()
    {
        boxNumber++;
        
        levelControl = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        color = GetComponent<MeshRenderer>();
        color.enabled = true;
        color.sharedMaterial = material[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBox"))
        {
            color.sharedMaterial = material[1];
            Debug.Log("Temas var");

            levelControl.LevelCompleted(1);

        }
    }
}
