using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BntPackController : MonoBehaviour
{
    private Animator animator;
    private BntPack2Controller btPack2Controller;
    private BntPack3Controller btPack3Controller;
    private BntPack4Controller btPack4Controller;

    private void Start()
    {
        animator = GetComponent<Animator>();
        btPack2Controller = Object.FindFirstObjectByType<BntPack2Controller>();
        btPack3Controller = Object.FindFirstObjectByType<BntPack3Controller>();
        btPack4Controller = Object.FindFirstObjectByType<BntPack4Controller>();
    }

<<<<<<< HEAD
    public void OnButtonClicked1()
    {
        animator.SetBool("Disabled", false);
=======
    public void OnButtonClicked()
    {
        animator.SetTrigger("On");
>>>>>>> f2069d3f76518f4d4adbbc6ac554bec9a59f2b8d
        btPack2Controller.DisableButton();
        btPack3Controller.DisableButton3();
        btPack4Controller.DisableButton();
    }

    public void DisableButton()
    {
        animator.SetBool("Disabled", true);
    }
}
