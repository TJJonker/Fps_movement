using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3f;
    public float obstacleRange = 5f;

    private bool isAlive;

    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

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
            GameObject hitObject = hit.transform.gameObject;
            // If sees the player, fire fireball
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (!fireball)
                {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }
            // If sees the wall, turn away
            else if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetAlive(bool alive) => isAlive = alive;
}