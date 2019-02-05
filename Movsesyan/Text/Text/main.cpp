#include <iostream>
#include <sstream>
#include <cmath>
#include <string>
#include <vector>

using namespace std;

vector<string> split(const string &s, char delim)
{

	vector<string> tokens;


	if (s.size() == 0)
	{
		cout << "Empty" << endl;
		return tokens ;
	}

	string item;
	
	istringstream Str(s);
	
	while (getline(Str, item, delim))
	{
		tokens.push_back(item);
	}
	return tokens;
}

int main()
{
	string kek = ""; //������, � ������ ���������� �����

	getline(cin, kek); // ����� ��������� ���� �����

	vector<string> words = split(kek, ' '); // ��������� ����� �� ������ � ���������� � ������

	if (words.size() == 0) // �������� �� �������� �����, ����� �� ��������
		return 0;

	string last = words.back(); // ����� ���������
	
	words.pop_back(); // ����������� ��������� �����, �.�. ��� ��� � ��� ��������
	last.pop_back(); // ����������� �����, ����� ���� ������ ����������

	vector<string> good_words; // ������ ���������� ��� ����

	for each (string s in words) // ���������� �� ���� ������
	{
		if (s != last) // ���� �� �� �� �����, ��� � ���������, �� �������� � ������ ����������
			good_words.push_back(s);
	}

	if (good_words.size() == 0)
	{
		cout << "��� ���������� ����" << endl;
		return 0;
	}

	for each (string s in good_words)
	{
		int n = 0;

		for each (char c in s)
		{
			if (c == 'a' || c == 'e' || c == 'u' || c == 'i' || c == 'o')
			{
				++n;
			}

			if (n >= 3)
			{
				cout << s << endl;
				break;
			}
		}
	}

	return 0;
}