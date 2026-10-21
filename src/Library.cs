namespace Pas2.RationalNumbers;

using System.Numerics;

public sealed record Rational
{
    public BigInteger Numerator { get; }
    public BigInteger Denominator { get; }

    public Rational(BigInteger numerator, BigInteger denominator)
    {
        if (denominator.IsZero)
            throw new DivideByZeroException();
        if (denominator.Sign < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
        BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public static Rational operator +(Rational a, Rational b) =>
        new(
            a.Numerator * b.Denominator + b.Numerator * a.Denominator,
            a.Denominator * b.Denominator
        );

    public static Rational operator -(Rational a, Rational b) =>
        new(
            a.Numerator * b.Denominator - b.Numerator * a.Denominator,
            a.Denominator * b.Denominator
        );

    public static Rational operator *(Rational a, Rational b) =>
        new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

    public static Rational operator /(Rational a, Rational b) =>
        new(a.Numerator * b.Denominator, a.Denominator * b.Numerator);

    public override string ToString() =>
        Numerator.ToString(System.Globalization.CultureInfo.InvariantCulture)
        + "/"
        + Denominator.ToString(System.Globalization.CultureInfo.InvariantCulture);
}
