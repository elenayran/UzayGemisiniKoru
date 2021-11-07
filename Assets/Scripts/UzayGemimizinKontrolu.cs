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
    // Start is called before the first frame update
    void Start()
    {
        float uzaklýk = transform.position.z - Camera.main.transform.position.z;
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, uzaklýk));
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklýk));
        xmin = solUc.x + inceAyar;
        xmax = sagUc.x - inceAyar;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {

            Instantiate(Mermi, transform.position, Quaternion.identity);
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
}
