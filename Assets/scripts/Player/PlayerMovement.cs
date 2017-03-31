using UnityEngine;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        Vector3 movement;
        Rigidbody playerRigidbody;

        void Awake ()
        {
            playerRigidbody = GetComponent <Rigidbody> ();
        }


        void Update ()
        {
            if (GameManager.alive)
            {
                Move();
                Turning();
            }
        }

        void Move ()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            movement.Set (h, 0f, v);
            movement = movement.normalized * speed * Time.deltaTime;
            playerRigidbody.MovePosition (transform.position + movement);
        }


        void Turning()
        {
            var h = Input.GetAxis("RightHorizontal");
            var v = Input.GetAxis("RightVertical");

            float heading = Mathf.Atan2(h, v);

            if (h != 0 && v != 0)
                transform.rotation = Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f);
        }
    }
}