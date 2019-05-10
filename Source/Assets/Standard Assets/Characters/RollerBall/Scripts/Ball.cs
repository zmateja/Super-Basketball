using System;
using UnityEngine;


namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
        public AudioSource JumpSFX;
        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.
        private bool canJump;
        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;


        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }


        public void Move(Vector3 moveDirection, bool jump)
        {
            if (Ballstuff.canMove)
            {
                // If using torque to rotate the ball...
                if (canJump)
                {
                    // ... add torque around the axis defined by the move direction.
                    m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * m_MovePower);
                }
                else
                {
                    // Otherwise add force in the move direction.
                    m_Rigidbody.AddForce(moveDirection * m_MovePower / 4);
                }

                // If on the ground and jump is pressed...
                if (jump && canJump)
                {
                    // ... add force in upwards.
                    m_Rigidbody.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
                    JumpSFX.Play();
                }
            }
            else
                m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.name == "LevelTerrain")
                canJump = true;
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.name == "LevelTerrain")
                canJump = false;
        }
    }
}

