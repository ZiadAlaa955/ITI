#include <iostream>
#include <conio.h>

using namespace std;

int main()
{
	int column = 1, key;
	char ch[20];
	for (int i = 0; i < 20; i++) ch[i] = ' ';
	char* startptr = ch;
	char* currptr = ch;
	char* endptr = ch + 19;

	cout << "\033[1;" << column << "H\033[41m                    \033[0m";
	do
	{
		cout << "\033[1;" << column << "H";
		key = _getch();
		
		switch (key) {
		case 224:
				key = _getch();
				switch (key)
				{
				case 75: // left
					if (currptr > startptr)
					{
						column--;
						currptr--;
					}
					break;
				case 77: //right
					if (currptr < endptr) {
						column++;
						currptr++;
					}
					break;
				case 79: //end
					column = 20;
					currptr = endptr;
					break;
				case 71: //home
					column = 1;
					currptr = startptr;
					break;
				}
			break;
		case 8: //backspace
		{
			if (currptr > startptr) {

				column--;
				currptr--;
				
				for (char* ptr = currptr; ptr < endptr; ptr++) {
					*ptr = *(ptr + 1);
				}
				*endptr = ' ';

				cout << "\033[41;30m\033[1;1H";
				for (char* ptr = startptr; ptr <= endptr; ptr++) {
					cout << *ptr;
				}
				cout << "\033[0m";

				cout << "\033[1;" << column << "H";
			}
		}
			break;
		case 13: //enter
		{
			system("cls");
			cout << "You typed: ";
			char* ptr = startptr;
			for (int i = 0; i < 20; i++) {
				cout << *ptr;
				ptr++;
			}
		}
			break;
		default: // enter other keys
			if (currptr <= endptr) {
				for (char* ptr = endptr; ptr > currptr; ptr--) {
					*ptr = *(ptr - 1);
				}
				*currptr = key;

				char* ptr = startptr;
				cout << "\033[41;30m\033[1;1H";
				for (int i = 0; i < 20; i++) {
					cout << *ptr;
					ptr++;
				}
				cout << "\033[0m";

				if (currptr <= endptr) {
					column++;
					currptr++;
				}
				cout << "\033[1;" << column << "H";
			}
			break;
		}
	} while (key != 13);

	return 0;
}
