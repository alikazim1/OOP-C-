#include <iostream>
using namespace std;
void findMaxMin(int arr[], int size, int& smallest, int& largest)
{
	largest = arr[0];
	smallest = arr[0];

	for (int i = 0; i < size; i++)
	{
		if (arr[i] > largest)
		{
			largest = arr[i];
		}
		if (arr[i] < smallest)
		{
			smallest = arr[i];
		}
	}

}
int main()
{
	int nums[] = { 5,1,2,3,7,9,8 };
	int size = sizeof(nums) / sizeof(nums[0]);
	int smallest, largest;
	findMaxMin(nums, size, smallest, largest);

	cout << "Largest: " << largest << " Smallest: " << smallest << endl;
	


}

