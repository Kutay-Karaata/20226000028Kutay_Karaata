using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AteşEtme : MonoBehaviour
{
    public Camera kamera;
    public LayerMask zombiKatman;
    KarakterKontrol hpKontrol;
    public ParticleSystem muzzleFlash;
    Animator anim;

    public float sarjor = 5;
    public float cephane = 30;
    public float sarjorKapasitesi = 5;

    public GameObject mermiefekti;
    public GameObject kanefekti;

    public AudioSource silahSesKaynağı;  // Ses kaynağı
    public AudioClip ateşSesi;           // Silah ateş sesi

    void Start()
    {
        kamera = Camera.main;
        hpKontrol = this.gameObject.GetComponent<KarakterKontrol>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (hpKontrol.YasiyorMu() == true)
        {
            if (Input.GetMouseButton(0))  // Sağ tıkla ateş etme
            {
                if (sarjor > 0)
                {
                    anim.SetBool("atesEt", true);
                }
                if (sarjor <= 0)
                {
                    anim.SetBool("atesEt", false);
                }
                if (sarjor <= 0 && cephane > 0)
                {
                    anim.SetBool("sarjorDegistirme", true);
                }
            }
            else
            {
                anim.SetBool("atesEt", false);
            }
        }
    }

    public void SarjorDegistirme()
    {
        cephane -= sarjorKapasitesi - sarjor;
        sarjor = sarjorKapasitesi;
        anim.SetBool("sarjorDegistirme", false);
    }

    public void SarjorEkle(float sarjorMiktarı)
    {
        sarjor += sarjorMiktarı;
    }

    public void AtesEtme()
    {
        if (sarjor > 0)
        {
            sarjor--;
            muzzleFlash.Play();  // Muzzle flash (ateş ışığı) efekti

            // Silah sesi
           // silahSesKaynağı.PlayOneShot(source);

            Vector3 mermiYönü = new Vector3(0.5f, 0.5f, 0);
            Ray ray = kamera.ViewportPointToRay(mermiYönü);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombiKatman))
            {
                hit.collider.gameObject.GetComponent<Zombi>().HasarAl();
                Debug.Log("vurdum");
            }
        }
    }
}



