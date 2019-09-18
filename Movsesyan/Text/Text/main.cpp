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
	string kek = ""; //строка, в котрую запишеться текст

	getline(cin, kek); // здесь считываем весь текст

	vector<string> words = split(kek, ' '); // разбиваем текст по словам и записываем в вектор

	if (words.size() == 0) // проверка на непустой текст, чтобы не вылетало
		return 0;

	string last = words.back(); // берем последнее
	
	words.pop_back(); // отбрасываем последнее слово, т.к. оно уже у нас отдельно
	last.pop_back(); // отбрасываем точку, чтобы было удобно сравнивать

	vector<string> good_words; // вектор подходящих нам слов

	for each (string s in words) // проходимся по всем словам
	{
		if (s != last) // если не то же самое, что и последнее, то включаем в список подходящих
			good_words.push_back(s);
	}

	if (good_words.size() == 0)
	{
		cout << "Нет подходящих слов" << endl;
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