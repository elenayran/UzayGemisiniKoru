using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKontrolu : MonoBehaviour
{
    public float can = 100f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MermiKontrolu carpanMermi = collision.gameObject.GetComponent<MermiKontrolu>();

        if (carpanMermi)
        {
            carpanMermi.carptigindaYokOL();
            can -= carpanMermi.ZararVerme();

            if (can <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
