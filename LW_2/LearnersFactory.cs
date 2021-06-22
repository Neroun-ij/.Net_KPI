using System;
using System.Collections.Generic;
using System.Text;

namespace LW_2
{
    class LearnersFactory
    {
        private static Dictionary<LearnerType, ILearner> learners = new Dictionary<LearnerType, ILearner>();
        public static ILearner GetPlanetoryObject(LearnerType learner)
        {
            if (learners.ContainsKey(learner))
                return learners[learner];
            else
            {
                ILearner newObject = null;
                if (learner == LearnerType.Schoolchild)
                {
                    newObject = new Schoolchild();
                    learners.Add(LearnerType.Schoolchild, newObject);
                }
                else if (learner == LearnerType.Bachelor)
                {
                    newObject = new Bachelor();
                    learners.Add(LearnerType.Bachelor, newObject);
                }
                else
                {
                    newObject = new Master();
                    learners.Add(LearnerType.Master, newObject);
                }
                return newObject;
            }
        }
    }
}
