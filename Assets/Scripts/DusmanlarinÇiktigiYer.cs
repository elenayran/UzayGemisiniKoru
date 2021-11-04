using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanlarinÇiktigiYer : MonoBehaviour
{
    public GameObject dusmanPrefabi;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform cocuk in transform)
        {
            GameObject enemy = Instantiate(dusmanPrefabi,cocuk.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = cocuk;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
