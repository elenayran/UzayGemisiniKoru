using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanlarinÇiktigiYer : MonoBehaviour
{
    public GameObject dusmanPrefabi;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy= Instantiate(dusmanPrefabi, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        enemy.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
