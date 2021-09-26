using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]  
public class EnemyMoment : ScriptableObject
{
   public GameObject[] gidilicekNoktalar;
   public GameObject[] objectChild;

    public float speed;
    //Saw objesinin olu�turulan chil objeleri aras�nda gidip gelme i�lemleri
    public bool aradakiMesafeyiBirkereAl = true;
    public Vector3 aradakiMesafe;
    public int aradakiMesafeSayac;
    public bool birKereGitti = true;

}
