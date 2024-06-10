#pragma once
class cashRegister
{
public:
	int getCurrentBalance() const
	{
		return cashOnHand;
	}


	void acceptAmount(int amountIn)
	{
		cashOnHand = cashOnHand + amountIn;
	}

	cashRegister(int cashIn = 500)
	{
		if (cashIn >= 0)
			cashOnHand = cashIn;
		else
			cashOnHand = 500;
	}

private: 
	int cashOnHand;
};

class dispenserType
{
public:
	int getNoOfItems() const
	{
		return numberOfItems;
	}

	int getCost() const
	{
		return cost;
	}

	void makeSale()
	{
		numberOfItems--;
	}

	dispenserType(int setNoOfItems, int setCost)
	{

		if (setNoOfItems >= 0)
			numberOfItems = setNoOfItems;
		else
			numberOfItems = 50;
		if (setCost >= 0)
			cost = setCost;
		else
			cost = 50;
	}
private: 
	int numberOfItems;
	int cost;



};

