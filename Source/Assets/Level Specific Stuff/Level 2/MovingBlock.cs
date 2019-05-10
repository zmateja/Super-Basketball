using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Rigidbody block;
    [SerializeField] private float blockSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        block = GetComponent<Rigidbody>();
        block.AddForce(new Vector3(0, 0, -1*blockSpeed), ForceMode.VelocityChange);

        Invoke("UpMotion", 16/blockSpeed);
    }

    private void DownMotion()
    {
        block.AddForce(new Vector3(0, 0, -2*blockSpeed), ForceMode.VelocityChange);
        Invoke("UpMotion", 16/blockSpeed);
        
    }
    private void UpMotion()
    {
       
        int curSpeed = (int)block.velocity.z;
        if (curSpeed == 0)
        {
            block.AddForce(new Vector3(0, 0, blockSpeed), ForceMode.VelocityChange);
        }
        else
            block.AddForce(new Vector3(0, 0, 2*blockSpeed), ForceMode.VelocityChange);

        Invoke("DownMotion", 16/blockSpeed);
        
    }
}
