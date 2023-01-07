using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject diamondPrefab;
    [SerializeField] private GameObject referancePlatform;

    public PieceManager pM;

    private GameObject lastPlatform;
    private Vector3 spawnPos;
    private int xCounter = 0;
    private int zCounter = 0;

    private void Start()
    {
        spawnPos = referancePlatform.transform.position + new Vector3(0, 0, 1f);
            for (int i = 0; i < 60; i++)
                SpawnPlatform();
        
            InvokeRepeating(nameof(SpawnPlatform),0.1f,0.5f);
    }

    void SpawnPlatform()
    {
        int rnd = Random.Range(0, 6);
        if (rnd < 3)
        {
            SpawnX();
            if (xCounter >= 4)
            {
                SpawnZ();
                SpawnZ();
                SpawnZ();
                xCounter = 0;
            }
        }
        else if (rnd >= 3)
        {
            SpawnZ();
            if (zCounter >= 4)
            {
                SpawnX();
                SpawnX();
                SpawnX();
                zCounter = 0;
            }
        }

        if (pM.isLBounded == true)
        {
            SpawnX();
            SpawnX();
        }

        if (pM.isRBounded == true)
        {
            SpawnZ();
            SpawnZ();
        }
    }

    void SpawnX()
    {
        lastPlatform = Instantiate(platformPrefab, spawnPos, quaternion.identity);
        spawnPos = lastPlatform.transform.position + new Vector3(1, 0, 0);
        xCounter++;
        SpawnDiamond();
    }
    
    void SpawnZ()
    {
        lastPlatform = Instantiate(platformPrefab, spawnPos, quaternion.identity);
        spawnPos = lastPlatform.transform.position + new Vector3(0, 0, 1);
        zCounter++;
        SpawnDiamond();
    }

    void SpawnDiamond()
    {
        int rnd = Random.Range(0, 5);
        if (rnd < 1)
            Instantiate(diamondPrefab, spawnPos + new Vector3(0,1f,0), quaternion.identity);
    }
}
