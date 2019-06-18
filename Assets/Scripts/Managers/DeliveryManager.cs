using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public Route[] routes;
    public int spawnWaves = 0;
    bool shouldStop;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < routes.Length; i++)
        {
            spawnWaves = routes[i].carCount > spawnWaves ? routes[i].carCount : spawnWaves;
        }
        InvokeRepeating("InitDeliveryCar", 0f, 5f);
    }

    // Update is called once per frame
    void InitDeliveryCar()
    {
        if (!GameManager.Instance.representationManager.buildingsRepresentation.gameObject.activeSelf)
            return;
        if (spawnWaves == 0) CancelInvoke();
        for (int i = 0; i < routes.Length; i++)
        {
            if (routes[i].carCount >= spawnWaves)
            {
                shouldStop = false;
                GameObject car = Instantiate(routes[i].carPrefab, routes[i].wayPoints[0].position, Quaternion.identity);
                car.transform.SetParent(GameManager.Instance.representationManager.buildingsRepresentation.transform);
                car.GetComponent<DeliveryCar>().targets = routes[i].wayPoints;
            }
        }
                spawnWaves--;
    }
}
[System.Serializable]
public class Route
{
    public GameObject carPrefab;
    public int carCount;
    public Transform[] wayPoints;
}
