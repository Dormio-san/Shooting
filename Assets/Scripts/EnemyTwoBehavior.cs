using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoBehavior : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, -1, 0) * Time.deltaTime * 1);
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x > 9.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            whatIHit.GetComponent<PlayerBehavior>().LoseLife();
            Destroy(this.gameObject);
        }
        else if (whatIHit.tag == "Bullet")
        {
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}