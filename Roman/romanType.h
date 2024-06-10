#pragma once
#include <iostream>
#include <list>
using namespace std;
class romanType
{
public: 
	

	void convertToDeciamal()
	{
		if (romanChar == 'M')
			romanNumeral = 1000;
		else if (romanChar == 'D')
			romanNumeral = 500;
		else if (romanChar == 'C')
			romanNumeral = 100;
		else if (romanChar == 'L')
			romanNumeral = 50;
		else if (romanChar == 'X')
			romanNumeral = 10;
		else if (romanChar == 'V')
			romanNumeral = 5;
		else if (romanChar == 'I')
			romanNumeral = 1;
		else
			cout << "Please enter the roman characters";
	}

	romanType(string c)
	{
		for (int i = 0; i < 8; i++)
		{
			mylist.push_back(i);
		}
	}

	int getRomanNumeral()
	{
		return romanNumeral;
	}






private: 
	int romanNumeral;
	char romanChar;
	string romanString[8];
	list<char> mylist;
};

