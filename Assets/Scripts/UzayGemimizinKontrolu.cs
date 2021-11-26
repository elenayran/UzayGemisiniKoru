using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemimizinKontrolu : MonoBehaviour
{
    public float speed;
    public float inceAyar = 0.7f;
     float xmin;
     float xmax;
    public GameObject Mermi;
    public float mermininHizi = 1f;
    public float atesEtmeAraligi = 2f;
    public float can = 400f;

    public AudioClip AtesSesi;
    public AudioClip OlumSesi;
    // Start is called before the first frame update
    void Start()
    {
        float uzaklik = transform.position.z - Camera.main.transform.position.z;
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, uzaklik));
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklik));
        xmin = solUc.x + inceAyar;
        xmax = sagUc.x - inceAyar;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) // space tuþuna 1 kere basýp devreye girer yani bir kere çalýþýr
        {

            InvokeRepeating("AtesEtme", 0.001f, atesEtmeAraligi); // istenilen fonktiyon ne kadar süre sonra gerçekleþsin ve hangi aralik,siklikla gerçekleþecek
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("AtesEtme");
        }
        float yeniX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(yeniX, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

          //  transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    void AtesEtme()
    {
        GameObject GemimizinMermisi = Instantiate(Mermi, transform.position + new Vector3(0,1f,0), Quaternion.identity) as GameObject; //  as gamebject= gemimizin memisi gameobjest gibi davranmasýný saðlýyoruz

        GemimizinMermisi.GetComponent<Rigidbody2D>().velocity = new Vector3(0, mermininHizi, 0);
        AudioSource.PlayClipAtPoint(AtesSesi, transform.position);
    }


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
                AudioSource.PlayClipAtPoint(OlumSesi, transform.position);
            }
        }
    }
}
