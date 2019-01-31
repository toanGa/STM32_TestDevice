#pragma once
#include "Window.h"
class Application
{
private:
	
	static int AppIdCount;
	int AppId;
	Window* MainWd;
	vector<Window*> AppWindows;
public:
	typedef enum
	{
		WindowStart,
		WindowResume,
		WindowPause,
		WindowStop
	}AppMessage;

	Application();
	~Application();
	char* Name;
	static void Run(Window* mainWd);
	static void Exit();
	static Application* FindApp(char* name);
	static bool AppExisted(char* name);
	static Application* AppCurrent();

	void StartWindow(Window* newWindow);
	Window* CurrentWindow();
	Window* MainWindow();
	void CloseCurrentWindow();
	void CloseWindow(Window* wd);
	static void HandleMessage(Message m);
private:
	static int GenNewAppID();
	void OnStart();
	void OnResume();
	void OnPause();
	void OnStop();
};

