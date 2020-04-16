using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrayindex : MonoBehaviour
{
	public AudioSource[] fuentesarray;
    public GameObject[] objetosArray;
    Vector3 posicion, diferencia;
    // Start is called before the first frame update
    void Start()
    {
        fuentesarray[0] = objetosArray[0].GetComponent<AudioSource>();
        posicion = objetosArray[0].transform.position;
        print(posicion);
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.position);
        diferencia = new Vector3(posicion.x - transform.position.x, posicion.y - transform.position.y, posicion.z - transform.position.z);
        print(diferencia);
    }
}
