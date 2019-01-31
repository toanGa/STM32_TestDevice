#include <stdio.h>
#include "uart_console.h"
#include "ClassFuntionPointer.h"

void (*SleepOut)();

class People
{
	
public:
	typedef void (People::*GoDef)();
	typedef void (People::*SleepDef)();

	GoDef Go;
	SleepDef Sleep;

	typedef void(*SleepInDef)();
	SleepInDef SleepIn;
};

class Man : public People
{
public:
	typedef void (Man::*GetWife)();
	void ManGo()
	{
		SOS_DEBUG("Man Go\r\n");
	}

	void ManSleep()
	{
		SOS_DEBUG("Man Sleep\r\n");
	}

	Man()
	{
		this->Go = static_cast<void (People::*)()>(&Man::ManGo);
		this->Sleep = static_cast<void (People::*)()>(&Man::ManSleep);

		(this->*Go)();
		(this->*Sleep)();
	}

	void ManTest()
	{
		(this->*Go)();
		(this->*Sleep)();
	}
};

class Woman : public People
{
public:
	typedef void (Woman::*GetHuban)();

	void WomanGo()
	{
		SOS_DEBUG("Woman Go\r\n");
	}

	void WomanSleep()
	{
		SOS_DEBUG("Woman Sleep\r\n");
	}

	Woman()
	{
		this->Go = static_cast<void (People::*)()>(&Woman::WomanGo);
		this->Sleep = static_cast<void (People::*)()>(&Woman::WomanSleep);

		//this->SleepIn = static_cast<SleepInDef>(&Woman::WomanSleep);;
		(this->*Go)();
		(this->*Sleep)();
	}

	void WmTest()
	{
		(this->*Go)();
		(this->*Sleep)();
	}
};

void TestFunPtr()
{
	Man man;
	Woman wm;
	man.ManTest();
	wm.WmTest();
}