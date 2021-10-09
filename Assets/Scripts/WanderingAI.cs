using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3f;
    public float obstacleRange = 5f;

    private bool isAlive;

    private void Start()
    {
        isAlive = true;
    }

    private void Update()
    {
        if (!isAlive) return;
        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.SphereCast(ray, .75f, out hit))
        {
            if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetAlive(bool alive) => isAlive = alive;
}