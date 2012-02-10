﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SYDE461_UI
{
    class ExerciseSession
    {
        //Might make sense to move these enums to different loc
        public enum exerciseType { pinch, squeeze, pickup };
        public enum exerciseState { incomplete, cancelled, complete };
        
        
        UserInfo user;
        exerciseState state;
        exerciseType type;
        int attempts;
        int reps;
        int completedReps;
        DateTime addedDate;
        DateTime lastModified;
        DateTime startTime;
        DateTime endTime;


        //save exercise session to memory
        //add exercise session to user history info
        //delete exercise session

        //This constructor is for when a health care professional adds an exercise to the patient's
        //profile, rep number not defined
        public ExerciseSession(UserInfo user, exerciseType type)
        {

           //for (UserHistoryData
            this.user = user;
            this.type = type;
            this.state = exerciseState.incomplete; 
            this.addedDate = DateTime.Now;
            this.attempts = 0;
            //default number of reps if not indicated
            this.reps = 10;
            this.completedReps = 0;

        }

        //This constructor is for when a health care professional adds an exercise to the patient's
        //profile, rep number defined
        public ExerciseSession(UserInfo user, exerciseType type, int reps)
        {

            //for (UserHistoryData
            this.user = user;
            this.type = type;
            this.state = exerciseState.incomplete;
            this.addedDate = DateTime.Now;
            this.attempts = 0;
            this.reps = reps;
            this.completedReps = 0;

        }

        //This constructor is for copying an existing ExerciseSession, and cancelling the old session
        ExerciseSession(ExerciseSession old)
        {
            this.user = old.user;
            this.type = old.type;
            this.state = old.state;
            old.state = exerciseState.cancelled;
            this.attempts = old.attempts;
            this.addedDate = DateTime.Now;
            old.lastModified = DateTime.Now;
            this.reps = old.reps;
            this.completedReps = 0;
        }

        //Copy ExerciseSession, used by health care professional, probably to repeat an exercise
        void copyExerciseSession(ExerciseSession old)
        {
            this.user = old.user;
            this.type = old.type;
            this.state = old.state;
            this.attempts = 0;
            this.addedDate = DateTime.Now;
            this.reps = old.reps;
            this.completedReps = 0;
        }

        //
        void modifyOnStart()
        {
            this.startTime = DateTime.Now;
        }

        //When session ends when user has complete exerciese
        void modifyOnComplete()
        {
            this.state = exerciseState.complete;
            this.endTime = DateTime.Now;
            this.lastModified = DateTime.Now;
        }

        //When exercise is exited before session is complete.
        void modifyOnIncomplete()
        {
            this.state = exerciseState.incomplete;
            this.endTime = DateTime.Now;
            this.lastModified = DateTime.Now;
            this.attempts = this.attempts + 1;
        }

        //To update rep count after a rep is completed
        void updateRepCount()
        {
            this.completedReps = this.completedReps + 1;
        }

        // check if user has completed exercise
        bool checkComplete()
        {
            if (this.reps == this.completedReps);

            return true;
        }

        //add session to user history, with only username and password
        public void addSessiontoHistory()
        {
            String filename = this.user.getUsername();

            // add password check?
            try
            {
                StreamWriter writestream = new StreamWriter(filename + ".txt", true);
                writestream.WriteLine(this.state);
                writestream.WriteLine(this.type);
                writestream.WriteLine(this.attempts);
                writestream.WriteLine(this.reps);
                writestream.WriteLine(this.completedReps);
                writestream.WriteLine(this.addedDate);
                writestream.WriteLine(this.lastModified);
                writestream.WriteLine(this.startTime);
                writestream.WriteLine(this.endTime);
                writestream.Close(); 
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        //add session to user history, with user history object
        void addSessiontoHistory(UserHistoryData history)
        {

        }

        //get from user history, with username and password
        //void getSessionfromHistory(UserHistoryData history)
        //{
        //    String filename = this.user.getUsername();
        //    StreamReader readstream = new StreamReader(filename + ".txt", true);
        //}
        
        ////get from user history, with user history object
        //void getSessionfromHistory(UserHistoryData history)
        //{

        //}


    }
}
