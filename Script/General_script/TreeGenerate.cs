using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TreeGenerate : MonoBehaviour
{
    public GameObject treePrefab1; // Assign the tree prefab in the Inspector
    public int numberOfTrees1 = 10; // Number of trees to generate
    public float areaRadius1 = 10f; // The radius within which trees will be generated
    public Vector3 TargetCenterpoint1 = new Vector3(55.0f, 1.0f, 77.0f);
    public Vector3 HolePoint1 = new Vector3(55.0f, 1.0f, 77.0f);
    public float HoleRadius1 = 10f;

    public GameObject treePrefab2; // Assign the tree prefab in the Inspector
    public int numberOfTrees2 = 10; // Number of trees to generate
    public float areaRadius2 = 10f; // The radius within which trees will be generated
    public Vector3 TargetCenterpoint2 = new Vector3(55.0f, 1.0f, 77.0f);
    public Vector3 HolePoint2 = new Vector3(55.0f, 1.0f, 77.0f);
    public float HoleRadius2 = 10f;


    public GameObject WoftPrefab; // Assign the tree prefab in the Inspector
    public int numberOfWoft = 10; // Number of trees to generate
    public float areaRadius3 = 10f; // The radius within which trees will be generated
    public Vector3 TargetCenterpoint3 = new Vector3(55.0f, 1.0f, 77.0f);
    public Vector3 HolePoint3 = new Vector3(55.0f, 1.0f, 77.0f);
    public float HoleRadius3 = 10f;

    private Terrain terrain; // Reference to the terrain
    List<string> ListTag = new List<string>() { "Tree", "CaveTroll", "Woft" };

    private void Start()
    {
        terrain = Terrain.activeTerrain;
        Debug.Log(terrain.tag);
        GenerateTrees1();
        GenerateTrees2();
        GenerateWofts();
    }

    private void GenerateTrees1()
    {
        for (int i = 0; i < numberOfTrees1; i++)
        {
            // Generate random positions within the areaRadius
            Vector3 randomPosition = Random.insideUnitSphere * areaRadius1;
            randomPosition.y = 0f; // Start at ground level
            randomPosition += TargetCenterpoint1;

            float CheckInHole = Vector3.Distance(randomPosition, HolePoint1);
            if (CheckInHole < HoleRadius1)
            {
                Vector3 offset = Vector3.Normalize(randomPosition - HolePoint1) * HoleRadius1;
                randomPosition += offset;
            }


            // Cast a ray from above the terrain to find the highest point on the terrain
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(randomPosition.x, 100f, randomPosition.z), Vector3.down, out hit, Mathf.Infinity))
            {
                // Position the tree at the hit point (on top of the terrain)
                //if (hit.collider.gameObject != treePrefab2 | hit.collider.gameObject != treePrefab1)
                //if (hit.collider.gameObject.tag != "Tree")
                if (!ListTag.Contains(hit.collider.gameObject.tag))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
                    randomPosition = hit.point;
                }
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
                //randomPosition = hit.point;
            }
            else
            {
                // If raycast fails, fall back to terrain height (use a small offset if needed)
                randomPosition.y = terrain.SampleHeight(randomPosition) + 0.1f;
            }

            // Instantiate the tree prefab at the random position with no rotation
            GameObject treeInstance = Instantiate(treePrefab1, randomPosition, Quaternion.identity);

            // Parent the tree instance to the GameObject this script is attached to
            treeInstance.transform.SetParent(transform);
        }
    }
    private void GenerateTrees2()
    {
        for (int i = 0; i < numberOfTrees2; i++)
        {
            // Generate random positions within the areaRadius
            Vector3 randomPosition = Random.insideUnitSphere * areaRadius2;
            randomPosition.y = 0f; // Start at ground level
            randomPosition += TargetCenterpoint2;

            float CheckInHole = Vector3.Distance(randomPosition, HolePoint2);
            if (CheckInHole < HoleRadius2)
            {
                Vector3 offset = Vector3.Normalize(randomPosition - HolePoint2) * HoleRadius2;
                randomPosition += offset;
            }
            randomPosition.y = 0f; // Start at ground level


            // Cast a ray from above the terrain to find the highest point on the terrain
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(randomPosition.x, 100f, randomPosition.z), Vector3.down, out hit, Mathf.Infinity))
            {
                // Position the tree at the hit point (on top of the terrain)
                //if (hit.collider.gameObject != treePrefab2 | hit.collider.gameObject != treePrefab1)
                //if (hit.collider.gameObject.tag != "Tree")
                if (!ListTag.Contains(hit.collider.gameObject.tag))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
                    randomPosition = hit.point;
                }
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
                //randomPosition = hit.point;
            }
            else
            {
                // If raycast fails, fall back to terrain height (use a small offset if needed)
                randomPosition.y = terrain.SampleHeight(randomPosition) + 0.1f;
            }

            // Instantiate the tree prefab at the random position with no rotation
            GameObject treeInstance = Instantiate(treePrefab2, randomPosition, Quaternion.identity);

            // Parent the tree instance to the GameObject this script is attached to
            treeInstance.transform.SetParent(transform);
        }
    }
    private void GenerateWofts()
    {
        for (int i = 0; i < numberOfWoft; i++)
        {
            // Generate random positions within the areaRadius
            Vector3 randomPosition = Random.insideUnitSphere * areaRadius3;
            randomPosition.y = 0f; // Start at ground level
            randomPosition += TargetCenterpoint3;

            float CheckInHole = Vector3.Distance(randomPosition, HolePoint3);
            if (CheckInHole < HoleRadius3)
            {
                Vector3 offset = Vector3.Normalize(randomPosition - HolePoint3) * HoleRadius3;
                randomPosition += offset;
            }
            randomPosition.y = 0f; // Start at ground level


            // Cast a ray from above the terrain to find the highest point on the terrain
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(randomPosition.x, 100f, randomPosition.z), Vector3.down, out hit, Mathf.Infinity))
            {
                // Position the tree at the hit point (on top of the terrain)
                //if (hit.collider.gameObject != treePrefab2 | hit.collider.gameObject != treePrefab1)
                if (hit.collider.gameObject.tag != "Tree")
                {
                    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
                    randomPosition = hit.point;
                }
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
                //randomPosition = hit.point;
            }
            else
            {
                // If raycast fails, fall back to terrain height (use a small offset if needed)
                randomPosition.y = terrain.SampleHeight(randomPosition) + 0.1f;
            }

            // Instantiate the tree prefab at the random position with no rotation
            GameObject treeInstance = Instantiate(WoftPrefab, randomPosition, Quaternion.identity);


            // Parent the tree instance to the GameObject this script is attached to
            treeInstance.transform.SetParent(transform);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(TargetCenterpoint1, HoleRadius1);
    }

}