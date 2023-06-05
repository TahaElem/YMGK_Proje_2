using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    private Rigidbody2D Maymun;

    public float move_Speed = 2f;

    public float normal_Itme = 10f;
    public float extra_Itme = 14f;

    private bool initial_Push;

    private int Itme_Sayisi;

    private bool player_Oldu;

    void Awake()//ilk çalýþacak kod
    {
        Maymun = GetComponent<Rigidbody2D>();//fizik iþlemleri için

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

            Maymun.velocity = new Vector2(Maymun.velocity.x, normal_Itme);

            target.gameObject.SetActive(false);

            Itme_Sayisi++;

            Ses_Yonetim.instance.JumpSoundFX();

        }

        if (target.tag == "extra_Itme")
        {

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

        if (target.tag == "MaymunDustu" || target.tag == "Yanlis_Kutu")
        {

            player_Oldu = true;//maymun düþtü

            Ses_Yonetim.instance.GameOverSoundFX();

            Yonetim.instance.RestartGame();
        }



        if (target.tag == "Kazandýn" || target.tag == "Puan kontrol")
        {

            //colider ile temas ve puan kontrolü kazandýn paneli açýlmasý

            Ses_Yonetim.instance.GameOverSoundFX();

            Yonetim.instance.RestartGame();//kaybet panel gelecek.
        }

    } // on trigger enter
}
