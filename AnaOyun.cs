using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaOyun : MonoBehaviour
{
    public Material mat_normal;
    public Material mat_secili;

    private GameObject mevcut_secili;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f,LayerMask.GetMask("Birim","Bina")))
            {
                if(mevcut_secili != null)
                {
                    MeshRenderer mr_eski = mevcut_secili.GetComponent<MeshRenderer>();
                    if (mr_eski != null)
                    {
                        mr_eski.material = mat_normal;
                    }
                }

                mevcut_secili = hit.transform.gameObject;
                MeshRenderer mr = mevcut_secili.GetComponent<MeshRenderer>();
                if(mr != null)
                {
                    mr.material = mat_secili;
                }
             
            }
            else
            {
                if (mevcut_secili != null)
                {
                    MeshRenderer mr_eski = mevcut_secili.GetComponent<MeshRenderer>();
                    if (mr_eski != null)
                    {
                        mr_eski.material = mat_normal;
                    }
                    mevcut_secili = null;
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if(mevcut_secili != null)
            {
                LayerMask lm = LayerMask.GetMask("Birim");

                if (lm == (lm | (1 << mevcut_secili.layer)))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Zemin")))
                    {
                        Birim b = mevcut_secili.GetComponentInParent<Birim>();
                        if (b != null)
                        {
                            b.Yuru(hit.point);
                        }
                    }
                }

                lm = LayerMask.GetMask("Bina");

                if (lm == (lm | (1 << mevcut_secili.layer)))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Zemin")))
                    {
                        Bina b = mevcut_secili.GetComponentInParent<Bina>();
                        if (b != null)
                        {
                            b.VarisSec(hit.point);
                        }
                    }
                }
            }
        }
        
    }
}
