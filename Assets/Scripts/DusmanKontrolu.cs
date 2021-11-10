using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKontrolu : MonoBehaviour
{
    public GameObject mermi;
    public float mermiHizi = 8f;
    public float can = 100f;

   // public float saniyeBasinaMermiAtma = 100000f;
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
        //float atmaOlasiligi = Time.deltaTime * saniyeBasinaMermiAtma;
        if (Random.value < 0.003) //0.003 yerine atma olasýlýðýný yazarakta yapýlabilirdi
        {
            AtesEt();
        }
       
    }

    void AtesEt()
    {
        Vector3 baslangicPozisyonu = transform.position + new Vector3(0, -0.8f, 0);
        GameObject DusmaninMermisi = Instantiate(mermi, baslangicPozisyonu, Quaternion.identity) as GameObject;
        DusmaninMermisi.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -mermiHizi);
    }
}
