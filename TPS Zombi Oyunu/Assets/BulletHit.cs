using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject bloodEffectPrefab; // Asset Store’dan gelen kan efekti prefab’ý

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            if (hit.collider.CompareTag("Zombi")) // Zombi ile çarpýþmayý kontrol et
            {
                SpawnBloodEffect(hit.point, hit.normal);

                if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
                {
                    Debug.Log("Çarpýþma tespit edildi: " + hit.collider.name);
                }

            }

        }
    }

    void SpawnBloodEffect(Vector3 position, Vector3 normal)
    {
        // Kan efektini oluþtur
        GameObject bloodEffect = Instantiate(bloodEffectPrefab, position, Quaternion.LookRotation(normal));

        // Efekti bir süre sonra sahneden kaldýr (örn. 5 saniye)
        //Destroy(bloodEffect, 5f);


    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bloodEffectPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }




}
