using UnityEngine;
using System.Collections.Generic;

namespace _Scripts
{
    public class Mover : MonoBehaviour
    {
        public GameObject minime;
        public float speed; // speed of the puurply venomball
        public float dropInterval = 0.5f; // time interval between mini-mes
        private int dropCount = 0; // add drop count to change colour
        private Vector3 direction = new Vector3(0.1f, 0, 0); // initial direction
        private bool isPurple = true; // colour toggle

        private List<GameObject> minimeList = new List<GameObject>(); // balls can't fall all willy nilly 

        // Start is called before the first frame update
        void Start()
        {
            // Rigidbody and SphereCollider
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false; //aint nothin droppin the big ball

            // please for the love of nature drop mini balls 
            InvokeRepeating("DropMiniMe", 0f, dropInterval);
        }

        // Update is called once per frame
        void Update()
        {
            // Move the ball in the current direction
            transform.position += Time.deltaTime * speed * direction;

            // Detect spacebar press to rotate movement by 90 degrees in the same plane
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = Quaternion.Euler(0, 0, 90) * direction;
            }
        }

        // Drop a mini ball and handle its behavior
        void DropMiniMe()
        {
            // Instantiate a new mini ball at the current position of the big ball
            GameObject newMini = Instantiate(minime, transform.position, Quaternion.identity);
            minimeList.Add(newMini); // Add the new mini ball to the list

            // Add Rigidbody to the mini ball
            Rigidbody miniRb = newMini.AddComponent<Rigidbody>();
            miniRb.useGravity = false; // Keep the mini ball stationary for now

            SphereCollider miniCollider = newMini.AddComponent<SphereCollider>();
            miniCollider.isTrigger = false; // Enable physics for the mini ball

            dropCount++;

            // Change color every 5 balls
            Renderer miniRenderer = newMini.GetComponent<Renderer>();
            if (dropCount % 5 == 0)
            {
                isPurple = !isPurple; // Toggle between purple and red every 5 balls
            }

            if (miniRenderer != null)
            {
                miniRenderer.material.color = isPurple ? new Color(0.5f, 0, 0.5f) : Color.red; // Set the ball color
            }

            // Check if there are more than 8 mini balls
            if (minimeList.Count > 8)
            {
                // Get the oldest mini ball (the first in the list)
                GameObject oldestMini = minimeList[0];
                Rigidbody oldestRb = oldestMini.GetComponent<Rigidbody>();

                if (oldestRb != null)
                {
                    // Apply gravity to the oldest mini ball to make it fall
                    oldestRb.useGravity = true;
                }

                // Remove the oldest mini ball from the list and destroy it after a delay
                minimeList.RemoveAt(0);
                Destroy(oldestMini, 2f); // Destroy the mini ball after 2 seconds of falling
            }
        }
    }
}