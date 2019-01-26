using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private enum STATE { IDLE, MOVE };
    private STATE state;
    private Transform target;
    private UISprite sprite;
    private List<string> iconList;
    private int iconIndex;
    private float timer;

    public float speed;
    public float switchIdle;

    private void Awake()
    {
        state = STATE.IDLE;
        speed = 0.3f;
        switchIdle = 0.2f;
        iconList = new List<string> { "Emoticon - Annoyed", "Emoticon - Frown" };
        sprite = GetComponentInChildren<UISprite>();
    }

    private void OnIdle()
    {
        //切换idle状态
    }

    private void OnMove()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            state = STATE.IDLE;
            sprite.spriteName = iconList[0];
            return;
        }
        timer += Time.deltaTime;
        if (timer > switchIdle)
        {
            timer = 0.0f;
            iconIndex = (iconIndex + 1) % iconList.Count;
            sprite.spriteName = iconList[iconIndex];
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    private void Update()
    {
        switch(state)
        {
            case STATE.IDLE:
                OnIdle();
                break;
            case STATE.MOVE:
                OnMove();
                break;
        }
    }

    public void Move(Transform tf)
    {
        if (state == STATE.MOVE)
            return;
        state = STATE.MOVE;
        target = tf;
        timer = 0.0f;
        iconIndex = 0;
    }
}
