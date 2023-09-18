using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;

    public int value = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavpointIndex = 0;

    void Start()
    {
        target = Waypoint.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += value;
        
        GameObject effect = (GameObject)Instantiate(deathEffect , transform.position, Quaternion.identity);
        Destroy(effect ,5f);
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime ,Space.World);

        if (Vector3.Distance(transform.position ,target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavpointIndex >= Waypoint.points.Length -1)
        {
            EndPath();
            return;
        }
        wavpointIndex++;
        target = Waypoint.points[wavpointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
        PlayerStats.Lives--;
    }
}
