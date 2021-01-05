using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float angularV = 45;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(angularV * Time.deltaTime, 0, 0);
    }
}
