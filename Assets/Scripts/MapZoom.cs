using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Maps.Unity;
using Microsoft.Geospatial;


public class MapZoom : MonoBehaviour
{
    [SerializeField] private GameObject MRO;
    [SerializeField] private MapRenderer map;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        //52.04460121973492, 4.250174259776212 (TIH)
        MRO = GameObject.Find("MapRenderer");
        map = MRO.GetComponent<MapRenderer>();
        map.ZoomLevel = 14f;

    }
    public float zoomSpeed = 1f; // Adjust the speed of zooming
    public float minZoomDistance = 1f; // Set the minimum zoom distance
    public float maxZoomDistance = 10f; // Set the maximum zoom distance

    private void Update()
    {
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;

        // Apply zooming
        float currentZoomDistance = Vector3.Distance(transform.position, Vector3.zero);
        float newZoomDistance = currentZoomDistance - zoomAmount;
        newZoomDistance = Mathf.Clamp(newZoomDistance, minZoomDistance, maxZoomDistance);

        Vector3 zoomDirection = transform.position.normalized;
        Vector3 zoomPosition = zoomDirection * newZoomDistance;

       // transform.position = zoomPosition;
    }
}