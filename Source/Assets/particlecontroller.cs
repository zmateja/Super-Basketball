using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlecontroller : MonoBehaviour
{
    public AudioSource TNTsfx;
    [SerializeField]private float power = 10.0f;
    [SerializeField]private float radius = 5.0f;
    [SerializeField]private float upForce = 50.0f;
    [SerializeField]private ParticleSystem explode;
   
    // Start is called before the first frame update
    void Start()
    {
        explode.Stop();
        //ParticleSystem.EmissionModule em = explode.emission;
    //    var em = explode.emission;
    //    em = false;
    // ParticleSystem.EmissionModule em = explode.GetComponent <ParticleSystem> ().emission;
    //  em.enabled = false;
    }
void OnCollisionEnter(Collision c){
       // ParticleSystem.EmissionModule em = explode.emission;
    //    ParticleSystem.EmissionModule em = explode.GetComponent <ParticleSystem> ().emission; 
    //    em.enabled = true;
    explode.Play();
    TNTsfx.Play();
    //c.transform.position = new Vector3(Random.Range(-6,-8), Random.Range(-3,6),0);
    Detonate(gameObject);
    Debug.Log(c.transform.position-gameObject.transform.position);
    Destroy(gameObject);
     
       // var em = explode.emission;
      // em = true;
        //  StartCoroutine (stopExplosion());
    }
    void Detonate(GameObject c){
        Vector3 explosionPosition = c.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition,radius);
        foreach(Collider hit in colliders){
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb!=null)
            rb.AddExplosionForce(power,explosionPosition,radius,upForce,ForceMode.Impulse);
        }
    }
}
