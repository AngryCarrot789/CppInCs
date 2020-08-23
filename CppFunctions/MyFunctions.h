#include <iostream>
#include <Windows.h>

// This is simply a thing to shorten having to write _declspec(dllexport).
// Idk if it has to be the same name as the File name, but idk. easy to test if or not.
#define MyFunctions _declspec(dllexport)

// Any "Exportable" code has to be in extern. the "C" bit says that it's exporting
// C code, not C++ (i think... so many dont pass over classes.)
extern "C" {

	// Need to put the _declspec(dllexport), or the MyFunctions thing at 
	// the start (before void, or whatever the return type is)

	MyFunctions int AddNumbers(int a, int b) {
		return a + b;
	}
	MyFunctions int SubtractNumbers(int a, int b) {
		return a - b;
	}
}