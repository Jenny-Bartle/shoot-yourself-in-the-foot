using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class BulletInteract : MonoBehaviour
    {
        [SerializeField]
        public GameObject bulletPrefab;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Camera cam = Camera.main;
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, cam.transform.position, cam.transform.rotation);
                Rigidbody rigidBody = bullet.GetComponent<Rigidbody>();
                rigidBody.AddForce(cam.transform.forward * 40, ForceMode.Impulse);
            }
        }
    }
}
