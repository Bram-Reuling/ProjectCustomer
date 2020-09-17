using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectCustomer.Other
{

public class BirdAnimScript : MonoBehaviour
{

        public int speed=5,min =300,max=150;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            this.transform.Translate(Vector3.up * speed * Time.deltaTime, this.transform);

            if(this.transform.position.z < max)
            {
                this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,min);
            }

    }

}

}
