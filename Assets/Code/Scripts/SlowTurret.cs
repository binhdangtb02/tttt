using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTurret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float aps = 4f;
    [SerializeField] private float freeTime = 1f;

    private float timeUtilFire;

    private void Update()
    {
        timeUtilFire += Time.deltaTime;
        if(timeUtilFire >= 1f / aps)
        {
            FreeEnemies();
            timeUtilFire = 0f;
        }
    }

    private void FreeEnemies()
    {
        RaycastHit2D[] hits = Physics2D
            .CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if(hits.Length > 0 )
        {
            for(int i =0; i< hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.UpdateSpeed(0.5f); 
                StartCoroutine(ResetEnemySpeed(em));
            }
        }
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement em)
    {
        yield return new WaitForSeconds(freeTime);
        em.ResetSpeed();
    }
}
