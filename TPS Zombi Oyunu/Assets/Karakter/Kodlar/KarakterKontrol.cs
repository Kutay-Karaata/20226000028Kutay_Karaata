
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float KarakterHiz;
    [SerializeField]
     float ziplamaGucu = 5f; // Zýplama gücü
    private float saglik = 100;
    private bool hayattaMi;
    private bool yerdeMi; // Karakterin yerde olup olmadýðýný kontrol eder
    private Rigidbody rb; // Rigidbody bileþeni

    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>(); // Rigidbody bileþeni alýnýyor
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
            Ziplama(); // Zýplama fonksiyonunu çaðýr
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
        // Zýplama kontrolü: Karakter "Space" tuþuna basarsa ve yerdeyse zýplar
        if (Input.GetKeyDown(KeyCode.Space) && yerdeMi)
        {
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            anim.SetTrigger("zipladi"); // Zýplama animasyonu tetikleniyor
            yerdeMi = false; // Zýpladýðý için artýk havada
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Yere temas edildiðinde yerdeMi'yi true yap
        if (collision.gameObject.CompareTag("Untagged"))
        {
            yerdeMi = true;
        }
    }
}

