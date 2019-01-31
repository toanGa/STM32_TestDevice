#include "../Application.h"
#include "../TextBox.h"

class MyWindow1 :
	public Window
{
private:
	void Wd1KeyPress(void* sender, KeyEventArgs e)
	{
		/*MyWindow2 *wd = new MyWindow2();
		wd->Start();*/
		this->Stop();
	}
public:
	TextBox tb1;
	TextBox tb2;
	MyWindow1()
	{
		Init();
	}
	~MyWindow1()
	{
		PRINTF("%s:Window closed\r\n", this->Name);
	}

	void Init()
	{
		this->Name = "MyMainWindow1";
		this->Width = 240;
		this->Height = 320;

		tb1.Name = "tb1";
		tb1.TabIndex = 1;

		tb2.Name = "tb1";
		tb2.TabIndex = 2;

		this->Add(&tb1);
		this->Add(&tb2);

		tb1.KeyPress = ON_KEY_CALLBACK(MyWindow1::Wd1KeyPress);
	}

	
};

class MyWindow2 :
	public Window
{
private:
	void Wd2KeyPress(void* sender, KeyEventArgs e)
	{
		Application::Exit();
	}
public:
	TextBox tb1;
	TextBox tb2;
	MyWindow2()
	{
		Init();
	}

	~MyWindow2()
	{
		PRINTF("%s:Window closed\r\n", this->Name);
	}

	void Init()
	{
		this->Name = "MyWindow2";
		this->Width = 240;
		this->Height = 320;

		tb1.Name = "tb1";
		tb1.TabIndex = 1;

		tb2.Name = "tb1";
		tb2.TabIndex = 2;

		this->Add(&tb1);
		this->Add(&tb2);

		tb1.KeyPress = ON_KEY_CALLBACK(MyWindow2::Wd2KeyPress);
	}
};

class MyWindow3 :
	public Window
{
private:
	void Wd3KeyPress(void* sender, KeyEventArgs e)
	{
		Application::Exit();
	}
public:
	TextBox tb1;
	TextBox tb2;
	MyWindow3()
	{
		Init();
	}
	~MyWindow3()
	{
		PRINTF("%s:Window closed\r\n", this->Name);
	}


	void Init()
	{
		this->Name = "MyWindow3";
		this->Width = 240;
		this->Height = 320;

		tb1.Name = "tb1";
		tb1.TabIndex = 1;

		tb2.Name = "tb1";
		tb2.TabIndex = 2;

		this->Add(&tb1);
		this->Add(&tb2);

		tb1.KeyPress = ON_KEY_CALLBACK(MyWindow3::Wd3KeyPress);
	}
};

class MyWindow4 :
	public Window
{
private:
	void Wd4KeyPress(void* sender, KeyEventArgs e)
	{
		Application::Exit();
	}

public:
	TextBox tb1;
	TextBox tb2;
	MyWindow4()
	{
		Init();
	}

	~MyWindow4()
	{
		PRINTF("%s:Window closed\r\n", this->Name);
	}

	void Init()
	{
		this->Name = "MyWindow4";
		this->Width = 240;
		this->Height = 320;

		tb1.Name = "tb1";
		tb1.TabIndex = 1;

		tb2.Name = "tb1";
		tb2.TabIndex = 2;

		this->Add(&tb1);
		this->Add(&tb2);

		tb1.KeyPress = ON_KEY_CALLBACK(MyWindow4::Wd4KeyPress);
	}
};









Window Mainwd;
Window Wd1;
Window Wd2;
Window Wd3;
void TestChangeApp()
{
	Mainwd.Name = "Mainwd";
	Wd1.Name = "Window 1";
	Wd2.Name = "Window 2";
	Wd3.Name = "Window 3";

	Application::Run(&Mainwd);
	Application::Run(&Wd1);
	Application::Run(&Wd2);
	Application::Exit();
	Application::Run(&Wd3);
}

void TestChangeWindow()
{
	Message m;
	m.Msg = Message::MessageKB3Press;


	Application::Run(new MyWindow1());
	Application::HandleMessage(m);

	Application::Run(new MyWindow2());
	Application::Run(new MyWindow3());
	Application::HandleMessage(m);
	Application::Run(new MyWindow4());

}