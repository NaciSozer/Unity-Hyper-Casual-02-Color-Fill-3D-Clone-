using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemyController : MonoBehaviour
{
    GameObject[] gidilicekNoktalar;
    GameObject[] sawChild;


    //Enemy objesinin oluþturulan chil objeleri arasýnda gidip gelme iþlemleri
    bool aradakiMesafeyiBirkereAl = true;
    Vector3 aradakiMesafe;
    int aradakiMesafeSayac;
    bool birKereGitti = true;

    void Start()
    {
        

        gidilicekNoktalar = new GameObject[transform.childCount];

        for(int i = 0; i < gidilicekNoktalar.Length; i++)
        {
            gidilicekNoktalar[i] = transform.GetChild(0).gameObject;
            gidilicekNoktalar[i].transform.SetParent(transform.parent);


        }
        
    }

    
    void FixedUpdate()
    {

        NoktalaraGit();

    }

    public void NoktalaraGit()
    {
        if (aradakiMesafeyiBirkereAl)
        {
            aradakiMesafe = (gidilicekNoktalar[aradakiMesafeSayac].transform.position - transform.position).normalized;
            aradakiMesafeyiBirkereAl = false;

        }

        float mesafe = Vector3.Distance(transform.position, gidilicekNoktalar[aradakiMesafeSayac].transform.position);

        transform.position += aradakiMesafe * Time.deltaTime * 10;

        if (mesafe < 0.5f)
        {
            aradakiMesafeyiBirkereAl = true;


            if (aradakiMesafeSayac == gidilicekNoktalar.Length - 1)
            {
                birKereGitti = false;
            }
            else if (aradakiMesafeSayac == 0)
            {
                birKereGitti = true;
            }


            if (birKereGitti)
            {
                aradakiMesafeSayac++;

            }

            else
            {
                aradakiMesafeSayac--;

            }




        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {



        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 0.7f);

        }

        for (int i = 0; i < transform.childCount - 1; i++)
        {

            Gizmos.color = Color.blue;

            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);


        }

    }
#endif

}

#if UNITY_EDITOR
[CustomEditor(typeof(EnemyController))]
[System.Serializable]

class EnemyEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EnemyController script = (EnemyController)target;//EnemyController sýnýfýndaki public tanýmlanan herþeye ulaþmamýzý saðlýyor.

        if (GUILayout.Button("New Object", GUILayout.MinWidth(100), GUILayout.Width(100)))//Butona bastýðýmýzda bu bloktaki objeleri oluþturur.
        {

            GameObject newGameObject = new GameObject("Enemy");

            newGameObject.transform.parent = script.transform;
            newGameObject.transform.position = script.transform.position;
            newGameObject.name = script.transform.childCount.ToString();



        }


    }


}
#endif