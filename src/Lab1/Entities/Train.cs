using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Segments;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Train
{
    private double _acceleration;

    private IForceApplicator? _applicator;

    public double Velocity { get; private set; }

    private Mass Mass { get; }

    private MaxForce MaxForce { get; }

    private Accuracy Accuracy { get; }

    public Train(Mass mass, MaxForce maxForce, Accuracy accuracy)
    {
        Mass = mass;
        MaxForce = maxForce;
        Accuracy = accuracy;
    }

    public TimeResult CalculateTime(Distance distance)
    {
        if (_acceleration == 0 && Velocity == 0)
        {
            return new TimeResult.Fail();
        }

        double time = 0;
        double remainingDistance = distance.Value;
        while (remainingDistance > 0)
        {
            double resVelocity = Velocity + (_acceleration * Accuracy.Value);
            if (resVelocity <= 0)
            {
                return new TimeResult.Fail();
            }

            double traveled = resVelocity * Accuracy.Value;
            remainingDistance -= traveled;
            time += Accuracy.Value;

            Velocity = resVelocity;
        }

        return new TimeResult.Success(time);
    }

    public bool ApplyForce(IForceApplicator forceApplicator)
    {
        double force = forceApplicator.Force;
        if (Math.Abs(force) > MaxForce.Value)
        {
            return false;
        }

        _acceleration = force / Mass.Value;
        _applicator = forceApplicator;
        return true;
    }

    public bool ResetForce(IForceApplicator forceApplicator)
    {
        if (!ReferenceEquals(_applicator, forceApplicator))
        {
            return false;
        }

        _acceleration = 0;
        _applicator = null;
        return true;
    }
}