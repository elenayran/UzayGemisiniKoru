using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanlarinÇiktigiYer : MonoBehaviour
{
    public GameObject dusmanPrefabi;
    public float genislik;
    public float yukseklik;
    public float speed;

    public bool sagaHareket = true;
    private float xmax;
    private float xmin;
    // Start is called before the first frame update
    void Start()
    {
        float ObjeIleKameraZsininFarki = transform.position.z - Camera.main.transform.position.z;
        Vector3 kameraninSolTarafi = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, ObjeIleKameraZsininFarki));
        Vector3 kameraninSagTarafi = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, ObjeIleKameraZsininFarki));
        xmin = kameraninSolTarafi.x;
        xmax = kameraninSagTarafi.x;
        foreach (Transform cocuk in transform)
        {
            GameObject enemy = Instantiate(dusmanPrefabi,cocuk.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = cocuk;
        }
       
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(genislik, yukseklik));
    }
    // Update is called once per frame
    void Update()
    {
        if (sagaHareket)
        {
            // transform.position += new Vector3(speed * Time.deltaTime, 0);
            transform.position += Vector3.right *speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        float sagSinir = transform.position.x + genislik / 2;
        float solSinir = transform.position.x - genislik / 2;

        if (sagSinir > xmax   )
        {

            sagaHareket = false;

        }
        else if (solSinir < xmin)
        {
            sagaHareket = true;
        }
    }
}
