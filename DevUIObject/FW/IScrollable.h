#pragma once
class IScrollable
{
private:
	int active;
	int total;
protected:
	bool circle;
public:
	IScrollable();
	~IScrollable();
	void SetActive(int value);
	int GetActive();
	void SetTotal(int value);
	int GetTotal();
	void EnableCircle(bool enable);
	void SetRatio(int active, int total);
protected:
	// scroll decrease
	virtual void OnScrollDec();
	// scroll increase
	virtual void OnScrollInc();

};

