#include <iostream>
#include <cmath>

using namespace std;

double my_function(double x)
{
    return sin(x) + 0.25;
}

int main()
{
    double eps = 0.000000001;
    double a = 1.0;
    double b = 2.0;

    double x_next = (a + b) / 2.0;
    double x;


    do {
        x = x_next;
        x_next = my_function(x);
        
    } while (abs(x - x_next) >= eps);
    cout << x << endl;

    return 0;
}