typedef struct _PassengerStruct
{
    wchar_t type[100];
    int volume;
    int power;
    int price;
    int doors;
} PassengerStruct;
typedef struct _CargoStruct
{
    wchar_t type[100];
    int volume;
    int power;
    int price;
    int weight;
} CargoStruct;
typedef struct _KamazStruct
{
    wchar_t type[100];
    int volume;
    int power;
    int price;
    int weight;
    wchar_t model[100];
} KamazStruct;

#pragma once	
extern "C" __declspec(dllexport) bool InputPassenger(PassengerStruct* ptr);
extern "C" __declspec(dllexport) bool OutputPassenger(PassengerStruct* ptr);
extern "C" __declspec(dllexport) bool InputCargo(CargoStruct* ptr);
extern "C" __declspec(dllexport) bool OutputCargo(CargoStruct* ptr);
extern "C" __declspec(dllexport) bool InputKamaz(KamazStruct* ptr);
extern "C" __declspec(dllexport) bool OutputKamaz(KamazStruct* ptr);
extern "C" __declspec(dllexport) bool InputStr(wchar_t*, int length);
extern "C" __declspec(dllexport) int InputInt();
extern "C" __declspec(dllexport) bool OutputStr(wchar_t*, int length);
extern "C" __declspec(dllexport) bool OutputInt(int num);