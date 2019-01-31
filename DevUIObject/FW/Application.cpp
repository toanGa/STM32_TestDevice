#include "Application.h"

static vector<Application*> UserApps;
int Application::AppIdCount = 0;

Application::Application()
{
	PRINTF("App created\r\n");
}

Application::~Application()
{
	PRINTF("App deleted\r\n");
}

void Application::Run(Window * mainWd)
{
	Application* currApp = AppCurrent();
	Application* newApp = new Application();

	newApp->AppId = GenNewAppID();
	newApp->MainWd = mainWd;
	newApp->AppWindows.push_back(mainWd);

	newApp->Name = mainWd->Name;

	UserApps.push_back(newApp);

	// TODO:
	// old app is pause
	if (currApp != NULL)
	{
		currApp->OnPause();
	}

	// new app is created
	newApp->OnStart();
}

void Application::Exit()
{
	Application* currApp = AppCurrent();
	// TODO: 
	// current app is closed
	currApp->OnStop();
	delete currApp;

	UserApps.pop_back();

	// previous app is resume
	currApp = AppCurrent();
	if (currApp != NULL)
	{
		currApp->OnResume();
	}
	else
	{
		SOS_DEBUG("Nothing App running -> back to system control\r\n");
	}
}

Application * Application::FindApp(char * name)
{
	Application *app = NULL;
	int numsApp = UserApps.size();
	int i;
	for (i = 0; i < numsApp; i++)
	{
		if (strcmp(name, UserApps.at(i)->Name) == 0)
		{
			app = UserApps.at(i);
			break;
		}
	}
	return app;
}

bool Application::AppExisted(char * name)
{
	return (FindApp(name) != NULL);
}

Application * Application::AppCurrent()
{
	Application *app = NULL;
	int numApps = UserApps.size();
	if (numApps > 0)
	{
		app = UserApps.at(numApps - 1);
	}
	return app;
}

void Application::StartWindow(Window* newWindow)
{
	this->AppWindows.push_back(newWindow);
}

Window* Application::CurrentWindow()
{
	Window* currWd = NULL;
	int numWindows = this->AppWindows.size();
	if(numWindows > 0)
	{
		currWd = this->AppWindows.at(numWindows - 1);
	}

	return currWd;
}

Window* Application::MainWindow()
{
	return this->MainWd;
}

void Application::CloseCurrentWindow()
{
	CloseWindow(CurrentWindow());
}

void Application::CloseWindow(Window* wd)
{
	int i;
	int numWindows = this->AppWindows.size();

	if(wd != this->MainWd)
	{
		for(i = 0; i < numWindows; i++)
		{
			if(wd == this->AppWindows.at(i))
			{
				// clean resource when window stop
				wd->WndProcAppMessage(WindowStop);
				delete wd;

				UserApps.erase(UserApps.begin() + i);
				break;
			}
		}
	}
	else
	{
		Application::Exit();
	}
}

void Application::HandleMessage(Message m)
{
	Application* app = AppCurrent();
	Window* currWd = app->CurrentWindow();

	currWd->WndProc(m);
}

int Application::GenNewAppID()
{
	AppIdCount++;

	return AppIdCount;
}

void Application::OnStart()
{
	SOS_DEBUG("App Start:%s\r\n", this->Name);

	// start main window
	this->MainWd->WndProcAppMessage(WindowStart);
}

void Application::OnResume()
{
	SOS_DEBUG("App Resume:%s\r\n", this->Name);

	this->CurrentWindow()->WndProcAppMessage(WindowResume);
}

void Application::OnPause()
{
	SOS_DEBUG("App Paused:%s\r\n", this->Name);

	this->CurrentWindow()->WndProcAppMessage(WindowPause);
}

void Application::OnStop()
{
	SOS_DEBUG("App Stop:%s\r\n", this->Name);

	Window* wd;
	// clean resource
	int numWindows = this->AppWindows.size();
	int i;
	for (i = 0; i < numWindows; i++)
	{
		wd = this->AppWindows.at(i);
		wd->WndProcAppMessage(WindowStop);
		delete wd;
	}
}
