using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Uretec : MonoBehaviour
{
    int sayi;


    

    // Start is called before the first frame update
    void Start()
    {
        sayi = Uret();
        Debug.Log(sayi);
     Debug.Log((sayi/100)*100);
        Debug.Log(onluk_Yuvarla(sayi));
        Debug.Log(yuzluk_Yuvarla(sayi));
        Debug.Log(binlik_Yuvarla(sayi));
        //yuzluk_txt.text = yuzluk_Yuvarla(sayi).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Uret() 
    {

        System.Random random = new System.Random();
       

        int randomValue = random.Next (100, 5000);//random.Next(1000) * (max - min) + min;
        return randomValue;


    }

   

    static int yuzluk_Yuvarla(int sayi)// enyakýn yüzlüðe yuvarla
    {
        return ((int)Math.Round(sayi / 100.0)) * 100;
    }


    static int onluk_Yuvarla(int sayi)// enyakýn onluða yuvarla
    {
        return ((int)Math.Round(sayi / 10.0)) * 10;
    }

    static int binlik_Yuvarla(int sayi)// enyakýn binliðe yuvarla
    {
        return ((int)Math.Round(sayi / 1000.0)) * 1000;
    }
}
