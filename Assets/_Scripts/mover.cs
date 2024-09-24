using UnityEngine;

namespace _Scripts
{
    public class Mover : MonoBehaviour
    {
        public GameObject minime;
        public float speed; // speed of the puurply venomball
        public float dropInterval = 0.5f; // time interval between mini-mes

        // Start is called before the first frame update
        void Start()
        {
            // please for the love of nature drop mini balls 
          InvokeRepeating("DropMiniMe", 0f, dropInterval);
        }

        // Update is called once per frame
        void Update()
        {

            transform.position += Time.deltaTime * speed * new Vector3(x: 0.1f, y: 0, z: 0);
        }

        void DropMiniMe()
        {
            Instantiate(minime, transform.position, Quaternion.identity); //New mini ball at each current position
        }
    }

}
            
