using UnityEngine;
using System.Collections;


public class CarsController : MonoBehaviour 
{
    [SerializeField] new AutoCam camera;
    [SerializeField] GameObject carsObject;

    CarController[] cars;
    CarController currentCar;
    int currentCarIndex = 0;

    void Awake()
    {
        cars = carsObject.GetComponentsInChildren<CarController>();
        SetTarget();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentCarIndex++;
            if (currentCarIndex >= cars.Length)
            {
                currentCarIndex = 0;
            }

            SetTarget();    
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentCarIndex--;
            if (currentCarIndex <= 0)
            {
                currentCarIndex = cars.Length - 1;
            }

            SetTarget();   
        }
    }
        

    void SetTarget()
    {
        camera.SetTarget(cars[currentCarIndex].transform);
        CarController newCar = cars[currentCarIndex];

        CarAIControl aiControl = newCar.GetComponent<CarAIControl>();
        CarUserControl userControl = newCar.GetComponent<CarUserControl>();

        if (aiControl)
        {
            aiControl.enabled = false;
        }

        if (userControl)
        {
            userControl.enabled = true;
        }

        if (currentCar)
        {
            aiControl = currentCar.GetComponent<CarAIControl>();
            userControl = currentCar.GetComponent<CarUserControl>();

            if (aiControl)
            {
                aiControl.enabled = true;
            }

            if (userControl)
            {
                userControl.enabled = false;
            }
        }

        currentCar = newCar;
    }
}
