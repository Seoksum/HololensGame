using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    public Countdown _countDown;

    bool nextDummy = true;
    int KilledMonsterCount = 0;
    int beforeIndex = 0;
    int MonsterCount = 3;
    int DamageAmount = 10;

    int TotalKilledMonsterCount = 0;
    int StageEnemyCount = 0;

    int hp = 0;
    bool isMaking;

    GameObject[] DummyArray;
    [SerializeField] GameObject NextSceneCanvas;
    [SerializeField] GameObject Dummy1;
    [SerializeField] GameObject Dummy2;
    [SerializeField] GameObject Dummy3;


    void Start()
    {
        DummyArray = new GameObject[MonsterCount + 1];
        DummyArray[0] = Dummy1;
        DummyArray[1] = Dummy2;
        DummyArray[2] = Dummy3;
        DummyArray[3] = null;
        MakeEnemy();
    }

    void Update()
    {
        //if (TotalKilledMonsterCount == MonsterCount)
        //{
        //    _countDown.StopPlaying();
        //    NextSceneCanvas.SetActive(true);
        //}
    }

    void MakeEnemy()
    {
        hp += 30;
        for (int i = beforeIndex; i <= beforeIndex + StageEnemyCount; i++)
        {
            DummyArray[i].SetActive(true);
            DummyArray[i].GetComponent<EnemyMoving>().OnStartToRun();
            SetEnemy(DummyArray[i], hp);
        }
        KilledMonsterCount = 0;
        StageEnemyCount++;
        beforeIndex = beforeIndex + StageEnemyCount;
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.Damaged(DamageAmount);
            if (enemy.Hp <= 0 && !enemy.IsDied)
            {
                col.gameObject.GetComponent<Enemy>().Hp = 0;
                enemy.IsDied = true;
                StartCoroutine(EnemyDie(col.gameObject));
            }
        }
    }

    IEnumerator EnemyDie(GameObject obj)
    {
        Debug.Log("Enemy Died");
        obj.gameObject.GetComponentInChildren<Animator>().SetBool("IsAttack", false);
        obj.gameObject.GetComponentInChildren<Animator>().SetBool("IsDied", true);
        yield return new WaitForSeconds(2.0f);

        obj.SetActive(false);
        KilledMonsterCount++;
        TotalKilledMonsterCount++;

        if (TotalKilledMonsterCount >= MonsterCount)
        {
            _countDown.StopPlaying();
            NextSceneCanvas.SetActive(true);
        }
        else
        {
            if (KilledMonsterCount == StageEnemyCount)
            {
                MakeEnemy();
            }
        }
    }



    void SetEnemy(GameObject dummy, int _Hp)
    {
        Enemy enemy = dummy.GetComponent<Enemy>();
        enemy.Hp = _Hp;
        enemy.IsDied = false;
    }

}
