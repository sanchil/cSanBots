
using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
namespace Phy.Lib;

interface IStrategies
{
    public void sayHello();
    public CSignal getSignal();
}
public class CStrategies : IStrategies
{
    private CSignal _signal;
    private CStats _stats;
    private CUtils _utils;
    public CStrategies(PhysicsEngine engine, CStats stats, CUtils utils)
    {
        _utils = utils;
        _stats = stats;
        _signal = new CSignal(engine, stats, utils);
    }

    public void sayHello()
    {
        Console.WriteLine("Hello, World!");
    }

    public CSignal getSignal()
    {
        return _signal;
    }
    public SIG Strategy_1(in T_SIG tSig)
    {
        //################################################################################################################
        //############################# micWave Strategy
        //################################################################################################################
        if (
           (tSig.fsig5 == tSig.fsig30)
           && (tSig.fsig30 == tSig.microWaveSIG)
           && ((tSig.fsig30 == SIG.BUY) || (tSig.fsig30 == SIG.SELL))
        )
        {
            return tSig.fsig30;
        }
        else
        {
            return SIG.CLOSE;
        }

        //################################################################################################################




    }

    public SIG Strategy_2(in T_SIG tSig, in double totalTradeProfits)
    {
        ////################################################################################################################
        //############################# baseSlope Strategy  [close on baseSlope != Close]
        //################################################################################################################
        if (
           (tSig.baseSlopeSIG != SIG.CLOSE)
           && (tSig.fastSIG == SIG.HOLD)
        )
        {

            return SIG.CLOSE;
        }
        else if ((tSig.baseSlopeSIG == SIG.CLOSE)
        && (totalTradeProfits >= 4.0)
        )
        {
            return SIG.CLOSE;
        }
        else if (
           (tSig.fsig5 == tSig.fsig30)
           && (tSig.fsig30 == tSig.fastSIG)
           && ((tSig.fsig30 == SIG.BUY) || (tSig.fsig30 == SIG.SELL))
           && (tSig.fsig30 == tSig.baseSlopeSIG)
        )
        {
            return tSig.fsig30;

        }
        ////################################################################################################################


        return SIG.NOSIG;
    }


    public SIG Strategy_3(in T_SIG tSig, in double totalTradeProfits)
    {
        //################################################################################################################
        //############################# baseSlope Strategy [close on baseSlope = Close]
        //################################################################################################################
        if (
          (tSig.baseSlopeSIG == SIG.CLOSE)
          && (tSig.fastSIG == SIG.HOLD)
        )
        {
            return SIG.CLOSE;
        }
        else if ((tSig.baseSlopeSIG == SIG.CLOSE)
        &&(totalTradeProfits>=4.0)
        )
        {
            return SIG.CLOSE;
        }
        else if (
          (tSig.fsig5 == tSig.fsig30)
          && (tSig.fsig30 == tSig.fastSIG)
          && ((tSig.fsig30 == SIG.BUY) || (tSig.fsig30 == SIG.SELL))
          && (tSig.fsig30 == tSig.baseSlopeSIG)
        )
        {
            return tSig.fsig30;
        }
        //################################################################################################################
        return SIG.NOSIG;
    }


}
