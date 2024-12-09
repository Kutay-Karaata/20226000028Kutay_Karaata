using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour
{
    public float zombiHP = 10;
    bool zombiDeath;
    Animator zombiAnim;
   public float kovalamaMesafesi;
    NavMeshAgent zombiNavMesh;
    public float saldirmaMesafesi;
    float mesafe;
    GameObject hedefOyuncu;
    void Start()
    {
        zombiAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("Swat (1) 1");
        zombiNavMesh = this.GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
       
        if (zombiHP <= 0)
        {
            zombiDeath = true;  
        }

        if (zombiDeath == true)
        {
            zombiAnim.SetBool("Bool death",true);
            StartCoroutine(Yok01());
        }

        else
        {
            mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if (mesafe < kovalamaMesafesi)
            {
                zombiNavMesh.isStopped = false;
                zombiNavMesh.SetDestination(hedefOyuncu.transform.position);
                zombiAnim.SetBool("yuruyor", true);
              //  zombiAnim.SetBool("saldýrýyor", false);
                this.transform.LookAt(hedefOyuncu.transform.position);
            }
            else
            {
                zombiNavMesh.isStopped = true;
                zombiAnim.SetBool("yuruyor", false);
                zombiAnim.SetBool("saldýrýyor", false);

                //durma animasyonu
            }
            if (mesafe < saldirmaMesafesi)
            {
                this.transform.LookAt(hedefOyuncu.transform.position);
                zombiNavMesh.isStopped = true ;
                zombiAnim.SetBool("yuruyor", false);
                zombiAnim.SetBool("saldýrýyor",  true);
                //vurma animasyonu
            }
        }
    }
    public void HasarVer()
    {
       hedefOyuncu.GetComponent<KarakterKontrol>().HasarAl();
    }
    IEnumerator Yok01()
    {
        yield return new WaitForSeconds(10);

        Destroy(this.gameObject);
    }

    public void HasarAl()
    {
        zombiHP -= Random.Range(15, 25);
    }
}
