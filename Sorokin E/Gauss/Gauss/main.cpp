#include <iostream>
#include <cmath>

using namespace std;

double alpa[4] = {
    0.069432, 
    0.33001,
    0.66999,
    0.930568,
};

double beta[4] = {
    0.173927,
    0.326073,
    0.326073,
    0.173927
};

const double a = 3.14 / 2;
const double b = 3.14 / 2;

int main()
{
    double answer = 0;

    for (int i = 0; i < 4; ++i)
    {
        double x = a + (b - a) * alpa[i];

        answer += beta[i] * sin(x);
    }

    answer *= b - a;

    cout << answer << endl;

    return 0;

}