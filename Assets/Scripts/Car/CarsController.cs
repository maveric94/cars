using UnityEngine;
using System.Collections;


public class CarsController : MonoBehaviour 
{
    [SerializeField] new AutoCam camera;
    [SerializeField] CarController playerCar;
    [SerializeField] GameObject carsObject;

    CarController[] cars;
    int currentCarIndex = 0;

    void Awake()
    {
        cars = carsObject.GetComponentsInChildren<CarController>();
        camera.SetTarget(playerCar.transform);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(0.0f, 0.0f, 200.0f, 200.0f), "Player car"))
        {
            camera.SetTarget(playerCar.transform);
        }

        if (GUI.Button(new Rect(200.0f, 0.0f, 200.0f, 200.0f), "Next car"))
        {
            camera.SetTarget(cars[currentCarIndex++].transform);
            if (currentCarIndex >= cars.Length)
            {
                currentCarIndex = 0;
            }
        }

        if (GUI.Button(new Rect(400.0f, 0.0f, 200.0f, 200.0f), "Prev car"))
        {
            camera.SetTarget(cars[currentCarIndex--].transform);
            if (currentCarIndex <= 0)
            {
                currentCarIndex = cars.Length - 1;
            }
        }
    }
}
