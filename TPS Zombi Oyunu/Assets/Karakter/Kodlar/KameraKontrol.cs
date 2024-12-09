using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public Transform hedef;
    public Vector3 hedefMesafe;
    [SerializeField]
    private float fareHassasiyeti;
    float fareX, fareY;

    //Vector3 objRot;
    //public Transform karakterVucut;

    KarakterKontrol karakterHP;
    void Start()
    {
        karakterHP = GameObject.Find("Swat (1) 1").GetComponent<KarakterKontrol>();
        Cursor.lockState = CursorLockMode.Locked;

        //Vector3 gecici = this.transform.localEulerAngles;
        //gecici = this.transform.localEulerAngles;
        //gecici.z = 0;
        //gecici.y = 0;
        //gecici.x = this.transform.localEulerAngles.x + 10;
        //objRot = gecici;
        //karakterVucut.transform.eulerAngles = objRot;
    }

    void Update()
    {
        
    }


    private void LateUpdate()
    {
        if (karakterHP.YasiyorMu() == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
            fareX += Input.GetAxis("Mouse X") * fareHassasiyeti;
            fareY += Input.GetAxis("Mouse Y") * fareHassasiyeti;
            if (fareY >= 25)
            {
                fareY = 25;
            }
            if (fareY <= -40)
            {
                fareY = -40;
            }

            this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
            hedef.transform.eulerAngles = new Vector3(0, fareX, 0);

            //Vector3 gecici = this.transform.eulerAngles;
            //gecici = this.transform.eulerAngles;
            //gecici.z = 0;
            //gecici.y = this.transform.localEulerAngles.y;
            //gecici.x = this.transform.localEulerAngles.x + 10;
            //objRot = gecici;
            //karakterVucut.transform.eulerAngles = objRot;
        }
        //this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
        //fareX += Input.GetAxis("Mouse X") * fareHassasiyeti;
        //fareY += Input.GetAxis("Mouse Y") * fareHassasiyeti;
        //if (fareY >= 25)
        //{
        //    fareY = 25;
        //}
        //if (fareY <= -40)
        //{
        //    fareY = -40;
        //}

        //this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
        //hedef.transform.eulerAngles = new Vector3(0, fareX, 0);

        //Vector3 gecici = this.transform.eulerAngles;
        //gecici = this.transform.eulerAngles;
        //gecici.z = 0;
        //gecici.y = this.transform.localEulerAngles.y;
        //gecici.x = this.transform.localEulerAngles.x + 10;
        //objRot = gecici;
        //karakterVucut.transform.eulerAngles = objRot;



    }
}
