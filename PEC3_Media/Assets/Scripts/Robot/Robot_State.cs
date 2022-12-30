using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_State
{
    protected Robot_Controller robotController;
    protected Robot_StateMachine stateMachine;

    protected float startTime; // Referencia para saber cuanto lleva en cada estado

    private string animBoolName; // En esta variable se guardar� informacion para las animaciones, as� el animator sabr� que animaci�n deber� usar.

    public Robot_State(Robot_Controller robotController, Robot_StateMachine stateMachine)
    {
        this.robotController = robotController;
        this.stateMachine = stateMachine;
    }

    // Enter() se ejecutar� al entrar en un estado
    public virtual void Enter()
    {
        Debug.Log("Zombie1: " + animBoolName);
    }

    // Exit() se ejecutar� al salir del estado
    public virtual void Exit()
    {
        // Comprobamos si el cambio tiene animaci�n para evitar advertencias 
        if (animBoolName != "")
        {
            //zombie1.Anim.SetBool(animBoolName, false); // ponemos el animator en false al salir
        }

    }

    // LogicUpdate() se ejecutar� en cada Update()
    public virtual void LogicUpdate()
    {

    }

    // PhysicsUpdate se ejecutar� en cada FixedUpdate()
    public virtual void PhysicsUpdate()
    {

    }
}
