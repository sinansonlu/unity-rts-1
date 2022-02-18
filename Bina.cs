using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina : MonoBehaviour
{
    public GameObject uretilen_birim;
    public GameObject cikis_noktasi;
    public GameObject varis_noktasi;

    float zaman;

    // Start is called before the first frame update
    void Start()
    {
        zaman = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        zaman -= Time.deltaTime;
        if(zaman <= 0)
        {
            GameObject yeniBirim = Instantiate(uretilen_birim, cikis_noktasi.transform.position, Quaternion.identity);
            Birim b = yeniBirim.GetComponent<Birim>();
            b.AgentBelirle();
            b.Yuru(varis_noktasi.transform.position);
            zaman = 1f;
        }

    }

    public void VarisSec(Vector3 konum)
    {
        varis_noktasi.transform.SetPositionAndRotation(konum, Quaternion.identity);
    }
}
