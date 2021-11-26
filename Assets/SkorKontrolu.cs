using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkorKontrolu : MonoBehaviour
{
    public int skor;
    private Text benimMetnim;

    private void Start()
    {
        benimMetnim = GetComponent<Text>();
        SkoruSifirla();
    }
    public void SkorArtttirma(int puanlar)
    {
        skor += puanlar;
        benimMetnim.text = skor.ToString();
    }
    public void SkoruSifirla()
    {
        skor = 0;
        benimMetnim.text = skor.ToString();
    }
}
