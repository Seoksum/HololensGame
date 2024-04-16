using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyCollider : MonoBehaviour
{
    public Countdown _countDown;
    //Enemy1 enemy;
    //Enemy1 enemy2;

    bool nextDummy = true;
    int count = 0;
    int EnemyListIdx = 0;
    int MonsterCount = 3;
    bool isPlaying;
    bool isMaking;

    GameObject[] DummyArray;
    [SerializeField] GameObject NextSceneCanvas;
    [SerializeField] GameObject Dummy1;
    [SerializeField] GameObject Dummy2;
    [SerializeField] GameObject Dummy3;

    void Start()
    {
        DummyArray = new GameObject[MonsterCount + 1];
        isPlaying = true;
        isMaking = true;

        count++;

        DummyArray[0] = Dummy1;
        DummyArray[1] = Dummy2;
        DummyArray[2] = Dummy3;
        DummyArray[3] = null;
        SetEnemy1(Dummy1);

    }

    void Update()
    {

        if (Dummy1.activeSelf == false && isMaking==true)
        {
            MakeEnemy();
        }

        if (EnemyListIdx == MonsterCount)
        {
            _countDown.StopPlaying();
            NextSceneCanvas.SetActive(true);
        }

    }
    void MakeEnemy()
    {
        isPlaying = true;
        int StageEnemyCount = 2;
        for (int i = count; i < count + StageEnemyCount; i++)
        {
            DummyArray[i].SetActive(true);
            DummyArray[i].GetComponent<Moveable>().EnemyMove();
            SetEnemy2(DummyArray[i]);
        }

        count += StageEnemyCount;
        isMaking = false;
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Enemy1 enemy = col.gameObject.GetComponent<Enemy1>();
            enemy.Damaged(10);

            if (enemy.Hp < 0 && !enemy.IsDied)
            {
                col.gameObject.GetComponent<Enemy1>().Hp = 0;
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
        DummyArray[EnemyListIdx++].SetActive(false);

    }



    void SetEnemy1(GameObject dummy)
    {
        Enemy1 enemy = dummy.GetComponent<Enemy1>();
        enemy.Hp = 30;
        enemy.Attack = 10;
        enemy.Name = "Enemy";
        enemy.IsDied = false;
    }
    void SetEnemy2(GameObject dummy)
    {
        Enemy1 enemy = dummy.GetComponent<Enemy1>();
        enemy.Hp = 50;
        enemy.Attack = 10;
        enemy.Name = "Enemy";
        enemy.IsDied = false;
    }
}
