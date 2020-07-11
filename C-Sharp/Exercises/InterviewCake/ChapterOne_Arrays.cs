namespace InterviewCake
{
    public static class ChapterOne_Arrays
    {
        // Cafe Order Checker
        public static bool IsFirstComeFirstServed(int[] takeOut, int[] dineIn, int[] served)
        {
            if (takeOut == null || dineIn == null || served == null )
                throw new System.ArgumentNullException();

            if (takeOut.Length + dineIn.Length != served.Length)
                throw new System.ArgumentException("Orders quatity don't match");

            int takeoutPointer = 0;
            int dineInPointer = 0;

            for (int i = 0; i < served.Length; i++)
            {
                int orderNumber = served[i];
                if (takeoutPointer < takeOut.Length && orderNumber == takeOut[takeoutPointer])
                    takeoutPointer++;
                else if (dineInPointer < dineIn.Length && orderNumber == dineIn[dineInPointer])
                    dineInPointer++;
                else
                    return false;
            }
            return true;
        }
    }



}