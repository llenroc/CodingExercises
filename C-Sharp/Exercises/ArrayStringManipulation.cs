namespace Exercises
{

    public static class ArrayStringManipulation
    {
	    public static bool IsFirstComeFirstServed(int[] takeOutOrders, int[] dineInOrders, int[] servedOrders)
        {
            if (servedOrders == null && (takeOutOrders != null || dineInOrders != null))
            {
                return false;
            }
    
            if (servedOrders != null)
            {
                int len = takeOutOrders == null ? 0 : takeOutOrders.Length;
                len += dineInOrders == null ? 0 : dineInOrders.Length;
                if (servedOrders.Length != len)
                {
                    return false;
                }
            }
    
            // Check if we're serving orders first-come, first-served
            int previousIn = -1; // In index
            int previousOut = -1; // Out index
            int x = 0;
            int y = 0;
    
            for (int i = 0; i < servedOrders.Length; i++)
            {
                if (y < takeOutOrders.Length && servedOrders[i] == takeOutOrders[y])
                {
                    if (previousOut > takeOutOrders[y])
                    {
                        return false;
                    }
                    previousOut = takeOutOrders[y++];
                }
        
                if (x < dineInOrders.Length && servedOrders[i] == dineInOrders[x])
                {
                    if (previousIn > dineInOrders[x])
                    {
                        return false;
                    }
                    previousIn = dineInOrders[x++];
            
                }
            }
    
            return (x == dineInOrders.Length && y == takeOutOrders.Length);
        }
 
    }
}