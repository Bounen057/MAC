 using Photon.Pun;
using UnityEngine;

public class PlayerControl : MonoBehaviourPunCallbacks
{
    public float sensitivit = 3f;

    private GameObject cam;
    private Rigidbody rb;
    private float speed = 30f;
    private Vector3 initial_position;


    private void Start()
    {
         if (photonView.IsMine)
        {
            rb = this.gameObject.GetComponent<Rigidbody>();

            cam = GameObject.Find("MainCamera");
            initial_position = cam.transform.position;

            cam.transform.position = this.gameObject.transform.position + initial_position;
            cam.transform.rotation = this.gameObject.transform.rotation; 
            cam.transform.parent = this.gameObject.transform;
        }
    }

    void Update()
    {
        // ローカルプレイヤーの時
        if (photonView.IsMine) {
            // X rotate
            float x_mouse = Input.GetAxis("Mouse X");
            Vector3 newRotation = transform.localEulerAngles;
        	    newRotation.y += x_mouse * sensitivit;
            transform.localEulerAngles = newRotation;

            // Y rotate
            float y_mouse = Input.GetAxis("Mouse Y");
            Vector3 newRotation_cam = cam.transform.localEulerAngles;
            newRotation_cam.x -= y_mouse * sensitivit;
            if (200 > newRotation_cam.x && newRotation_cam.x > 90) newRotation_cam.x = 90;
            if (200 <= newRotation_cam.x && newRotation_cam.x < 270) newRotation_cam.x = 270;
            cam.transform.localEulerAngles = newRotation_cam;

            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(new Vector3(0, 500f, 0)); //上に向かって力を加える
            }

            click();
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            move();
        }
    }

    private void move()
    {
        if (rb.velocity.magnitude < 10)
        {
            float currentSpeed = speed - rb.velocity.magnitude;

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(this.gameObject.transform.forward * speed * 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(this.gameObject.transform.forward * speed * -1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(this.gameObject.transform.right * speed * 1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(this.gameObject.transform.right * speed * -1);
            }
        }
    }

    private void click()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(1))
            {
                var ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    string objectName = hit.collider.gameObject.name;
                    Debug.Log("左クリック:" + objectName);
                }
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 5, true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            GameObject obj = other.gameObject;
            if (obj.GetComponent<DroppedItem>() != null)
            {
                obj.GetComponent<DroppedItem>().Pick(PhotonNetwork.LocalPlayer.ActorNumber);
            }
        }
    }
} 