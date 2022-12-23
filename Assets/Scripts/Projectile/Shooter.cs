using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public AudioClip fireClip;
    public GameObject projectilePrefab;
    public string inputName;

    private void Start()
    {
        if (inputName == "")
        {
            StartCoroutine(WaitAndShoot());
        }
    }

    private void Update()
    {
        if (inputName != "" && Input.GetButtonDown(inputName))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var position = transform.position;

        Instantiate(projectilePrefab, position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(fireClip, position);
    }

    private IEnumerator WaitAndShoot()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(3f, 9f));
            Shoot();
        }
    }
}
