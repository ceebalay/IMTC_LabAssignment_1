using UnityEngine;

namespace _Scripts
{
    public class Mover : MonoBehaviour
    {
        public Vector3 targetPosition;

        // Start is called before the first frame update
        void Start()
        {
          targetPosition = new Vector3(x:0, y:0, z:0);
        }

        // Update is called once per frame
        void Update()
        {
         
            targetPosition = targetPosition + Time.deltaTime * new Vector3(x: 1, y: 0, z: 0);
            this.gameObject.transform.position = targetPosition; 
            
            
        }
    }

}
            
