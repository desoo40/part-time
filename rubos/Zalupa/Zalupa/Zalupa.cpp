#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <string.h>
#include <conio.h>

enum Language
{
	English,
	French,
	German
};

struct Date
{
	int Day;
	int Month;
	int Year;
};

struct Student
{
	struct Date BirthDay;
	int Gradebook;
	enum Language Lang;
	float AverageScore;
};

void addStudent(struct Student *newStudent, struct Date birthDay, int gradebook, enum Language lang, float averageScore);
void displayEnglish(struct Student *students, int amount);
void restructAchievements(struct Student *students, int amount);
void displayPercent(struct Student *students, int amount);
void displayStudents(struct Student *students, int amount);
void getNameLanguage(enum Language lang, char *name);

int main()
{
	struct Student students[30];
	int amount = 0;
	int c;

	setlocale(LC_ALL, "");

	while (1)
	{
		do
		{
			printf("1. Добавить студента в список\n");
			printf("2. Вывести в файл студентов, изучающих английский язык\n");
			printf("3. Упорядочить студентов по среднему баллу\n");
			printf("4. Отобразить в процентах изучаемые языки\n");
			printf("5. Вывести список всех студентов\n");

			c = _getch();
			while (c == '\n');

		} while ((c < '1' || c > '5') && c != 27);

		if (c == 27)
			break;

		switch (c)
		{
		case '1':
		{
			struct Date birthDay;
			int gradebook;
			enum Language lang;
			float averageScore;

			if (amount >= 30)
			{
				printf("Количество студентов достигло предела\n");
				continue;
			}

			do
			{
				printf("Введите месяц рождения: ");
				scanf("%d", &birthDay.Month);
			} while (birthDay.Month < 1 || birthDay.Month > 12);

			do
			{
				printf("Введите день рождения: ");
				scanf("%d", &birthDay.Day);
			} while (birthDay.Day < 1 || birthDay.Day > 31);

			do
			{
				printf("Введите год рождения: ");
				scanf("%d", &birthDay.Year);
			} while (birthDay.Year < 1970 || birthDay.Year > 2002);
			do
			{
				printf("Введите номер зачётной книжки: ");
				scanf("%d", &gradebook);
			} while (gradebook < 1 || gradebook > 9999);
			do
			{
				printf("Введите номер изучаемого языка (англ. - 0, франц. - 1, нем. - 2): ");
				scanf("%d", &lang);
			} while (lang < 0 || lang > 2);
			do
			{
				printf("Введите средний балл: ");
				scanf("%f", &averageScore);
			} while (averageScore < 2.0f || averageScore > 5.0f);

			addStudent(&students[amount], birthDay, gradebook, lang, averageScore);
			amount++;

			break;
		}
		case '2':
		{
			displayEnglish(students, amount);
			break;
		}
		case '3':
		{
			restructAchievements(students, amount);
			printf("Студенты упорядочены по среднему баллу\n");
			break;
		}
		case '4':
		{
			displayPercent(students, amount);
			break;
		}
		case '5':
		{
			displayStudents(students, amount);
			break;
		}
		}

		printf("\n");
	}

	return 0;
}

void addStudent(struct Student *newStudent, struct Date birthDay, int gradebook, enum Language lang, float averageScore)
{
	newStudent->BirthDay = birthDay;
	newStudent->Gradebook = gradebook;
	newStudent->Lang = lang;
	newStudent->AverageScore = averageScore;
}

void displayEnglish(struct Student *students, int amount)
{
	int i;
	int t = 0;
	char langName[16];
	FILE *outfile;
	outfile = fopen("english.txt", "w");

	printf("Список студентов, изучающих английский язык:\n");
	for (i = 0; i < amount; i++)
	{
		if (students[i].Lang == 0)
		{
			t++;
			getNameLanguage(students[i].Lang, langName);
			printf("%d) %d.%d.%d, %d, %s, %0.1f\n", t, students[i].BirthDay.Day,
				students[i].BirthDay.Month, students[i].BirthDay.Year,
				students[i].Gradebook, langName, students[i].AverageScore);

			fprintf(outfile, "%d) %d.%d.%d, %d, %s, %0.1f\n", t, students[i].BirthDay.Day,
				students[i].BirthDay.Month, students[i].BirthDay.Year,
				students[i].Gradebook, langName, students[i].AverageScore);
		}
	}

	fclose(outfile);
}

void restructAchievements(struct Student *students, int amount)
{
	int i;

	for (i = 0; i < amount - 1; i++)
	{
		int j;
		for (j = i + 1; j < amount; j++)
		{
			if (students[i].AverageScore < students[j].AverageScore)
			{
				struct Student tempStud = students[i];
				students[i] = students[j];
				students[j] = tempStud;
				i--;
				break;
			}
		}
	}
}

void displayPercent(struct Student *students, int amount)
{
	int i;
	int languages[3] = { 0 };
	float percent;
	char langName[16];

	for (i = 0; i < amount; i++)
		languages[(int)students[i].Lang]++;

	printf("Изучаемые языки:\n");
	for (i = 0; i < 3; i++)
	{
		percent = languages[i] * 100.0f / amount;
		getNameLanguage((enum Language)i, langName);
		printf("%s - %0.2f\n", langName, percent);
	}
}

void displayStudents(struct Student *students, int amount)
{
	int i;
	char langName[16];

	printf("Список всех студентов:\n");
	for (i = 0; i < amount; i++)
	{
		getNameLanguage(students[i].Lang, langName);
		printf("%d) %d.%d.%d, %d, %s, %0.1f\n", i + 1, students[i].BirthDay.Day,
			students[i].BirthDay.Month, students[i].BirthDay.Year,
			students[i].Gradebook, langName, students[i].AverageScore);
	}
}

void getNameLanguage(enum Language lang, char *name)
{
	switch (lang)
	{
	case English:
	{
		strcpy(name, "английский");
		break;
	}
	case French:
	{
		strcpy(name, "французский");
		break;
	}
	case German:
	{
		strcpy(name, "немецкий");
		break;
	}
	default:
	{
		strcpy(name, "неправильно");
		break;
	}
	}
}