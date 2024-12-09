
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float KarakterHiz;
    [SerializeField]
     float ziplamaGucu = 5f; // Z�plama g�c�
    private float saglik = 100;
    private bool hayattaMi;
    private bool yerdeMi; // Karakterin yerde olup olmad���n� kontrol eder
    private Rigidbody rb; // Rigidbody bile�eni

    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>(); // Rigidbody bile�eni al�n�yor
        hayattaMi = true;
    }

    void Update()
    {
        if (saglik <= 0)
        {
            hayattaMi = false;
            anim.SetBool("yasiyorMu", hayattaMi);
        }
        if (hayattaMi == true)
        {
            Hareket();
            Ziplama(); // Z�plama fonksiyonunu �a��r
        }
    }

    public bool YasiyorMu()
    {
        return hayattaMi;
    }
    public void HasarAl()
    {
        saglik -= Random.Range(5, 10);
    }

    void Hareket()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", yatay);
        anim.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * KarakterHiz * Time.deltaTime, 0, dikey * KarakterHiz * Time.deltaTime);
    }

    void Ziplama()
    {
        // Z�plama kontrol�: Karakter "Space" tu�una basarsa ve yerdeyse z�plar
        if (Input.GetKeyDown(KeyCode.Space) && yerdeMi)
        {
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            anim.SetTrigger("zipladi"); // Z�plama animasyonu tetikleniyor
            yerdeMi = false; // Z�plad��� i�in art�k havada
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Yere temas edildi�inde yerdeMi'yi true yap
        if (collision.gameObject.CompareTag("Untagged"))
        {
            yerdeMi = true;
        }
    }
}

