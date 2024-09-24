using UnityEngine;

namespace _Scripts
{
    public class Mover : MonoBehaviour
    {
        public GameObject minime;
        public Vector3 targetPosition;
        public float speed;

        // Start is called before the first frame update
        void Start()
        {
          targetPosition = new Vector3(x:0, y:0, z:0);
        }

        // Update is called once per frame
        void Update()
        {
         
            targetPosition = targetPosition + Time.deltaTime * speed * new Vector3(x:0.1f, y: 0, z: 0);
            this.gameObject.transform.position = targetPosition; 
            Instantiate(minime, targetPosition, Quaternion.identity);
            
            
        }
    }

}
            
