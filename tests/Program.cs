using Pas2.RationalNumbers;

static void Check(bool condition, string message)
{
    if (!condition)
        throw new Exception(message);
}
static void Fails(Action action)
{
    try
    {
        action();
    }
    catch (Exception)
    {
        return;
    }
    throw new Exception("Expected failure");
}
Check(new Rational(2, 4) == new Rational(1, 2), "normalized equality");
Check((new Rational(1, 3) + new Rational(1, 6)).ToString() == "1/2", "addition");
Check((new Rational(2, 3) / new Rational(4, 5)).ToString() == "5/6", "division");
Check(new Rational(1, -2).ToString() == "-1/2", "sign");
Check(new Rational(0, 9).ToString() == "0/1", "zero");
Fails(() => new Rational(1, 0));
Fails(() =>
{
    var result = new Rational(1, 2) / new Rational(0, 1);
});
Console.WriteLine("All checks passed");
