using UnityEngine;


public class Saw : MonoBehaviour
{
    [SerializeField] private float rotatSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, rotatSpeed * Time.deltaTime);
    }
}
