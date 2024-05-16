using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BntPack4Controller : MonoBehaviour
{
    private Animator animator;
    private BntPack2Controller btPack2Controller;
    private BntPack3Controller btPack3Controller;
    private BntPackController btPackController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        btPack2Controller = Object.FindFirstObjectByType<BntPack2Controller>();
        btPack3Controller = Object.FindFirstObjectByType<BntPack3Controller>();
        btPackController = Object.FindFirstObjectByType<BntPackController>();
    }

<<<<<<< HEAD
    public void OnButtonClicked4()
    {
        animator.SetBool("Disabled", false);
=======
    public void OnButtonClicked()
    {
        animator.SetTrigger("On");
>>>>>>> f2069d3f76518f4d4adbbc6ac554bec9a59f2b8d
        btPackController.DisableButton();
        btPack2Controller.DisableButton();
        btPack3Controller.DisableButton3();
    }

    public void DisableButton()
    {
        animator.SetBool("Disabled", true);
    }
}
