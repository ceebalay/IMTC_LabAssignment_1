using UnityEngine;

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

        // Start is called before the first frame update
        void Start()
        {
            // please for the love of nature drop mini balls 
            InvokeRepeating("DropMiniMe", 0f, dropInterval);
        }

        // Update is called once per frame
        void Update()
        {
            // Move the ball in the current direction
            transform.position += Time.deltaTime * speed * direction;

            // Detect spacebar press to rotate movement by 90 degrees
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = Quaternion.Euler(0, 0, 90) * direction;
            }
        }
       
        void DropMiniMe()
        {

            GameObject newMini = Instantiate(minime, transform.position, Quaternion.identity); // New mini ball at each current position
            dropCount++;

            Renderer miniRenderer = newMini.GetComponent<Renderer>();
            if (miniRenderer != null)
            {
                // Switch between purple and red every 5 mini balls
                if (dropCount % 5 == 0)
                {
                    isPurple = !isPurple; // Toggle between purple and red
                }

                if (isPurple)
                {
                    miniRenderer.material.color = new Color(0.5f, 0, 0.5f); // Purple color
                }
                else
                {
                    miniRenderer.material.color = Color.red; // Red color
                }
            }
        }
    }
}

            
