using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackAnimationController : MonoBehaviour
{
    [SerializeField] private float maxComboDelay = 1f;

    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    private float lastClickedTime = 0;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {

        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            _animator.SetBool("hit1", false);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            _animator.SetBool("hit2", false);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            _animator.SetBool("hit3", false);
            noOfClicks = 0;
        }


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
    }

    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            _animator.SetBool("hit1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            _animator.SetBool("hit1", false);
            _animator.SetBool("hit2", true);
        }
        if (noOfClicks >= 3 && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            _animator.SetBool("hit2", false);
            _animator.SetBool("hit3", true);
        }
    }
    public bool isAttacking()
    {
        if(_animator.GetBool("hit1") || _animator.GetBool("hit2") || _animator.GetBool("hit3"))
        {
            return true; 
        }
        return false;
    }
}