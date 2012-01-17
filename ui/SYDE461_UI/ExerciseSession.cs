using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYDE461_UI
{
    class ExerciseSession
    {
        UserInfo user;
        enum exerciseType { pinch, squeeze, pickup };
        enum exerciseState { pending, incomplete, cancelled, complete };
        int attempts;
        DateTime startTime;
        DateTime endTime;
        int reps;
        int completedReps;

        //save exercise session to memory
        //add exercise session to user history info
        //delete exercise session

        ExerciseSession(UserInfo user)
        {

           //for (UserHistoryData

            this.user = user;
            this.startTime = DateTime.Now;
            this.attempts = 0;
        }

        void addSessiontoHistory(UserInfo user, UserHistoryData userHistory)
        {
            //add session to beginning of user history
        }
    }
}
