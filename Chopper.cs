using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KarateChopKataOne
{
	public class Chopper
	{
		public int FindIndexOfTarget(
			int numberToFind, 
			List<int> listToSearch)
		{			
			if (listToSearch == null || listToSearch.Count == 0)
			{
				return -1;
			}
			else if (listToSearch.Count == 1)
			{
				if (numberToFind == listToSearch[0])
				{
					return 0;
				}
				else
				{
					return -1;
				}
			}
			else
			{
				List<int> topHalf = null;
				List<int> bottomHalf = null;
				SplitListInHalf(
					listToSearch,
					out topHalf,
					out bottomHalf);
				if (numberToFind < bottomHalf[0])
				{
					return FindIndexOfTarget(numberToFind, topHalf);
				}
				else
				{
					int returnedIndex = 
						FindIndexOfTarget(numberToFind, bottomHalf);
					if (returnedIndex == -1)
					{
						return -1;
					}
					else
					{
						return topHalf.Count + returnedIndex;
					}						
				}
			}
		}

		public void SplitListInHalf(
			List<int> listToSplit, 
			out List<int> topHalf, 
			out List<int> bottomHalf)
		{
			if (listToSplit.Count % 2 == 0)
			{
				int halfwayPoint = listToSplit.Count / 2;
				topHalf =
					listToSplit.Take(halfwayPoint).ToList<int>();
				bottomHalf =
					listToSplit.Reverse<int>()
					.Take(halfwayPoint).ToList<int>()
					.Reverse<int>().ToList<int>()
					;
			}
			else
			{
				int indexToSplitOn = 
					(int)Math.Floor((double)listToSplit.Count / 2);
				topHalf =
					listToSplit.Take(indexToSplitOn).ToList<int>();
				bottomHalf =
					listToSplit.Reverse<int>()
					.Take(indexToSplitOn + 1).ToList<int>()
					.Reverse<int>().ToList<int>();
			}
		}
	}
}
