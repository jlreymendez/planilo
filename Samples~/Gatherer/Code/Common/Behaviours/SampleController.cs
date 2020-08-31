using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlaniloSamples.Common
{
    public class SampleController : MonoBehaviour
    {
        public GameObject homePrefab;
        public Resource resourcePrefab;
        public GameObject agentPrefab;

        public int agentsCount;
        public int maxResourceCount;
        public float resourceProductionRate = 0.8f;

        List<Resource> resources;
        List<Resource> recycledResources;

        void Awake()
        {
            Instantiate(homePrefab);
            SpawnAgents();
            StartCoroutine(SpawnResources());
        }

        void SpawnAgents()
        {
            for (var i = 0; i < agentsCount; i++)
            {
                var rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
                var position = new Vector3(Random.Range(0f, 0.3f), 0, 0);
                Instantiate(agentPrefab, rotation * position, Quaternion.identity);
            }
        }

        IEnumerator SpawnResources()
        {
            recycledResources = new List<Resource>();
            for (var i = 0; i < maxResourceCount; i++)
            {
                var resource = Instantiate(resourcePrefab);
                resource.OnPicked += Resource_OnPick;
                resource.OnConsumed += Resource_OnConsume;
                resource.gameObject.SetActive(false);
                recycledResources.Add(resource);
            }

            while (true)
            {
                if (recycledResources.Count > 0)
                {
                    var rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
                    var position = new Vector3(Random.Range(0.5f, 1f), 0, 0);
                    var resource = recycledResources[0];
                    resource.transform.position = rotation * position;
                    resource.gameObject.SetActive(true);
                    recycledResources.RemoveAt(0);
                }
                yield return new WaitForSeconds(Random.Range(resourceProductionRate * 0.5f, resourceProductionRate));
            }
        }

        void Resource_OnPick(Resource resource)
        {
        }

        void Resource_OnConsume(Resource resource)
        {
            recycledResources.Add(resource);
        }
    }
}