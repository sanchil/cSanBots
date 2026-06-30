
using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
namespace Phy.Lib;

interface IStrategies
{
    public void sayHello();
    public CSignal getSignal();
    public SIG Strategy_1(in T_SIG tSig);
    public SIG Strategy_2(in T_SIG tSig, in double totalTradeProfits);
    public SIG Strategy_3(in T_SIG tSig, in double totalTradeProfits);
    public SIG Strategy_4(in T_SIG tSig, in double totalTradeProfits);

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
            Log.print($"Strategy_1: fsig5={tSig.fsig5}, fsig30={tSig.fsig30}, microWaveSIG={tSig.microWaveSIG}, baseSlopeSIG={tSig.baseSlopeSIG}");
            return tSig.fsig30;
        }
        else
        {
            Log.print($"Strategy_1: CLOSE");
            return SIG.CLOSE;
        }

        //################################################################################################################

    }

    public SIG Strategy_2(in T_SIG tSig, in double totalTradeProfits)
    {
        Log.print($"Point 1: Strategy_2: fsig5={tSig.fsig5}, fsig30={tSig.fsig30}, fastSIG={tSig.fastSIG}, baseSlopeSIG={tSig.baseSlopeSIG}");
        ////################################################################################################################
        //############################# baseSlope Strategy  [close on baseSlope != Close]
        //################################################################################################################
        if (
           (tSig.baseSlopeSIG != SIG.CLOSE)
           && (tSig.fastSIG == SIG.HOLD)
        )
        {
            Log.print($"Strategy_2: Signal CLOSE");
            return SIG.CLOSE;
        }
        else if ((tSig.baseSlopeSIG == SIG.CLOSE)
        && (totalTradeProfits >= 4.0)
        )
        {
            Log.print($"Strategy_2: Profit CLOSE");
            return SIG.CLOSE;
        }
        else if (
           (tSig.fsig5 == tSig.fsig30)
           && (tSig.fsig30 == tSig.fastSIG)
           && ((tSig.fsig30 == SIG.BUY) || (tSig.fsig30 == SIG.SELL))
           && (tSig.fsig30 == tSig.baseSlopeSIG)
        )
        {
            Log.print($"Point 2: Strategy_2: fsig5={tSig.fsig5}, fsig30={tSig.fsig30}, fastSIG={tSig.fastSIG}, baseSlopeSIG={tSig.baseSlopeSIG}");
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
            Log.print($"Strategy_3: Signal CLOSE");
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
            Log.print($"Point 3: Strategy_3: fsig5={tSig.fsig5}, fsig30={tSig.fsig30}, fastSIG={tSig.fastSIG}, baseSlopeSIG={tSig.baseSlopeSIG}");
            return tSig.fsig30;
        }
        //################################################################################################################
        return SIG.NOSIG;
    }

    public SIG Strategy_4(in T_SIG tSig, in double totalTradeProfits)
    {
        //################################################################################################################
        //############################# baseSlope Strategy [close on baseSlope = Close]
        //################################################################################################################
        if (
          (tSig.slope30SIG == SIG.CLOSE)
          && (tSig.fastSIG == SIG.HOLD)
        )
        {
            Log.print($"Strategy_4: Signal CLOSE");
            return SIG.CLOSE;
        }
        else if ((tSig.slope30SIG == SIG.CLOSE)
        && (totalTradeProfits >= 4.0)
        )
        {
            Log.print($"Strategy_4: Profit CLOSE");
            return SIG.CLOSE;
        }
        else if (
          (tSig.slope30SIG == SIG.BUY || tSig.slope30SIG == SIG.SELL)
        )
        {
            Log.print($"Point 3: Strategy_4: slope30SIG={tSig.slope30SIG}");
            return tSig.slope30SIG;
        }
        //################################################################################################################
        return SIG.NOSIG;
    }
}
