using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Script : MonoBehaviour
{
    private Rigidbody2D Maymun;

    public float move_Speed = 2f;

    public float normal_Itme = 10f;
    public float extra_Itme = 14f;

    private bool initial_Push;

    private int Itme_Sayisi;

    private bool player_Oldu;
    public GameObject kazandin_pnl;
    public TextMeshProUGUI hatali_txt;
    public int can = 10;
    public TextMeshProUGUI Puan_txt;
    public int puan = 0;

    void Awake()//ilk çalýþacak kod
    {
        Maymun = GetComponent<Rigidbody2D>();//fizik iþlemleri için
        can = 10;
        hatali_txt.text = "X : " + can;
        puan = 0;
        Puan_txt.text = "Puan : " + puan + " /100";

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()// hareket methodu
    {

        if (player_Oldu)
            return;

        if (SimpleInput.GetAxisRaw("Horizontal") > 0)//hareket sýfýrdan büyükse
        {

            Maymun.velocity = new Vector2(move_Speed, Maymun.velocity.y);

        }
        else if (SimpleInput.GetAxisRaw("Horizontal") < 0)//hareket sýfýrdan küçük ise
        {

            Maymun.velocity = new Vector2(-move_Speed, Maymun.velocity.y);

        }

    } // player hareketi

    void OnTriggerEnter2D(Collider2D target)
    {

        if (player_Oldu)// maymun kaybederse return ile method ignore et
            return;

        if (target.tag == "extra_Itme")
        {

            if (!initial_Push)
            {

                initial_Push = true;

                Maymun.velocity = new Vector2(Maymun.velocity.x, 18f);

                target.gameObject.SetActive(false);

                Ses_Yonetim.instance.JumpSoundFX();

                // ilk itme nedeniyle trigger giriþinden çýkýþ
                return;
            } // ilk itme

            // ilk itme blok sonu

        } 

        if (target.tag == "NormalItme")
        {

            puan += 3;
            Puan_txt.text = "Puan : " + puan + " /100";

            Maymun.velocity = new Vector2(Maymun.velocity.x, normal_Itme);

            target.gameObject.SetActive(false);

            Itme_Sayisi++;

            Ses_Yonetim.instance.JumpSoundFX();

        }

        if (target.tag == "extra_Itme")
        {

            puan += 5;
            Puan_txt.text = "Puan : " + puan + " /100";

            Maymun.velocity = new Vector2(Maymun.velocity.x, extra_Itme);

            target.gameObject.SetActive(false);

            Itme_Sayisi++;

            Ses_Yonetim.instance.JumpSoundFX();//zýplama sesi

        }

        if (Itme_Sayisi == 2)
        {

            Itme_Sayisi = 0;
            PlatformSpawner.instance.SpawnPlatforms();

        }

        //can konrolü
        if (target.tag == "Yanlis_Kutu")
        {
            can--;
            hatali_txt.text = "X : " + can;
        }

        if (target.tag == "MaymunDustu" || target.tag == "Yanlis_Kutu")
        {
            Ses_Yonetim.instance.GameOverSoundFX();

            if (can==0)
            {
                player_Oldu = true;//maymun düþtü
                Yonetim.instance.RestartGame();
            }

            

            

         
        }



        if (puan>=100)//(target.tag == "Kazandýn" || target.tag == "Puan kontrol")
        {
            
            kazandin_pnl.SetActive(true);
            Time.timeScale = 0;
            ////colider ile temas ve puan kontrolü kazandýn paneli açýlmasý

            //Ses_Yonetim.instance.GameOverSoundFX();

            //Yonetim.instance.RestartGame();//kaybet panel gelecek.
        }

    } // on trigger enter
}
