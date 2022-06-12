using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackAnimationController : MonoBehaviour
{
    [SerializeField]private float timeWindow = 0.3f; 

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButton(0))
        {
            OnClick();
        }

    }

    void OnClick()
    {
        //First attack
        if(!isAttacking() && !_animator.GetBool("canCombo"))
        {
            _animator.SetBool("isAttacking",true);
            _animator.SetTrigger("swing");
            _animator.SetBool("canCombo", false);
        }
        //Next attack
        else if(!isAttacking() && _animator.GetBool("canCombo"))
        {
            StopCoroutine("ComboWindow");
            _animator.SetBool("isAttacking",true);
            _animator.SetTrigger("swing");
            _animator.SetBool("canCombo", false);
        }
    }

    public bool isAttacking()
    {
        return _animator.GetBool("isAttacking");
    }

    public void SetupCombo() 
    {
        _animator.SetBool("isAttacking", false);
        _animator.SetBool("canCombo", true);
        StartCoroutine(ComboWindow());
    }

    IEnumerator ComboWindow()
    {
        yield return new WaitForSeconds(timeWindow);
        _animator.SetBool("canCombo", false);
    }

    public void EndAttack() 
    {
        _animator.SetBool("isAttacking", false);
    }
}