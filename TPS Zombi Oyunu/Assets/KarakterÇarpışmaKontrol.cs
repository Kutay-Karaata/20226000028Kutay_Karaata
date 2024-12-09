using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterCarpismaKontrol : MonoBehaviour
{
    private AteşEtme atesEtme;

    private void Start()
    {
        atesEtme = GetComponent<AteşEtme>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mermi"))
        {
            MermiKodu mermiKodu = other.gameObject.GetComponent<MermiKodu>();
            atesEtme.SarjorEkle(mermiKodu.sarjorMiktari);
            Destroy(other.gameObject);
        }
    }
}
