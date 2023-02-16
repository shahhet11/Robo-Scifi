﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    public int currentActive;
    public static bool isIndicatorOn;

    [Header("[Powers]")]
    public GameObject LaserSwords;

    [Header("[Tripe Bombs]")]
    public GameObject bombPrefab;
    public GameObject bombGroundEffect;
    public GameObject bombIndicators;
    public Transform[] bombPositions;
    public float bombSpawnHeight;
    public float bombDropDelay;


    void Start()
    {

    }


    void Update()
    {
        //DroppingBombAbility();
        LaserBlades();
    }

    void DroppingBombAbility()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bombIndicators.SetActive(true);

            isIndicatorOn = true;
            currentActive = 0;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            LaserSwords.SetActive(true);
        }

        if (isIndicatorOn == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                CheckAndShoot(currentActive);
            }
        }
    }

    void LaserBlades()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LaserSwords.SetActive(true);
        }
    }

    public void CheckAndShoot(int id)
    {
        if (id == 0)
        {
            Power_BombDrop();
        }

        isIndicatorOn = false;
    }

    private void Power_BombDrop()
    {
        bombIndicators.SetActive(false);

        StartCoroutine(DropBombs());
    }

    private IEnumerator DropBombs()
    {
        Vector3[] storePosition = new Vector3[bombPositions.Length];

        for (int i = 0; i < bombPositions.Length; i++)
        {
            storePosition[i] = bombPositions[i].position;
        }

        for (int i = 0; i < bombPositions.Length; i++)
        {
            Instantiate(bombPrefab, new Vector3
                (
                storePosition[i].x,
                bombSpawnHeight,
                storePosition[i].z), bombPrefab.transform.rotation);

            yield return new WaitForSeconds(bombDropDelay);
        }
    }
}
