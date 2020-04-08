using UnityEngine;

public class RotateBall : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 15f, 0f) * Time.deltaTime);        
    }
}
