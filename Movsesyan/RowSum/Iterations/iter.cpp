#include <iostream>
#include <cmath>

using namespace std;

int factorial(int n)
{
	if (n > 1)
		return n * factorial(n - 1);
	else
		return 1;
}

double row_member(int n, double x)
{
	int sign = 1;

	if (n % 2 == 0)
		sign = -1;

	return sign * pow(x, n * 2) / factorial(n * 2);
}

int main()
{
	double eps = 0.0001;
	double x = 0;

	cout << "Enter X: " << endl;
	cin >> x;

	double sum_cos = 0;
	double fn = row_member(0, x);

	for (int n = 1; fn > eps; ++n)
	{
		sum_cos += fn;
	}


	cout << sum_cos << endl;




}