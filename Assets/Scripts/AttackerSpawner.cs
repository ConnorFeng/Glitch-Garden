using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    float minSpawnDelay = 2f;
    [SerializeField]
    float maxSpawnDelay = 5f;
    [SerializeField]
    Attacker[] attackerPrefabArray;

    bool toSpawn = true;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(toSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
    void Update()
    {

    }

    public void StopSpawn()
    {
        toSpawn = false;
    }

    private void SpawnAttacker()
    {
        //Debug.Log(attackerPrefabArray.Length);
        int attackerIndex = Random.Range(0, 2);
       // Debug.Log(attackerIndex);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    
}
