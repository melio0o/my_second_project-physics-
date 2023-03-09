using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_player : MonoBehaviour
{
    [SerializeField] private float mainThrust;
    [SerializeField] private float rotationThrust;
    private Rigidbody rb;
    private AudioSource Audiosource;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetButton("Jump"))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward * rotationThrust * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            ResetPlayerPosition();
            StartCoroutine(SetDefaultRBValues());
        }
    }

    private void ResetPlayerPosition()
    {
        rb.freezeRotation = true;
        rb.drag = 1000;
        transform.position = new Vector3(39.5f, 2.9f);
        transform.rotation = Quaternion.identity;
    }

    private IEnumerator SetDefaultRBValues()
    {
        yield return new WaitForSeconds(0.5f);
        print("working");
        rb.freezeRotation = false;
        rb.drag = 0;

    }


}
