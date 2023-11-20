using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    private GameObject plyr;
    // Start is called before the first frame update
    void Start()
    {
        plyr = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, -2, 0) * Time.deltaTime * 1);
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x < -9.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D whatIHit)
    {    
        if(whatIHit.tag == "Player")
        {
            plyr.GetComponent<PlayerBehavior>().ActivateShield();
            Destroy(this.gameObject);
        }
    }
}