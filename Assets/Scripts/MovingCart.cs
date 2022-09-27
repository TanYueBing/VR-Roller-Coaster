using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingCart : MonoBehaviour
{
    public GameObject[] forwardWayPoints, backwardWayPoints;
    private GameObject[] wayPoints;
    public GameObject rightController;
    private int index = 0;
    public bool reverse = false;
    private float speed;
    public float movingSpeed = 30;
    private bool move = false;
    public AudioSource rollerCoasterSound;
    public GameObject mainMenu;
    public ObjectShake objectShake;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(move)
        {
            Direction(reverse);
            if (index < wayPoints.Length)
            {
                var angle = transform.rotation.x;

                if (angle >= 10)
                {
                    speed = movingSpeed*4;
                    StartCoroutine(objectShake.Shake(.3f, .5f));

                }
                else if (angle < 10 && angle >= -5)
                {
                    speed = movingSpeed;
                    StartCoroutine(objectShake.Shake(.3f, .02f));
                }
                else if (angle < -5)
                {
                    speed = movingSpeed/2;
                    StartCoroutine(objectShake.Shake(.3f, .005f));
                }

                var distance = Vector3.Distance(transform.position, wayPoints[index].transform.position);

                if (distance < 0.5f && index < wayPoints.Length)
                {
                    index++;
                }

                float step = speed * Time.deltaTime;
                if(index < wayPoints.Length)
                {
                    var targetRotation = Quaternion.LookRotation(wayPoints[index].transform.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
                    transform.position = Vector3.MoveTowards(transform.position, wayPoints[index].transform.position, step);
                }
            }
            else
            {
                move = false;
                rollerCoasterSound.Stop();
                Invoke("restoreMenu", 0.3f);
            }
        }
    }  

    public void startMove()
    {
        move = true;
        rollerCoasterSound.Play();
        index = 0;
        mainMenu.SetActive(false);
        rightController.SetActive(false);
        speed = movingSpeed;
    }

    public void Direction(bool reverse)
    {
        if(reverse == false)
        {
            wayPoints = forwardWayPoints;
        }
        else
        {
            wayPoints = backwardWayPoints;
        }
    }

    public void restoreMenu()
    {
        mainMenu.SetActive(true);
        rightController.SetActive(true);
    }
}
