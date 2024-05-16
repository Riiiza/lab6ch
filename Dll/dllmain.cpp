// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "pch.h"
#include <iostream>
#include "dllmain.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

__declspec(dllexport)
bool InputPassenger(PassengerStruct* ptr)
{
    printf("Enter type, volume, power, price, doors: \n");
    wscanf_s(L"%s %d %d %d %d", ptr->type, 100, &ptr->volume, &ptr->power, &ptr->price, &ptr->doors);
    return TRUE;
}
__declspec(dllexport)
bool OutputPassenger(PassengerStruct* ptr)
{
    wprintf_s(L"%s %d %d %d %d", ptr->type, ptr->volume, ptr->power, ptr->price, ptr->doors);
    return TRUE;
}

__declspec(dllexport)
bool InputCargo(CargoStruct* ptr)
{
    printf("Enter type, volume, power, price, weight: \n");
    wscanf_s(L"%s %d %d %d %d", ptr->type, 100, &ptr->volume, &ptr->power, &ptr->price, &ptr->weight);
    return TRUE;
}
__declspec(dllexport)
bool OutputCargo(CargoStruct* ptr)
{
    wprintf_s(L"%s %d %d %d %d", ptr->type, ptr->volume, ptr->power, ptr->price, ptr->weight);
    return TRUE;
}

__declspec(dllexport)
bool InputKamaz(KamazStruct* ptr)
{
    printf("Enter type, volume, power, price, weight, model: \n");
    wscanf_s(L"%s %d %d %d %d %s", ptr->type, 100, &ptr->volume, &ptr->power, &ptr->price, &ptr->weight, ptr->model, 100);
    return TRUE;
}
__declspec(dllexport)
bool OutputKamaz(KamazStruct* ptr)
{
    wprintf_s(L"%s %d %d %d %d %s", ptr->type, ptr->volume, ptr->power, ptr->price, ptr->weight, ptr->model);
    return TRUE;
}
__declspec(dllexport)
bool InputStr(wchar_t* src, int length)
{
    wscanf_s(L"%s", src, length);
    return TRUE;
}

__declspec(dllexport)
int InputInt()
{
    int num;
    scanf_s("%d", &num);
    return num;
}

__declspec(dllexport)
bool OutputStr(wchar_t* src, int length)
{
    wprintf_s(L"%s ", src, length);
    return TRUE;
}

__declspec(dllexport)
bool OutputInt(int num)
{
    wprintf_s(L"%d ", num);
    return TRUE;
}
