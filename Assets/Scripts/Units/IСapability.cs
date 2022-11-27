using UnityEngine;

public interface ICapability
{
    void Initialise();
    void Execute();
}

//public class DoMotion : ICapability
//{
//    public void Initialise() { }
//    public void Execute() { }
//}

//public class Fly : ICapability
//{
//    public void Initialise(IGroundCheck groundCheck) { }
//    public void Execute(Vector3 direction) { }

//    //public void Initialise(){ }
//    //public void Execute(){}

//}

//public class Manager
//{
//    public ICapability fly;

//    private void Invoke()
//    {
//        fly.Execute(Vector3.one);
//    }
//}