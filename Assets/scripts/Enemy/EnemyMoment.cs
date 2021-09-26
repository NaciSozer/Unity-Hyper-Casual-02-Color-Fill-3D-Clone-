using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]  
public class EnemyMoment : ScriptableObject
{
   public GameObject[] gidilicekNoktalar;
   public GameObject[] objectChild;

    public float speed;
    //Saw objesinin oluþturulan chil objeleri arasýnda gidip gelme iþlemleri
    public bool aradakiMesafeyiBirkereAl = true;
    public Vector3 aradakiMesafe;
    public int aradakiMesafeSayac;
    public bool birKereGitti = true;

}
