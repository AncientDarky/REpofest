using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
      Camera mainCam;
    Vector3 mainCamPos;
    [SerializeField] float Power = 5;
    
     [SerializeField] public int Ballnumber;// How many ball a player has
    Vector3 MousePos;
    GameObject Ball;
    Rigidbody RigiBall;
    Ray ray;
   

    // Start is called before the first frame update
    void Start()
    {
        
        
        mainCam = Camera.main;
        mainCamPos = mainCam.GetComponent<Transform>().position;
        Ball = GameObject.Find("Ballobject");
        RigiBall = Ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AiminSystem();
        
    }
    

    private void AiminSystem()
    {
        RaycastHit PointofHit;
        MousePos = Input.mousePosition;
        Ray ray = mainCam.ScreenPointToRay(MousePos);
        Vector3 rayDirection = ray.direction;
        if (Physics.Raycast(mainCamPos, rayDirection, out PointofHit))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                var instant = Instantiate(Ball);
                instant.transform.position = mainCamPos;
                instant.GetComponent<Rigidbody>().AddForce(PointofHit.point.x * Power, PointofHit.point.y * Power, 10 * Power);

            }
            print("Found an object - distance: " + PointofHit.distance);

        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }

    private static void MenuLeiste()
    {
        if (Input.GetKeyDown(KeyCode.M))//shows Pause menu
        {
            print("Pause Menu appears");
        }
        if (Input.GetKeyDown(KeyCode.Escape))//shows Pause menu
        {
            print("Pause Menu appears ESC");
        }
        if (Input.GetKeyDown(KeyCode.N))//shows Mode menu
        {
            print("Mode menu appears");
        }
    }

    private void  Ballcalculator()
    {
        //calculates if player has throw a ball or if he has ball left
    }
}
