
using System.Text;

ReverseString1("Hello, World!");
ReverseString2("Hello, World!");
HowManyAreTrue1(new List<bool>() { true, false });
HowManyAreTrue2(new List<bool>() { true, false });






string ReverseString1(string input)
{
    char[] charrArray = input.ToCharArray();
    Array.Reverse(charrArray);
    return new string(charrArray);
}





// Zasada KISS
// Lepsze Maintainability
// Lepsze Collaboration
string ReverseString2(string input)
{
    return new string(input.Reverse().ToArray());
}






int HowManyAreTrue1(IEnumerable<bool> bools)
{
    int count = 0;

    foreach (bool item in bools)
    {
        if (item)
        {
            count++;
        }
    }

    return count;
}

int HowManyAreTrue2(IEnumerable<bool> bools)
{
    return bools.Count(item => item);
}












void ShowResults1(int a, int b, int c, int d)
{
    var result = MethodOne(MethodTwo(a, MethodThree(b)), c, d);
    Console.WriteLine(result);
}

void ShowResults2(int a, int b, int c, int d)
{
    var result3 = MethodThree(b);
    var result2 = MethodTwo(a, result3);
    var result = MethodOne(result2, c, d);
    Console.WriteLine(result);
}
















int MethodThree(int b)
{
    return b + 5;
}

int MethodTwo(int a, int value)
{
    return a + 10;
}

int MethodOne(int value, int c, int d)
{
    return value + c + d;
}




