using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Slider levelSlider;
    public int levelSliderValue;
    public GameObject[] ground;

    void Start()
    {
        ground = GameObject.FindGameObjectsWithTag("Box");
        levelSlider.maxValue = ground.Length;
        levelSlider.value = levelSliderValue;
       
        
    }

    
    public void LevelCompleted(int levelComplated)
    {
        levelSliderValue += levelComplated;
        levelSlider.value = levelSliderValue;


        if(levelSliderValue == ground.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }



}
