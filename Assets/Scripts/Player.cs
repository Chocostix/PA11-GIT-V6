using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    private float y = 4f;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if(transform.position.y > 3.99 || transform.position.y < -3.99)
        {
            Bind();
        }

    }

    void Bind()
    {
        pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -y, y);
        transform.position = pos;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
