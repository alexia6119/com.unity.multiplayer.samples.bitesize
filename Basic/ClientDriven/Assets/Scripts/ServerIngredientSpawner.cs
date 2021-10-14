using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Samples;
using UnityEngine;
using Random = System.Random;

public class ServerIngredientSpawner : ClientServerNetworkBehaviour
{
    [SerializeField]
    private List<GameObject> m_SpawnPoints;

    [SerializeField]
    private float m_SpawnRatePerSecond;

    [SerializeField]
    private GameObject m_IngredientPrefab;

    private float m_LastSpawnTime;
    private Random r = new Random();

    private void FixedUpdate()
    {
        if (NetworkManager != null && !IsServer) return;
        if (Time.time - m_LastSpawnTime > m_SpawnRatePerSecond)
        {
            foreach (var spawnPoint in m_SpawnPoints)
            {
                var newIngredientObject = Instantiate(m_IngredientPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                newIngredientObject.transform.position = spawnPoint.transform.position;
                var ingredient = newIngredientObject.GetComponent<ServerIngredient>();
                ingredient.CurrentIngredientType.Value = (IngredientType) r.Next((int)IngredientType.max);
                ingredient.NetworkObject.Spawn();
            }

            m_LastSpawnTime = Time.time;
        }

    }
}
