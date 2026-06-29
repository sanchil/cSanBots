
using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
namespace Phy.Lib;

interface IStrategies
{
    public void sayHello();
}
public class CStrategies : IStrategies
{
    private CSignal _signal;
    public CStrategies(PhysicsEngine engine, CStats stats, CUtils utils)
    {

        _signal = new CSignal(engine, stats, utils);
    }

    public void sayHello()
    {
        Console.WriteLine("Hello, World!");
    }

}
